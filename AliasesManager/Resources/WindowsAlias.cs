using System;
using System.Diagnostics;

namespace TestPipe
{
    class Program
    {
        const string command = [COMMAND];
        const bool hidden = [HIDDEN];
        const bool toc = [TARGET_OPEN_CONSOLE];
        const string args_pattern = [ARGS_PATTERN];
        const string working_dir = [WORKING_DIR];
        static void Main(string[] args)
        {
            //Console.TreatControlCAsInput = true;
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
            };

            string cmd = command;
            string args_str = "";
            if (args_pattern != null)
            {
                args_str = Environment.CommandLine;
                args_str = args_str.Substring(nextArg(args_str));
                args_str = Environment.ExpandEnvironmentVariables(args_pattern.Replace("%ARGS%", args_str));
                if (cmd == null)
                {
                    cmd = args_str.Substring(0, endArg(args_str));
                    args_str = args_str.Substring(nextArg(args_str));
                }
            }

            Process p = new Process();
            if (cmd != null)
                p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(cmd.Replace("\"", ""));
            else
                return;
            p.StartInfo.Arguments = args_str;
            if (working_dir != null)
                p.StartInfo.WorkingDirectory = Environment.ExpandEnvironmentVariables(working_dir.Replace("\"", ""));
            else
                p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            p.StartInfo.CreateNoWindow = !toc && !hidden;
            p.StartInfo.UseShellExecute = hidden;
            if (hidden)
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
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
            return firstNonSpace(str.Substring(ea)) + ea;
        }
    }
}
