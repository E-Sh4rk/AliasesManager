﻿using System;
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
                command.Text = la.modified_command == null ? "" : la.modified_command;
                loadProfile.Checked = la.load_profile;
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