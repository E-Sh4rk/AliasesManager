using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
//using System.IO;

namespace TestPipe
{
    class Program
    {
        const string command = [COMMAND];
        const bool load_profile = [LOAD_PROFILE];
        const bool convert_args = [CONVERT_ARGS];
        static void Main(string[] args)
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
            /*p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;*/
            p.Start();
            /*Stream consoleError = Console.OpenStandardError();
            Stream consoleOutput = Console.OpenStandardOutput();
            StreamReader output = p.StandardOutput;
            StreamReader error = p.StandardError;
            output.BaseStream.CopyToAsync(consoleOutput);
            error.BaseStream.CopyToAsync(consoleError);*/
            p.WaitForExit();
        }
        static string matchEvaluator(Match m)
        {
            return m.Value.Substring(0,m.Length-2) + "/mnt/" + m.Value.Substring(m.Length - 2, 1).ToLowerInvariant();
        }
        static string convertArgs(string args)
        {
            args = args.Replace("\\", "/");
            args = Regex.Replace(args, "([^0-9a-zA-Z][a-zA-Z]"+Regex.Escape(":")+")", new MatchEvaluator(matchEvaluator));
            args = Regex.Replace(args, "^([a-zA-Z]" + Regex.Escape(":") + ")", new MatchEvaluator(matchEvaluator));
            return args;
        }
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
