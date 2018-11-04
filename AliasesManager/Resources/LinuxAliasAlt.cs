using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;

namespace TestPipe
{
    class Program
    {
        const string command = [COMMAND];
        const bool load_profile = [LOAD_PROFILE];
        const bool convert_args = [CONVERT_ARGS];
        const bool convert_input = [CONVERT_INPUT];
        const bool convert_output = [CONVERT_OUTPUT];
        static int Main(string[] args)
        {
            //Console.TreatControlCAsInput = true;
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
            };

            string args_str = Environment.CommandLine;
            args_str = args_str.Substring(nextArg(args_str));
            if (convert_args)
                args_str = convertWinLin(args_str);
            if (command != null)
                args_str = command + " " + args_str;

            Process p = new Process();
            p.StartInfo.FileName = "bash.exe";
            p.StartInfo.Arguments = "-c " + quoteParam(args_str);
            if (load_profile)
                p.StartInfo.Arguments = "--login " + p.StartInfo.Arguments;
            p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;

            p.Start();
            Stream consoleError = Console.OpenStandardError();
            Stream consoleOutput = Console.OpenStandardOutput();
            Stream consoleInput = Console.OpenStandardInput();
            StreamReader output = p.StandardOutput;
            StreamReader error = p.StandardError;
            StreamWriter input = p.StandardInput;

            Thread t1 = new Thread(new ParameterizedThreadStart(forward));
            t1.Start(new object[] { output, new StreamWriter(consoleOutput), true });
            Thread t2 = new Thread(new ParameterizedThreadStart(forward));
            t2.Start(new object[] { error, new StreamWriter(consoleError), true });
            Thread t3 = new Thread(new ParameterizedThreadStart(forward));
            t3.Start(new object[] { new StreamReader(consoleInput), input, false });

            p.WaitForExit();
            try { t1.Abort(); } catch { }
            try { t2.Abort(); } catch { }
            try { t3.Abort(); } catch { }

            return p.ExitCode;
        }

        // ----- PATHS CONVERSION -----
        static string filename_regex = "(?:[^" + Regex.Escape("/\\:*?\"<>|") + "]*[a-zA-Z0-9" + Regex.Escape("-_.") + "])";
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
        static string convertWinLin(string args)
        {
            // Absolute paths
            args = Regex.Replace(args, capture(start_separator_regex) + capture("[a-zA-Z]") + Regex.Escape(":") + capture(valid_abs_path_regex + "?") + capture(end_separator_regex), matchEvaluatorRootWL);
            // Relative paths fragments
            args = Regex.Replace(args, capture(start_separator_regex) + capture(valid_rel_path_regex) + capture(end_separator_regex), matchEvaluatorPartWL);
            return args;
        }
        static string matchEvaluatorRootLW(Match m)
        {
            return m.Groups[1].Value + m.Groups[2].Value.ToUpperInvariant() + ":" + m.Groups[3].Value.Replace("/", "\\") + m.Groups[4].Value;
        }
        static string matchEvaluatorPartLW(Match m)
        {
            return m.Groups[1].Value + m.Groups[2].Value.Replace("/", "\\") + m.Groups[3].Value;
        }
        static string convertLinWin(string args)
        {
            // Absolute paths
            args = Regex.Replace(args, capture(start_separator_regex) + Regex.Escape("/mnt/") + capture("[a-z]") + capture(valid_abs_path_regex + "?") + capture(end_separator_regex), matchEvaluatorRootLW);
            // Relative paths fragments
            args = Regex.Replace(args, capture(start_separator_regex) + capture(valid_rel_path_regex) + capture(end_separator_regex), matchEvaluatorPartLW);
            return args;
        }

        // ----- FORWARDING -----
        static void forward(/*StreamReader from, StreamWriter to, bool conv_direction*/object args)
        {
            object[] args_array = (object[])args;
            StreamReader from = (StreamReader)(args_array[0]);
            StreamWriter to = (StreamWriter)(args_array[1]);
            bool conv = (bool)(args_array[2]);
            while (!from.EndOfStream)
            {
                try
                {
                    string str = from.ReadLine();
                    if (str != null)
                    {
                        if (conv)
                            str = convert_output ? convertLinWin(str) : str;
                        else
                            str = convert_input ? convertWinLin(str) : str;
                        to.WriteLine(str); to.Flush();
                    }
                    else
                        break;
                }
                catch { break; }
            }
            try { from.Close(); } catch { }
            try { to.Close(); } catch { }
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
