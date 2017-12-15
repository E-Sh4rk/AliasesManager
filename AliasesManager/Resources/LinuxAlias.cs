using System;
using System.Diagnostics;
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
                args_str = args_str.Replace("\\", "/");
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
