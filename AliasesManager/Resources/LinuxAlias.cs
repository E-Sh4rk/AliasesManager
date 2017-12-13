using System;
using System.Diagnostics;
using System.IO;

namespace TestPipe
{
    class Program
    {
        const string change_command = [CHANGE_COMMAND];
        const bool load_profile = [LOAD_PROFILE];
        static void Main(string[] args)
        {
            string args_str = Environment.CommandLine;
            string cmd = change_command;
            if (cmd == null)
                cmd = "\"" + Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\"";
            // TODO : If this filename location contains a space...
            if (args_str.IndexOf(" ") < 0)
                args_str = "";
            else
                args_str = args_str.Substring(args_str.IndexOf(" ") + 1);
            args_str = cmd + " " + args_str;

            Process p = new Process();
            p.StartInfo.FileName = "bash.exe";
            p.StartInfo.Arguments = "-c " + quoteParam(args_str);
            if (load_profile)
                p.StartInfo.Arguments = "--login " + p.StartInfo.Arguments;
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
    }
}
