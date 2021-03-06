﻿using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AliasesManager
{
    class Builder
    {
        public static string Escape(string str)
        {
            str = str.Replace("\\", "\\\\");
            str = str.Replace("\"", "\\\"");
            str = str.Replace("\0", "\\0");
            str = str.Replace("\a", "\\a");
            str = str.Replace("\b", "\\b");
            str = str.Replace("\f", "\\f");
            str = str.Replace("\n", "\\n");
            str = str.Replace("\r", "\\r");
            str = str.Replace("\t", "\\t");
            str = str.Replace("\v", "\\v");
            return str;
        }
        public static string Quote(string str)
        {
            return "\"" + Escape(str) +"\"";
        }
        public static string CodeOfStr(string str)
        {
            return str == null ? "null" : Quote(str);
        }
        public static string CodeOfBool(bool b) { return b ? "true" : "false"; }
        public static string MakeLinuxAlias(string output, Config.LinuxAlias la)
        {
            string temp_dir = "temp";
            try
            {
                Directory.CreateDirectory(temp_dir);
                string exe_path = Path.Combine(temp_dir, "alias.exe");
                string manifest_path = Path.Combine(temp_dir, "manifest.xml");

                File.WriteAllText(manifest_path, Properties.Resources.LimitedManifest);
                CompilerParameters parameters = new CompilerParameters()
                {
                    GenerateExecutable = true,
                    TreatWarningsAsErrors = false,
                    CompilerOptions = "/win32manifest:" + manifest_path + " /platform:anycpu /target:exe",
                    IncludeDebugInformation = false,
                    GenerateInMemory = false,
                    OutputAssembly = exe_path
                };
                parameters.ReferencedAssemblies.Add("System.dll");

                string code = Properties.Resources.LinuxAlias;
                if (la.convert_input || la.convert_output)
                    code = Properties.Resources.LinuxAliasAlt;
    
                code = code.Replace("[COMMAND]", CodeOfStr(la.command));
                code = code.Replace("[LOAD_PROFILE]", CodeOfBool(la.load_profile));
                code = code.Replace("[CONVERT_ARGS]", CodeOfBool(la.convert_args));
                code = code.Replace("[CONVERT_INPUT]", CodeOfBool(la.convert_input));
                code = code.Replace("[CONVERT_OUTPUT]", CodeOfBool(la.convert_output));

                CSharpCodeProvider provider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
                CompilerResults compiler = provider.CompileAssemblyFromSource(parameters, code);
                if (compiler.Errors.Count > 0)
                    throw new Exception(compiler.Errors[0].ErrorText);
                File.Move(exe_path, output);
            }
            catch (Exception e) { return e.Message; }
            finally { try { Directory.Delete(temp_dir, true); } catch { } }
            return null;
        }

        public static string MakeWindowsAlias(string output, Config.WindowsAlias wa)
        {
            string temp_dir = "temp";
            try
            {
                Directory.CreateDirectory(temp_dir);
                string exe_path = Path.Combine(temp_dir, "alias.exe");
                string manifest_path = Path.Combine(temp_dir, "manifest.xml");

                if (wa.admin)
                    File.WriteAllText(manifest_path, Properties.Resources.AdminManifest);
                else
                    File.WriteAllText(manifest_path, Properties.Resources.LimitedManifest);
                CompilerParameters parameters = new CompilerParameters()
                {
                    GenerateExecutable = true,
                    TreatWarningsAsErrors = false,
                    CompilerOptions = "/win32manifest:" + manifest_path + " /platform:anycpu",
                    IncludeDebugInformation = false,
                    GenerateInMemory = false,
                    OutputAssembly = exe_path
                };
                if (wa.open_console)
                    parameters.CompilerOptions += " /target:exe";
                else
                    parameters.CompilerOptions += " /target:winexe";
                parameters.ReferencedAssemblies.Add("System.dll");

                string code = Properties.Resources.WindowsAlias;
                code = code.Replace("[COMMAND]", CodeOfStr(wa.command));
                code = code.Replace("[HIDDEN]", CodeOfBool(wa.hidden));
                code = code.Replace("[TARGET_HIDDEN]", CodeOfBool(wa.target_hidden));
                code = code.Replace("[TARGET_OPEN_CONSOLE]", CodeOfBool(wa.target_open_console));
                code = code.Replace("[ARGS_PATTERN]", CodeOfStr(wa.args_pattern));
                code = code.Replace("[WORKING_DIR]", CodeOfStr(wa.working_dir));

                CSharpCodeProvider provider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
                CompilerResults compiler = provider.CompileAssemblyFromSource(parameters, code);
                if (compiler.Errors.Count > 0)
                    throw new Exception(compiler.Errors[0].ErrorText);
                File.Move(exe_path, output);
            }
            catch (Exception e) { return e.Message; }
            finally { try { Directory.Delete(temp_dir, true); } catch { } }
            return null;
        }
    }
}
