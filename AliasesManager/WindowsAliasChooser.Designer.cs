namespace AliasesManager
{
    partial class WindowsAliasChooser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.command = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.hidden = new System.Windows.Forms.CheckBox();
            this.createNoWindow = new System.Windows.Forms.CheckBox();
            this.console = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.args = new System.Windows.Forms.TextBox();
            this.workingDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.admin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.Location = new System.Drawing.Point(264, 252);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 3;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(183, 252);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filename";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Alias";
            // 
            // command
            // 
            this.command.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.command.Location = new System.Drawing.Point(92, 49);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(247, 20);
            this.command.TabIndex = 8;
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Location = new System.Drawing.Point(92, 23);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(247, 20);
            this.name.TabIndex = 7;
            // 
            // hidden
            // 
            this.hidden.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hidden.AutoSize = true;
            this.hidden.Location = new System.Drawing.Point(93, 127);
            this.hidden.Name = "hidden";
            this.hidden.Size = new System.Drawing.Size(60, 17);
            this.hidden.TabIndex = 11;
            this.hidden.Text = "Hidden";
            this.hidden.UseVisualStyleBackColor = true;
            // 
            // createNoWindow
            // 
            this.createNoWindow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.createNoWindow.AutoSize = true;
            this.createNoWindow.Location = new System.Drawing.Point(159, 127);
            this.createNoWindow.Name = "createNoWindow";
            this.createNoWindow.Size = new System.Drawing.Size(110, 17);
            this.createNoWindow.TabIndex = 12;
            this.createNoWindow.Text = "CreateNoWindow";
            this.createNoWindow.UseVisualStyleBackColor = true;
            // 
            // console
            // 
            this.console.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.console.AutoSize = true;
            this.console.Checked = true;
            this.console.CheckState = System.Windows.Forms.CheckState.Checked;
            this.console.Location = new System.Drawing.Point(275, 127);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(64, 17);
            this.console.TabIndex = 13;
            this.console.Text = "Console";
            this.console.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Arguments";
            // 
            // args
            // 
            this.args.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.args.Location = new System.Drawing.Point(92, 75);
            this.args.Name = "args";
            this.args.Size = new System.Drawing.Size(247, 20);
            this.args.TabIndex = 14;
            // 
            // workingDir
            // 
            this.workingDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.workingDir.Location = new System.Drawing.Point(92, 101);
            this.workingDir.Name = "workingDir";
            this.workingDir.Size = new System.Drawing.Size(247, 20);
            this.workingDir.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Working dir";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 52);
            this.label5.TabIndex = 18;
            this.label5.Text = "Alias must not contains any / or \\ or \".\r\nYou can use environment variables\r\n(%AR" +
    "GS% is also available for arguments).\r\nFilename empty = Determined by the args";
            // 
            // admin
            // 
            this.admin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.admin.AutoSize = true;
            this.admin.Location = new System.Drawing.Point(93, 150);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(91, 17);
            this.admin.TabIndex = 19;
            this.admin.Text = "Run as admin";
            this.admin.UseVisualStyleBackColor = true;
            // 
            // WindowsAliasChooser
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(351, 287);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.workingDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.args);
            this.Controls.Add(this.console);
            this.Controls.Add(this.createNoWindow);
            this.Controls.Add(this.hidden);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.command);
            this.Controls.Add(this.name);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Name = "WindowsAliasChooser";
            this.Text = "WindowsAliasChooser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox command;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.CheckBox hidden;
        private System.Windows.Forms.CheckBox createNoWindow;
        private System.Windows.Forms.CheckBox console;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox args;
        private System.Windows.Forms.TextBox workingDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox admin;
    }
}