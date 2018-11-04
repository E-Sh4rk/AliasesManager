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
    public partial class LinuxAliasChooser : Form
    {
        public LinuxAliasChooser()
        {
            InitializeComponent();
        }

        public LinuxAliasChooser(Config.LinuxAlias la)
        {
            InitializeComponent();
            if (la != null)
            {
                name.Text = la.name;
                command.Text = la.command == null ? "" : la.command;
                loadProfile.Checked = la.load_profile;
                convertArgs.Checked = la.convert_args;
                convertInput.Checked = la.convert_input;
                convertOutput.Checked = la.convert_output;
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
        public bool LoadProfile
        {
            get { return loadProfile.Checked; }
        }
        public bool ConvertArgs
        {
            get { return convertArgs.Checked; }
        }
        public bool ConvertInput
        {
            get { return convertInput.Checked; }
        }
        public bool ConvertOutput
        {
            get { return convertOutput.Checked; }
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
