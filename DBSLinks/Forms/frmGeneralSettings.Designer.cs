namespace Links.Forms
{
    partial class frmGeneralSettings
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
            this.lblApplicationBehaviour = new System.Windows.Forms.Label();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.lblStartupOptions = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGeneralSettingsText = new System.Windows.Forms.Label();
            this.lblGeneralSettingsTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReloadLocalDatabase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkWaitForNetwork = new System.Windows.Forms.CheckBox();
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.lblWaitForNetworkMinutes1 = new System.Windows.Forms.Label();
            this.cmbWaitForNetwork = new System.Windows.Forms.ComboBox();
            this.grpSeparator2 = new System.Windows.Forms.GroupBox();
            this.grpSeparator1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCheckForUpdates = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblApplicationBehaviour
            // 
            this.lblApplicationBehaviour.AutoSize = true;
            this.lblApplicationBehaviour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationBehaviour.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationBehaviour.Location = new System.Drawing.Point(19, 95);
            this.lblApplicationBehaviour.Name = "lblApplicationBehaviour";
            this.lblApplicationBehaviour.Size = new System.Drawing.Size(131, 13);
            this.lblApplicationBehaviour.TabIndex = 3;
            this.lblApplicationBehaviour.Text = "Application Behaviour";
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Checked = true;
            this.chkTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTopMost.Location = new System.Drawing.Point(36, 129);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(165, 17);
            this.chkTopMost.TabIndex = 0;
            this.chkTopMost.Text = "The Links window is top most";
            this.chkTopMost.UseVisualStyleBackColor = true;
            // 
            // lblStartupOptions
            // 
            this.lblStartupOptions.AutoSize = true;
            this.lblStartupOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartupOptions.ForeColor = System.Drawing.Color.Black;
            this.lblStartupOptions.Location = new System.Drawing.Point(19, 18);
            this.lblStartupOptions.Name = "lblStartupOptions";
            this.lblStartupOptions.Size = new System.Drawing.Size(95, 13);
            this.lblStartupOptions.TabIndex = 5;
            this.lblStartupOptions.Text = "Startup Options";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblGeneralSettingsText);
            this.panel1.Controls.Add(this.lblGeneralSettingsTitle);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 50);
            this.panel1.TabIndex = 1;
            // 
            // lblGeneralSettingsText
            // 
            this.lblGeneralSettingsText.AutoSize = true;
            this.lblGeneralSettingsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneralSettingsText.ForeColor = System.Drawing.Color.Black;
            this.lblGeneralSettingsText.Location = new System.Drawing.Point(114, 17);
            this.lblGeneralSettingsText.Name = "lblGeneralSettingsText";
            this.lblGeneralSettingsText.Size = new System.Drawing.Size(209, 13);
            this.lblGeneralSettingsText.TabIndex = 7;
            this.lblGeneralSettingsText.Text = "Set up all the basics you need to use Links";
            // 
            // lblGeneralSettingsTitle
            // 
            this.lblGeneralSettingsTitle.AutoSize = true;
            this.lblGeneralSettingsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneralSettingsTitle.ForeColor = System.Drawing.Color.Black;
            this.lblGeneralSettingsTitle.Location = new System.Drawing.Point(11, 16);
            this.lblGeneralSettingsTitle.Name = "lblGeneralSettingsTitle";
            this.lblGeneralSettingsTitle.Size = new System.Drawing.Size(103, 13);
            this.lblGeneralSettingsTitle.TabIndex = 6;
            this.lblGeneralSettingsTitle.Text = "General settings:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCheckForUpdates);
            this.panel2.Controls.Add(this.btnReloadLocalDatabase);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chkWaitForNetwork);
            this.panel2.Controls.Add(this.chkStartup);
            this.panel2.Controls.Add(this.lblWaitForNetworkMinutes1);
            this.panel2.Controls.Add(this.cmbWaitForNetwork);
            this.panel2.Controls.Add(this.grpSeparator2);
            this.panel2.Controls.Add(this.grpSeparator1);
            this.panel2.Controls.Add(this.lblStartupOptions);
            this.panel2.Controls.Add(this.chkTopMost);
            this.panel2.Controls.Add(this.lblApplicationBehaviour);
            this.panel2.Location = new System.Drawing.Point(6, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 230);
            this.panel2.TabIndex = 2;
            // 
            // btnReloadLocalDatabase
            // 
            this.btnReloadLocalDatabase.Location = new System.Drawing.Point(33, 185);
            this.btnReloadLocalDatabase.Name = "btnReloadLocalDatabase";
            this.btnReloadLocalDatabase.Size = new System.Drawing.Size(136, 24);
            this.btnReloadLocalDatabase.TabIndex = 8;
            this.btnReloadLocalDatabase.Text = "Reload Local Database";
            this.btnReloadLocalDatabase.UseVisualStyleBackColor = true;
            this.btnReloadLocalDatabase.Click += new System.EventHandler(this.btnReloadLocalDatabase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(22, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 10);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Local Database";
            // 
            // chkWaitForNetwork
            // 
            this.chkWaitForNetwork.AutoSize = true;
            this.chkWaitForNetwork.Checked = true;
            this.chkWaitForNetwork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaitForNetwork.Location = new System.Drawing.Point(36, 49);
            this.chkWaitForNetwork.Name = "chkWaitForNetwork";
            this.chkWaitForNetwork.Size = new System.Drawing.Size(169, 17);
            this.chkWaitForNetwork.TabIndex = 12;
            this.chkWaitForNetwork.Text = "Wait for network on startup for";
            this.chkWaitForNetwork.UseVisualStyleBackColor = true;
            // 
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.Checked = true;
            this.chkStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartup.Location = new System.Drawing.Point(36, 72);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(181, 17);
            this.chkStartup.TabIndex = 11;
            this.chkStartup.Text = "Start Links when I start Windows";
            this.chkStartup.UseVisualStyleBackColor = true;
            // 
            // lblWaitForNetworkMinutes1
            // 
            this.lblWaitForNetworkMinutes1.AutoSize = true;
            this.lblWaitForNetworkMinutes1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitForNetworkMinutes1.ForeColor = System.Drawing.Color.Black;
            this.lblWaitForNetworkMinutes1.Location = new System.Drawing.Point(243, 49);
            this.lblWaitForNetworkMinutes1.Name = "lblWaitForNetworkMinutes1";
            this.lblWaitForNetworkMinutes1.Size = new System.Drawing.Size(43, 13);
            this.lblWaitForNetworkMinutes1.TabIndex = 9;
            this.lblWaitForNetworkMinutes1.Text = "minutes";
            // 
            // cmbWaitForNetwork
            // 
            this.cmbWaitForNetwork.FormattingEnabled = true;
            this.cmbWaitForNetwork.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbWaitForNetwork.Location = new System.Drawing.Point(205, 46);
            this.cmbWaitForNetwork.Name = "cmbWaitForNetwork";
            this.cmbWaitForNetwork.Size = new System.Drawing.Size(32, 21);
            this.cmbWaitForNetwork.TabIndex = 8;
            // 
            // grpSeparator2
            // 
            this.grpSeparator2.Location = new System.Drawing.Point(22, 108);
            this.grpSeparator2.Name = "grpSeparator2";
            this.grpSeparator2.Size = new System.Drawing.Size(355, 10);
            this.grpSeparator2.TabIndex = 7;
            this.grpSeparator2.TabStop = false;
            // 
            // grpSeparator1
            // 
            this.grpSeparator1.Location = new System.Drawing.Point(22, 30);
            this.grpSeparator1.Name = "grpSeparator1";
            this.grpSeparator1.Size = new System.Drawing.Size(355, 10);
            this.grpSeparator1.TabIndex = 6;
            this.grpSeparator1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(310, 302);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 24);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(210, 302);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheckForUpdates
            // 
            this.btnCheckForUpdates.Location = new System.Drawing.Point(241, 185);
            this.btnCheckForUpdates.Name = "btnCheckForUpdates";
            this.btnCheckForUpdates.Size = new System.Drawing.Size(136, 24);
            this.btnCheckForUpdates.TabIndex = 15;
            this.btnCheckForUpdates.Text = "Check For Updates";
            this.btnCheckForUpdates.UseVisualStyleBackColor = true;
            this.btnCheckForUpdates.Click += new System.EventHandler(this.btnCheckForUpdates_Click);
            // 
            // frmGeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 337);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGeneralSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.Label lblApplicationBehaviour;
        private System.Windows.Forms.Label lblStartupOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGeneralSettingsTitle;
        private System.Windows.Forms.Label lblGeneralSettingsText;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpSeparator2;
        private System.Windows.Forms.GroupBox grpSeparator1;
        private System.Windows.Forms.ComboBox cmbWaitForNetwork;
        private System.Windows.Forms.Label lblWaitForNetworkMinutes1;
        private System.Windows.Forms.CheckBox chkWaitForNetwork;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.Button btnReloadLocalDatabase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckForUpdates;
    }
}