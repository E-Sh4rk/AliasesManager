namespace AliasesManager
{
    partial class LinuxAliasChooser
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
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.command = new System.Windows.Forms.TextBox();
            this.loadProfile = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.convertArgs = new System.Windows.Forms.CheckBox();
            this.convertInput = new System.Windows.Forms.CheckBox();
            this.convertOutput = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(187, 228);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.Location = new System.Drawing.Point(268, 228);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Location = new System.Drawing.Point(86, 40);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(257, 20);
            this.name.TabIndex = 2;
            // 
            // command
            // 
            this.command.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.command.Location = new System.Drawing.Point(86, 66);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(257, 20);
            this.command.TabIndex = 3;
            // 
            // loadProfile
            // 
            this.loadProfile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.loadProfile.AutoSize = true;
            this.loadProfile.Checked = true;
            this.loadProfile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadProfile.Location = new System.Drawing.Point(86, 139);
            this.loadProfile.Name = "loadProfile";
            this.loadProfile.Size = new System.Drawing.Size(121, 17);
            this.loadProfile.TabIndex = 4;
            this.loadProfile.Text = "Load profile (.profile)";
            this.loadProfile.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alias";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Command";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Alias must not contains any / or \\ or \".\r\nCommand empty = Determined by the args";
            // 
            // convertArgs
            // 
            this.convertArgs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.convertArgs.AutoSize = true;
            this.convertArgs.Location = new System.Drawing.Point(213, 139);
            this.convertArgs.Name = "convertArgs";
            this.convertArgs.Size = new System.Drawing.Size(126, 17);
            this.convertArgs.TabIndex = 8;
            this.convertArgs.Text = "Convert paths in args";
            this.convertArgs.UseVisualStyleBackColor = true;
            // 
            // convertInput
            // 
            this.convertInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.convertInput.AutoSize = true;
            this.convertInput.Location = new System.Drawing.Point(86, 162);
            this.convertInput.Name = "convertInput";
            this.convertInput.Size = new System.Drawing.Size(197, 17);
            this.convertInput.TabIndex = 9;
            this.convertInput.Text = "Convert paths in input (experimental)";
            this.convertInput.UseVisualStyleBackColor = true;
            // 
            // convertOutput
            // 
            this.convertOutput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.convertOutput.AutoSize = true;
            this.convertOutput.Location = new System.Drawing.Point(86, 185);
            this.convertOutput.Name = "convertOutput";
            this.convertOutput.Size = new System.Drawing.Size(204, 17);
            this.convertOutput.TabIndex = 10;
            this.convertOutput.Text = "Convert paths in output (experimental)";
            this.convertOutput.UseVisualStyleBackColor = true;
            // 
            // LinuxAliasChooser
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(355, 263);
            this.Controls.Add(this.convertOutput);
            this.Controls.Add(this.convertInput);
            this.Controls.Add(this.convertArgs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadProfile);
            this.Controls.Add(this.command);
            this.Controls.Add(this.name);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Name = "LinuxAliasChooser";
            this.Text = "LinuxAliasChooser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox command;
        private System.Windows.Forms.CheckBox loadProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox convertArgs;
        private System.Windows.Forms.CheckBox convertInput;
        private System.Windows.Forms.CheckBox convertOutput;
    }
}