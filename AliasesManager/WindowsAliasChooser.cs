using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AliasesManager
{
    public partial class WindowsAliasChooser : Form
    {
        public WindowsAliasChooser()
        {
            InitializeComponent();
        }

        public WindowsAliasChooser(Config.WindowsAlias wa)
        {
            InitializeComponent();
            if (wa != null)
            {
                name.Text = wa.name;
                command.Text = wa.command == null ? "" : wa.command;
                hidden.Checked = wa.hidden;
                console.Checked = wa.open_console;
                targetConsole.Checked = wa.target_open_console;
                admin.Checked = wa.admin;
                args.Text = wa.args_pattern == null ? "" : wa.args_pattern;
                workingDir.Text = wa.working_dir == null ? "" : wa.working_dir;
            }
        }

        public string Alias
        {
            get { return name.Text; }
        }
        public string Command
        {
            get { return String.IsNullOrEmpty(command.Text) ? null : command.Text; }
        }
        public bool Hidden
        {
            get { return hidden.Checked; }
        }
        public bool Console
        {
            get { return console.Checked; }
        }
        public bool TargetConsole
        {
            get { return targetConsole.Checked; }
        }
        public bool Admin
        {
            get { return admin.Checked; }
        }
        public string Args
        {
            get { return String.IsNullOrEmpty(args.Text) ? null : args.Text; }
        }
        public string WorkingDir
        {
            get { return String.IsNullOrEmpty(workingDir.Text) ? null : workingDir.Text; }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
