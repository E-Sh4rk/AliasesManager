using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliasesManager
{
    public class Config
    {
        public class WindowsAlias
        {
            public int ID;
            public bool enabled;
            public string name;
            public bool hidden;
            public bool target_hidden;
            public string command;
            public string args_pattern;
            public string working_dir;
            public bool open_console;
            public bool target_open_console;
            public bool admin;
        }
        public class LinuxAlias
        {
            public int ID;
            public bool enabled;
            public string name;
            public bool load_profile;
            public string command;
            public bool convert_args;
        }
        public List<WindowsAlias> windows_aliases = new List<WindowsAlias>();
        public List<LinuxAlias> linux_aliases = new List<LinuxAlias>();
        public int nextID = 1;
        public int NextID()
        {
            nextID++;
            return nextID - 1;
        }
        public WindowsAlias GetWindowsAlias(int ID)
        {
            foreach (WindowsAlias wa in windows_aliases)
                if (wa.ID == ID)
                    return wa;
            return null;
        }
        public LinuxAlias GetLinuxAlias(int ID)
        {
            foreach (LinuxAlias la in linux_aliases)
                if (la.ID == ID)
                    return la;
            return null;
        }
        public void DeleteWindowsAlias(int ID)
        {
            int i = 0;
            while (i < windows_aliases.Count)
            {
                if (windows_aliases[i].ID == ID)
                    windows_aliases.RemoveAt(i);
                else
                    i++;
            }
        }
        public void DeleteLinuxAlias(int ID)
        {
            int i = 0;
            while (i < linux_aliases.Count)
            {
                if (linux_aliases[i].ID == ID)
                    linux_aliases.RemoveAt(i);
                else
                    i++;
            }
        }
    }
}
