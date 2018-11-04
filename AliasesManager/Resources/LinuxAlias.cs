using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TestPipe
{
    class Program
    {
        const string command = [COMMAND];
        const bool load_profile = [LOAD_PROFILE];
        const bool convert_args = [CONVERT_ARGS];
        static int Main(string[] args)
        {
            //Console.TreatControlCAsInput = true;
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
            };

            string args_str = Environment.CommandLine;
            args_str = args_str.Substring(nextArg(args_str));
            if (convert_args)
                args_str = convertArgs(args_str);
            if (command != null)
                args_str = command + " " + args_str;

            Process p = new Process();
            p.StartInfo.FileName = "bash.exe";
            p.StartInfo.Arguments = "-c " + quoteParam(args_str);
            if (load_profile)
                p.StartInfo.Arguments = "--login " + p.StartInfo.Arguments;
            p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.UseShellExecute = false;
            p.Start();

            p.WaitForExit();
            return p.ExitCode;
        }

        // ----- PATHS CONVERSION -----
        static string filename_first_last_char = "[^" + Regex.Escape("/\\:*?\"<>|='") + "\\s]";
        static string filename_middle_char = "[^" + Regex.Escape("/\\:*?\"<>|") + "]";
        static string filename_regex = "(?:(?:" + filename_first_last_char + filename_middle_char + "*" + filename_first_last_char + ")|" + filename_first_last_char + ")";
        static string filename_separator_regex = "[" + Regex.Escape("/\\") + "]";
        static string path_separator_regex = "[" + Regex.Escape("='\":") + "\\s" + "]";
        static string valid_rel_path_regex = "(?:(?:" + filename_regex + filename_separator_regex + "?)+)";
        static string valid_abs_path_regex = "(?:" + filename_separator_regex + valid_rel_path_regex + "?)";
        static string start_separator_regex = "(?:^|" + path_separator_regex + ")";
        static string end_separator_regex = "(?:$|" + path_separator_regex + ")";
        static string capture(string str) { return "(" + str + ")"; }
        static string matchEvaluatorRootWL(Match m)
        {
            return m.Groups[1].Value + "/mnt/" + m.Groups[2].Value.ToLowerInvariant() + m.Groups[3].Value.Replace("\\", "/") + m.Groups[4].Value;
        }
        static string matchEvaluatorPartWL(Match m)
        {
            return m.Groups[1].Value + m.Groups[2].Value.Replace("\\", "/") + m.Groups[3].Value;
        }
        static string convertArgs(string args)
        {
            // Absolute paths
            args = Regex.Replace(args, capture(start_separator_regex) + capture("[a-zA-Z]") + Regex.Escape(":") + capture(valid_abs_path_regex + "?") + capture(end_separator_regex), matchEvaluatorRootWL);
            // Relative paths fragments
            args = Regex.Replace(args, capture(start_separator_regex) + capture(valid_rel_path_regex) + capture(end_separator_regex), matchEvaluatorPartWL);
            return args;
        }

        // ----- PARAMETERS -----
        static string quoteParam(string param)
        {
            return "\"" + param.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
        }
        static int firstNonSpace(string str)
        {
            int i = 0;
            while (i < str.Length && str[i] == ' ') i++;
            return i;
        }
        static int endArg(string str)
        {
            int i = firstNonSpace(str);
            bool quote = false;
            while (i < str.Length)
            {
                if (str[i] == '"')
                    quote = !quote;
                else if (str[i] == ' ' && !quote)
                    break;
                i++;
            }
            return i;
        }
        static int nextArg(string str)
        {
            int ea = endArg(str);
            return firstNonSpace(str.Substring(ea))+ea;
        }
    }
}
