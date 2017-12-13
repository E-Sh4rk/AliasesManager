namespace AliasesManager
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.windowsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linuxListView = new System.Windows.Forms.ListView();
            this.alias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.command = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.profile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.reloadPath = new System.Windows.Forms.Button();
            this.savePathUser = new System.Windows.Forms.Button();
            this.addAliasesLocation = new System.Windows.Forms.Button();
            this.pathVariable = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.linuxCompleteContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linuxContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsCompleteContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.convert_args = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.linuxCompleteContextStrip.SuspendLayout();
            this.linuxContextStrip.SuspendLayout();
            this.windowsContextStrip.SuspendLayout();
            this.windowsCompleteContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 384);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.windowsListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Windows Aliases";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // windowsListView
            // 
            this.windowsListView.CheckBoxes = true;
            this.windowsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.windowsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsListView.FullRowSelect = true;
            this.windowsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.windowsListView.Location = new System.Drawing.Point(3, 3);
            this.windowsListView.MultiSelect = false;
            this.windowsListView.Name = "windowsListView";
            this.windowsListView.Size = new System.Drawing.Size(583, 352);
            this.windowsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.windowsListView.TabIndex = 0;
            this.windowsListView.UseCompatibleStateImageBehavior = false;
            this.windowsListView.View = System.Windows.Forms.View.Details;
            this.windowsListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.windowsListView_ItemCheck);
            this.windowsListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.windowsListView_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Alias";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Command";
            this.columnHeader2.Width = 92;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Arguments";
            this.columnHeader3.Width = 92;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Working dir";
            this.columnHeader4.Width = 83;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Hidden";
            this.columnHeader5.Width = 49;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "CNW";
            this.columnHeader6.Width = 45;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Console";
            this.columnHeader7.Width = 52;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Admin";
            this.columnHeader8.Width = 43;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.linuxListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Linux Aliases";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linuxListView
            // 
            this.linuxListView.CheckBoxes = true;
            this.linuxListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.alias,
            this.command,
            this.profile,
            this.convert_args});
            this.linuxListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linuxListView.FullRowSelect = true;
            this.linuxListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.linuxListView.Location = new System.Drawing.Point(3, 3);
            this.linuxListView.MultiSelect = false;
            this.linuxListView.Name = "linuxListView";
            this.linuxListView.Size = new System.Drawing.Size(583, 352);
            this.linuxListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.linuxListView.TabIndex = 1;
            this.linuxListView.UseCompatibleStateImageBehavior = false;
            this.linuxListView.View = System.Windows.Forms.View.Details;
            this.linuxListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.linuxListView_ItemCheck);
            this.linuxListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.linuxListView_MouseUp);
            // 
            // alias
            // 
            this.alias.Text = "Alias";
            this.alias.Width = 181;
            // 
            // command
            // 
            this.command.Text = "Command (if different)";
            this.command.Width = 197;
            // 
            // profile
            // 
            this.profile.Text = "Load Profile";
            this.profile.Width = 73;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.reloadPath);
            this.tabPage3.Controls.Add(this.savePathUser);
            this.tabPage3.Controls.Add(this.addAliasesLocation);
            this.tabPage3.Controls.Add(this.pathVariable);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(589, 358);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PATH Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PATH environment variable of the current user :";
            // 
            // reloadPath
            // 
            this.reloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadPath.Location = new System.Drawing.Point(311, 298);
            this.reloadPath.Name = "reloadPath";
            this.reloadPath.Size = new System.Drawing.Size(122, 23);
            this.reloadPath.TabIndex = 4;
            this.reloadPath.Text = "Reload";
            this.reloadPath.UseVisualStyleBackColor = true;
            this.reloadPath.Click += new System.EventHandler(this.reloadPath_Click);
            // 
            // savePathUser
            // 
            this.savePathUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savePathUser.Location = new System.Drawing.Point(439, 298);
            this.savePathUser.Name = "savePathUser";
            this.savePathUser.Size = new System.Drawing.Size(119, 23);
            this.savePathUser.TabIndex = 2;
            this.savePathUser.Text = "Save PATH";
            this.savePathUser.UseVisualStyleBackColor = true;
            this.savePathUser.Click += new System.EventHandler(this.savePathUser_Click);
            // 
            // addAliasesLocation
            // 
            this.addAliasesLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAliasesLocation.Location = new System.Drawing.Point(31, 298);
            this.addAliasesLocation.Name = "addAliasesLocation";
            this.addAliasesLocation.Size = new System.Drawing.Size(116, 23);
            this.addAliasesLocation.TabIndex = 1;
            this.addAliasesLocation.Text = "Add aliases location";
            this.addAliasesLocation.UseVisualStyleBackColor = true;
            this.addAliasesLocation.Click += new System.EventHandler(this.addAliasesLocation_Click);
            // 
            // pathVariable
            // 
            this.pathVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathVariable.Location = new System.Drawing.Point(31, 48);
            this.pathVariable.Multiline = true;
            this.pathVariable.Name = "pathVariable";
            this.pathVariable.Size = new System.Drawing.Size(527, 210);
            this.pathVariable.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(589, 358);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Aliases Manager 1.1\r\nCredits: Mickael Laurent\r\nhttps://github.com/E-Sh4rk/Aliases" +
    "Manager";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linuxCompleteContextStrip
            // 
            this.linuxCompleteContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.linuxCompleteContextStrip.Name = "linuxCompleteContextStrip";
            this.linuxCompleteContextStrip.Size = new System.Drawing.Size(108, 70);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // linuxContextStrip
            // 
            this.linuxContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.linuxContextStrip.Name = "linuxContextStrip";
            this.linuxContextStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // windowsContextStrip
            // 
            this.windowsContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.windowsContextStrip.Name = "linuxContextStrip";
            this.windowsContextStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem1.Text = "New";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem2_Click);
            // 
            // windowsCompleteContextStrip
            // 
            this.windowsCompleteContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.windowsCompleteContextStrip.Name = "linuxCompleteContextStrip";
            this.windowsCompleteContextStrip.Size = new System.Drawing.Size(108, 70);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem2.Text = "New";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.newToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem3.Text = "Edit";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.editToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem4.Text = "Delete";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.deleteToolStripMenuItem2_Click);
            // 
            // convert_args
            // 
            this.convert_args.Text = "Convert args";
            this.convert_args.Width = 73;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 384);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Aliases Manager";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.linuxCompleteContextStrip.ResumeLayout(false);
            this.linuxContextStrip.ResumeLayout(false);
            this.windowsContextStrip.ResumeLayout(false);
            this.windowsCompleteContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox pathVariable;
        private System.Windows.Forms.Button addAliasesLocation;
        private System.Windows.Forms.Button savePathUser;
        private System.Windows.Forms.Button reloadPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip linuxCompleteContextStrip;
        private System.Windows.Forms.ContextMenuStrip linuxContextStrip;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ListView windowsListView;
        private System.Windows.Forms.ListView linuxListView;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader alias;
        private System.Windows.Forms.ColumnHeader command;
        private System.Windows.Forms.ColumnHeader profile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ContextMenuStrip windowsContextStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip windowsCompleteContextStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader convert_args;
    }
}

