using System;
using System.Diagnostics;
//using System.IO;

namespace TestPipe
{
    class Program
    {
        const string command = [COMMAND];
        const bool hidden = [HIDDEN];
        const bool create_no_window = [CREATE_NO_WINDOW];
        const string args_pattern = [ARGS_PATTERN];
        const string working_dir = [WORKING_DIR];
        static void Main(string[] args)
        {
            string args_str = Environment.CommandLine;
            args_str = args_str.Substring(nextArg(args_str));
            args_str = Environment.ExpandEnvironmentVariables(args_pattern.Replace("%ARGS%", args_str));

            Process p = new Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(command);
            p.StartInfo.Arguments = args_str;
            if (working_dir != null)
                p.StartInfo.WorkingDirectory = Environment.ExpandEnvironmentVariables(working_dir);
            p.StartInfo.CreateNoWindow = create_no_window;
            p.StartInfo.UseShellExecute = false;
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
        static int nextArg(string str)
        {
            int i = firstNonSpace(str);
            bool quote = false;
            while (i < str.Length)
            {
                if (str[i] == '"')
                    quote = !quote;
                else if (str[i] == ' ' && !quote)
                {
                    i++;
                    break;
                }
                i++;
            }
            return i;
        }
    }
}
