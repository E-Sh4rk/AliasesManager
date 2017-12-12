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
            string args_str = "";

            foreach (string arg in args)
            {
                if (!String.IsNullOrEmpty(args_str))
                    args_str += " ";
                args_str += quoteParam(arg);
            }
            if (args_pattern != null)
                args_str = Environment.ExpandEnvironmentVariables(args_pattern.Replace("%ARGS%", args_str).Replace("%QARGS%", quoteParam(args_str)));

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
        static string quoteParam(string param)
        {
            return "\"" + param.Replace("\"", "\"\"\"") + "\"";
        }
    }
}
