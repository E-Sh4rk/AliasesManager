﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AliasesManager
{
    public partial class Form1 : Form
    {
        string data_location = null;
        string aliases_location = null;
        string config_file = null;
        Config cfg = null;

        public Form1()
        {
            InitializeComponent();
            data_location = Path.Combine(Environment.CurrentDirectory, "Data");
            aliases_location = Path.Combine(data_location, "Aliases");
            config_file = Path.Combine(data_location, "config.xml");

            try
            {
                Directory.CreateDirectory(data_location);
                Directory.CreateDirectory(aliases_location);
            }
            catch { }

            _reloadPath();
            _loadConfig();
        }

        private void _updateLists()
        {
            windowsListView.Items.Clear();
            linuxListView.Items.Clear();

            foreach (Config.WindowsAlias wa in cfg.windows_aliases)
            {
                ListViewItem lvi = new ListViewItem(new string[] { wa.name, wa.command, wa.args_pattern, wa.working_dir,
                    wa.hidden.ToString(), wa.target_hidden.ToString(), wa.open_console.ToString(), wa.target_open_console.ToString(), wa.admin.ToString() });
                lvi.Tag = wa.ID;
                lvi.Checked = wa.enabled;
                windowsListView.Items.Add(lvi);
            }

            foreach (Config.LinuxAlias la in cfg.linux_aliases)
            {
                ListViewItem lvi = new ListViewItem(new string[] { la.name, la.command, la.load_profile.ToString(), la.convert_args.ToString(), la.convert_input.ToString(), la.convert_output.ToString() });
                lvi.Tag = la.ID;
                lvi.Checked = la.enabled;
                linuxListView.Items.Add(lvi);
            }
        }

        private string _normalizeAliasName(string name)
        {
            name = name.ToLowerInvariant();
            if (String.Equals(Path.GetExtension(name), ".exe", StringComparison.OrdinalIgnoreCase))
                return name;
            return name + ".exe";
        }

        private void _updateAliases()
        {
            // Deleting disabled/unknown aliases
            HashSet<string> hs = new HashSet<string>();
            foreach (Config.WindowsAlias wa in cfg.windows_aliases)
            {
                if (wa.enabled)
                    hs.Add(_normalizeAliasName(wa.name));
            }
            foreach (Config.LinuxAlias la in cfg.linux_aliases)
            {
                if (la.enabled)
                    hs.Add(_normalizeAliasName(la.name));
            }
            string[] files = Directory.GetFiles(aliases_location);
            foreach (string file in files)
            {
                if (!hs.Contains(_normalizeAliasName(Path.GetFileName(file))))
                {
                    try { File.Delete(file); } catch { }
                }
            }

            // Creating new aliases
            foreach (Config.WindowsAlias wa in cfg.windows_aliases)
            {
                if (!wa.enabled)
                    continue;
                string filename = Path.Combine(aliases_location, _normalizeAliasName(wa.name));
                if (File.Exists(filename))
                    continue;
                string res = Builder.MakeWindowsAlias(filename, wa);
                if (res != null)
                    MessageBox.Show(this, "Unable to create the windows alias " + wa.name + ".\n" + res, "Error");
            }
            foreach (Config.LinuxAlias la in cfg.linux_aliases)
            {
                if (!la.enabled)
                    continue;
                string filename = Path.Combine(aliases_location, _normalizeAliasName(la.name));
                if (File.Exists(filename))
                    continue;
                string res = Builder.MakeLinuxAlias(filename, la);
                if (res != null)
                    MessageBox.Show(this, "Unable to create the linux alias " + la.name + ".\n" + res, "Error");
            }
        }

        private void _reloadPath()
        {
            pathVariable.Text = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
        }

        private void _loadConfig()
        {
            try
            {
                using (TextReader reader = new StreamReader(config_file))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Config));
                    cfg = (Config)xml.Deserialize(reader);
                }
            }
            catch
            {
                cfg = new Config();
            }
            _saveConfig();
            _updateLists();
            _updateAliases();
        }

        private void _saveConfig()
        {
            try
            {
                using (TextWriter writer = new StreamWriter(config_file))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Config));
                    xml.Serialize(writer, cfg);
                }
            }
            catch { MessageBox.Show(this, "An error has occured while trying to save configuration...", "Error"); }
        }

        // ----- PATH handlers -----

        private void reloadPath_Click(object sender, EventArgs e) { _reloadPath(); }

        private void addAliasesLocation_Click(object sender, EventArgs e)
        {
            pathVariable.AppendText(";" + aliases_location);
        }

        private void savePathUser_Click(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("PATH", pathVariable.Text, EnvironmentVariableTarget.User);
        }

        // ----- Linux ListBox handlers -----

        private void linuxListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (linuxListView.FocusedItem != null && linuxListView.FocusedItem.Bounds.Contains(e.Location))
                    linuxCompleteContextStrip.Show(Cursor.Position);
                else
                    linuxContextStrip.Show(Cursor.Position);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinuxAliasChooser lac = new LinuxAliasChooser();
            if (lac.ShowDialog(this) == DialogResult.OK)
            {
                Config.LinuxAlias la = new Config.LinuxAlias();
                la.enabled = false;
                la.ID = cfg.NextID();
                la.name = lac.Alias;
                la.command = lac.Command;
                la.load_profile = lac.LoadProfile;
                la.convert_args = lac.ConvertArgs;
                la.convert_input = lac.ConvertInput;
                la.convert_output = lac.ConvertOutput;
                cfg.linux_aliases.Add(la);

                _saveConfig();
                _updateLists();
                _updateAliases();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (linuxListView.FocusedItem == null)
                return;
            Config.LinuxAlias la = cfg.GetLinuxAlias((int)linuxListView.FocusedItem.Tag);
            if (la == null)
                return;
            LinuxAliasChooser lac = new LinuxAliasChooser(la);
            if (lac.ShowDialog(this) == DialogResult.OK)
            {
                // We must delete the alias involved, however it will not be updated
                string filename = Path.Combine(aliases_location, _normalizeAliasName(la.name));
                try { File.Delete(filename); } catch { }

                la.name = lac.Alias;
                la.command = lac.Command;
                la.load_profile = lac.LoadProfile;
                la.convert_args = lac.ConvertArgs;
                la.convert_input = lac.ConvertInput;
                la.convert_output = lac.ConvertOutput;

                // We must delete the alias involved, however it will not be updated
                filename = Path.Combine(aliases_location, _normalizeAliasName(la.name));
                try { File.Delete(filename); } catch { }

                _saveConfig();
                _updateLists();
                _updateAliases();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (linuxListView.FocusedItem == null)
                return;
            Config.LinuxAlias la = cfg.GetLinuxAlias((int)linuxListView.FocusedItem.Tag);
            if (la == null)
                return;
            cfg.DeleteLinuxAlias(la.ID);

            // We must delete the alias involved, however it will not be updated
            string filename = Path.Combine(aliases_location, _normalizeAliasName(la.name));
            try { File.Delete(filename); } catch { }

            _saveConfig();
            _updateLists();
            _updateAliases();
        }

        private void linuxListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Indeterminate || e.NewValue == CheckState.Indeterminate)
                return;

            Config.LinuxAlias la = cfg.GetLinuxAlias((int)linuxListView.Items[e.Index].Tag);
            if (la != null && la.enabled != (e.NewValue == CheckState.Checked))
            {
                la.enabled = (e.NewValue == CheckState.Checked);

                if (e.NewValue == CheckState.Unchecked)
                {
                    // We must delete the alias involved, however it will not be updated
                    string filename = Path.Combine(aliases_location, _normalizeAliasName(la.name));
                    try { File.Delete(filename); } catch { }
                }

                _saveConfig();
                _updateAliases();
            }
        }

        // ----- Windows ListBox handlers -----

        private void windowsListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (windowsListView.FocusedItem != null && windowsListView.FocusedItem.Bounds.Contains(e.Location))
                    windowsCompleteContextStrip.Show(Cursor.Position);
                else
                    windowsContextStrip.Show(Cursor.Position);
            }
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            WindowsAliasChooser wac = new WindowsAliasChooser();
            if (wac.ShowDialog(this) == DialogResult.OK)
            {
                Config.WindowsAlias wa = new Config.WindowsAlias();
                wa.enabled = false;
                wa.ID = cfg.NextID();
                wa.name = wac.Alias;
                wa.command = wac.Command;
                wa.args_pattern = wac.Args;
                wa.working_dir = wac.WorkingDir;
                wa.hidden = wac.Hidden;
                wa.target_hidden = wac.TargetHidden;
                wa.open_console = wac.Console;
                wa.target_open_console = wac.TargetConsole;
                wa.admin = wac.Admin;
                cfg.windows_aliases.Add(wa);

                _saveConfig();
                _updateLists();
                _updateAliases();
            }
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (windowsListView.FocusedItem == null)
                return;
            Config.WindowsAlias wa = cfg.GetWindowsAlias((int)windowsListView.FocusedItem.Tag);
            if (wa == null)
                return;
            WindowsAliasChooser wac = new WindowsAliasChooser(wa);
            if (wac.ShowDialog(this) == DialogResult.OK)
            {
                // We must delete the alias involved, however it will not be updated
                string filename = Path.Combine(aliases_location, _normalizeAliasName(wa.name));
                try { File.Delete(filename); } catch { }

                wa.name = wac.Alias;
                wa.command = wac.Command;
                wa.args_pattern = wac.Args;
                wa.working_dir = wac.WorkingDir;
                wa.hidden = wac.Hidden;
                wa.target_hidden = wac.TargetHidden;
                wa.open_console = wac.Console;
                wa.target_open_console = wac.TargetConsole;
                wa.admin = wac.Admin;

                // We must delete the alias involved, however it will not be updated
                filename = Path.Combine(aliases_location, _normalizeAliasName(wa.name));
                try { File.Delete(filename); } catch { }

                _saveConfig();
                _updateLists();
                _updateAliases();
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (windowsListView.FocusedItem == null)
                return;
            Config.WindowsAlias wa = cfg.GetWindowsAlias((int)windowsListView.FocusedItem.Tag);
            if (wa == null)
                return;
            cfg.DeleteWindowsAlias(wa.ID);

            // We must delete the alias involved, however it will not be updated
            string filename = Path.Combine(aliases_location, _normalizeAliasName(wa.name));
            try { File.Delete(filename); } catch { }

            _saveConfig();
            _updateLists();
            _updateAliases();
        }

        private void windowsListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Indeterminate || e.NewValue == CheckState.Indeterminate)
                return;

            Config.WindowsAlias wa = cfg.GetWindowsAlias((int)windowsListView.Items[e.Index].Tag);
            if (wa != null && wa.enabled != (e.NewValue == CheckState.Checked))
            {
                wa.enabled = (e.NewValue == CheckState.Checked);

                if (e.NewValue == CheckState.Unchecked)
                {
                    // We must delete the alias involved, however it will not be updated
                    string filename = Path.Combine(aliases_location, _normalizeAliasName(wa.name));
                    try { File.Delete(filename); } catch { }
                }

                _saveConfig();
                _updateAliases();
            }
        }

        // ----- About tab -----

        private void _reconstructAliases()
        {
            try
            {
                Directory.Delete(aliases_location, true);
                Directory.CreateDirectory(aliases_location);
            }
            catch { MessageBox.Show(this, "An error has occured. Maybe an alias is currently in use.", "Error"); }
            _updateAliases();
        }

        private void reconstructAliases_Click(object sender, EventArgs e) { _reconstructAliases(); }

        private void resetData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(config_file))
                        File.Delete(config_file);
                    _loadConfig();
                    _reconstructAliases();
                }
                catch { MessageBox.Show(this, "An error has occured.", "Error"); }
            }
        }
    }
}
