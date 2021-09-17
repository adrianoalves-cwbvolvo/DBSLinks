using System;

namespace LinksForm
{
    partial class frmLinks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinks));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnExportContactsToExcel = new System.Windows.Forms.Button();
            this.imageListButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnDeleteContact = new System.Windows.Forms.Button();
            this.btnEditContact = new System.Windows.Forms.Button();
            this.btnNewContact = new System.Windows.Forms.Button();
            this.lblClearContactsSearch = new System.Windows.Forms.Label();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.txtContacts = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExportDealersToExcel = new System.Windows.Forms.Button();
            this.btnDeleteDealerBranch = new System.Windows.Forms.Button();
            this.btnEditDealerBranch = new System.Windows.Forms.Button();
            this.btnNewDealerBranch = new System.Windows.Forms.Button();
            this.chkDealerContacts = new System.Windows.Forms.CheckBox();
            this.imageListMenuIcons = new System.Windows.Forms.ImageList(this.components);
            this.lblClearDealersSearch = new System.Windows.Forms.Label();
            this.txtDealers = new System.Windows.Forms.TextBox();
            this.dgvDealers = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEditApplication = new System.Windows.Forms.Button();
            this.btnNewApplication = new System.Windows.Forms.Button();
            this.btnDeleteApplication = new System.Windows.Forms.Button();
            this.lblClearAppSearch = new System.Windows.Forms.Label();
            this.chkHidePasswords = new System.Windows.Forms.CheckBox();
            this.txtAppSearch = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tspConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.dataAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dealersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealerBranchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.credentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updatePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripContacts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDealers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealers)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.contextMenuSystemTray.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripApps.SuspendLayout();
            this.contextMenuStripContacts.SuspendLayout();
            this.contextMenuStripDealers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.ImageList = this.imageListMenuIcons;
            this.tabMain.ItemSize = new System.Drawing.Size(88, 30);
            this.tabMain.Location = new System.Drawing.Point(0, 1);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(623, 491);
            this.tabMain.TabIndex = 0;
            this.tabMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabMain_MouseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnExportContactsToExcel);
            this.tabPage1.Controls.Add(this.btnDeleteContact);
            this.tabPage1.Controls.Add(this.btnEditContact);
            this.tabPage1.Controls.Add(this.btnNewContact);
            this.tabPage1.Controls.Add(this.lblClearContactsSearch);
            this.tabPage1.Controls.Add(this.dgvContacts);
            this.tabPage1.Controls.Add(this.txtContacts);
            this.tabPage1.ImageKey = "Contact.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Phone Contacts";
            // 
            // btnExportContactsToExcel
            // 
            this.btnExportContactsToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportContactsToExcel.ImageIndex = 5;
            this.btnExportContactsToExcel.ImageList = this.imageListButtons;
            this.btnExportContactsToExcel.Location = new System.Drawing.Point(429, 7);
            this.btnExportContactsToExcel.Name = "btnExportContactsToExcel";
            this.btnExportContactsToExcel.Size = new System.Drawing.Size(35, 35);
            this.btnExportContactsToExcel.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnExportContactsToExcel, "Export to Excel");
            this.btnExportContactsToExcel.UseVisualStyleBackColor = true;
            this.btnExportContactsToExcel.Click += new System.EventHandler(this.btnExportContactsToExcel_Click);
            // 
            // imageListButtons
            // 
            this.imageListButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListButtons.ImageStream")));
            this.imageListButtons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListButtons.Images.SetKeyName(0, "New.png");
            this.imageListButtons.Images.SetKeyName(1, "Edit.png");
            this.imageListButtons.Images.SetKeyName(2, "Delete.png");
            this.imageListButtons.Images.SetKeyName(3, "CogWheelNoBoarder.png");
            this.imageListButtons.Images.SetKeyName(4, "Reload-30.png");
            this.imageListButtons.Images.SetKeyName(5, "export-to-excel.png");
            // 
            // btnDeleteContact
            // 
            this.btnDeleteContact.Enabled = false;
            this.btnDeleteContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteContact.ImageIndex = 2;
            this.btnDeleteContact.ImageList = this.imageListButtons;
            this.btnDeleteContact.Location = new System.Drawing.Point(568, 7);
            this.btnDeleteContact.Name = "btnDeleteContact";
            this.btnDeleteContact.Size = new System.Drawing.Size(36, 35);
            this.btnDeleteContact.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnDeleteContact, "Delete Contact");
            this.btnDeleteContact.UseVisualStyleBackColor = true;
            this.btnDeleteContact.Click += new System.EventHandler(this.btnDeleteContact_Click);
            // 
            // btnEditContact
            // 
            this.btnEditContact.Enabled = false;
            this.btnEditContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditContact.ImageIndex = 1;
            this.btnEditContact.ImageList = this.imageListButtons;
            this.btnEditContact.Location = new System.Drawing.Point(526, 7);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(36, 35);
            this.btnEditContact.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnEditContact, "Edit Contact");
            this.btnEditContact.UseVisualStyleBackColor = true;
            this.btnEditContact.Click += new System.EventHandler(this.btnEditContact_Click);
            // 
            // btnNewContact
            // 
            this.btnNewContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewContact.ImageIndex = 0;
            this.btnNewContact.ImageList = this.imageListButtons;
            this.btnNewContact.Location = new System.Drawing.Point(484, 7);
            this.btnNewContact.Name = "btnNewContact";
            this.btnNewContact.Size = new System.Drawing.Size(36, 35);
            this.btnNewContact.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnNewContact, "New Contact");
            this.btnNewContact.UseVisualStyleBackColor = true;
            this.btnNewContact.Click += new System.EventHandler(this.btnNewContact_Click);
            // 
            // lblClearContactsSearch
            // 
            this.lblClearContactsSearch.AutoSize = true;
            this.lblClearContactsSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblClearContactsSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearContactsSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClearContactsSearch.Location = new System.Drawing.Point(150, 20);
            this.lblClearContactsSearch.Name = "lblClearContactsSearch";
            this.lblClearContactsSearch.Size = new System.Drawing.Size(15, 13);
            this.lblClearContactsSearch.TabIndex = 5;
            this.lblClearContactsSearch.Text = "X";
            this.lblClearContactsSearch.Visible = false;
            this.lblClearContactsSearch.Click += new System.EventHandler(this.lblClearContactsSearch_Click);
            this.lblClearContactsSearch.MouseLeave += new System.EventHandler(this.lblClearContactsSearch_MouseLeave);
            this.lblClearContactsSearch.MouseHover += new System.EventHandler(this.lblClearContactsSearch_MouseHover);
            // 
            // dgvContacts
            // 
            this.dgvContacts.AllowUserToAddRows = false;
            this.dgvContacts.AllowUserToDeleteRows = false;
            this.dgvContacts.AllowUserToResizeRows = false;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Location = new System.Drawing.Point(5, 50);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.RowHeadersVisible = false;
            this.dgvContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvContacts.Size = new System.Drawing.Size(604, 410);
            this.dgvContacts.TabIndex = 3;
            this.dgvContacts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContacts_CellClick);
            this.dgvContacts.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvContacts_CellMouseDown);
            this.dgvContacts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvContacts_KeyDown);
            this.dgvContacts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvContacts_MouseClick);
            // 
            // txtContacts
            // 
            this.txtContacts.Location = new System.Drawing.Point(5, 17);
            this.txtContacts.Name = "txtContacts";
            this.txtContacts.Size = new System.Drawing.Size(164, 20);
            this.txtContacts.TabIndex = 2;
            this.txtContacts.TextChanged += new System.EventHandler(this.txtContacts_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExportDealersToExcel);
            this.tabPage2.Controls.Add(this.btnDeleteDealerBranch);
            this.tabPage2.Controls.Add(this.btnEditDealerBranch);
            this.tabPage2.Controls.Add(this.btnNewDealerBranch);
            this.tabPage2.Controls.Add(this.chkDealerContacts);
            this.tabPage2.Controls.Add(this.lblClearDealersSearch);
            this.tabPage2.Controls.Add(this.txtDealers);
            this.tabPage2.Controls.Add(this.dgvDealers);
            this.tabPage2.ImageIndex = 2;
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(615, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dealers - Partner Branches";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExportDealersToExcel
            // 
            this.btnExportDealersToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportDealersToExcel.ImageIndex = 5;
            this.btnExportDealersToExcel.ImageList = this.imageListButtons;
            this.btnExportDealersToExcel.Location = new System.Drawing.Point(429, 7);
            this.btnExportDealersToExcel.Name = "btnExportDealersToExcel";
            this.btnExportDealersToExcel.Size = new System.Drawing.Size(35, 35);
            this.btnExportDealersToExcel.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnExportDealersToExcel, "Export to Excel");
            this.btnExportDealersToExcel.UseVisualStyleBackColor = true;
            this.btnExportDealersToExcel.Click += new System.EventHandler(this.btnExportDealersToExcel_Click);
            // 
            // btnDeleteDealerBranch
            // 
            this.btnDeleteDealerBranch.Enabled = false;
            this.btnDeleteDealerBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDealerBranch.ImageIndex = 2;
            this.btnDeleteDealerBranch.ImageList = this.imageListButtons;
            this.btnDeleteDealerBranch.Location = new System.Drawing.Point(568, 7);
            this.btnDeleteDealerBranch.Name = "btnDeleteDealerBranch";
            this.btnDeleteDealerBranch.Size = new System.Drawing.Size(36, 35);
            this.btnDeleteDealerBranch.TabIndex = 8;
            this.btnDeleteDealerBranch.UseVisualStyleBackColor = true;
            this.btnDeleteDealerBranch.Click += new System.EventHandler(this.btnDeleteDealerBranch_Click);
            // 
            // btnEditDealerBranch
            // 
            this.btnEditDealerBranch.Enabled = false;
            this.btnEditDealerBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDealerBranch.ImageIndex = 1;
            this.btnEditDealerBranch.ImageList = this.imageListButtons;
            this.btnEditDealerBranch.Location = new System.Drawing.Point(526, 7);
            this.btnEditDealerBranch.Name = "btnEditDealerBranch";
            this.btnEditDealerBranch.Size = new System.Drawing.Size(36, 35);
            this.btnEditDealerBranch.TabIndex = 9;
            this.btnEditDealerBranch.UseVisualStyleBackColor = true;
            this.btnEditDealerBranch.Click += new System.EventHandler(this.btnEditDealerBranch_Click);
            // 
            // btnNewDealerBranch
            // 
            this.btnNewDealerBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDealerBranch.ImageIndex = 0;
            this.btnNewDealerBranch.ImageList = this.imageListButtons;
            this.btnNewDealerBranch.Location = new System.Drawing.Point(484, 7);
            this.btnNewDealerBranch.Name = "btnNewDealerBranch";
            this.btnNewDealerBranch.Size = new System.Drawing.Size(36, 35);
            this.btnNewDealerBranch.TabIndex = 10;
            this.btnNewDealerBranch.UseVisualStyleBackColor = true;
            this.btnNewDealerBranch.Click += new System.EventHandler(this.btnNewDealerBranch_Click);
            // 
            // chkDealerContacts
            // 
            this.chkDealerContacts.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDealerContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDealerContacts.ImageIndex = 10;
            this.chkDealerContacts.ImageList = this.imageListMenuIcons;
            this.chkDealerContacts.Location = new System.Drawing.Point(175, 7);
            this.chkDealerContacts.Margin = new System.Windows.Forms.Padding(0);
            this.chkDealerContacts.Name = "chkDealerContacts";
            this.chkDealerContacts.Size = new System.Drawing.Size(36, 35);
            this.chkDealerContacts.TabIndex = 7;
            this.chkDealerContacts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDealerContacts.UseVisualStyleBackColor = true;
            this.chkDealerContacts.CheckedChanged += new System.EventHandler(this.chkDealerContacts_CheckedChanged);
            // 
            // imageListMenuIcons
            // 
            this.imageListMenuIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMenuIcons.ImageStream")));
            this.imageListMenuIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMenuIcons.Images.SetKeyName(0, "Contact.png");
            this.imageListMenuIcons.Images.SetKeyName(1, "Applications.png");
            this.imageListMenuIcons.Images.SetKeyName(2, "Truck-30.png");
            this.imageListMenuIcons.Images.SetKeyName(3, "Truck-40 (2).png");
            this.imageListMenuIcons.Images.SetKeyName(4, "Countries30,.png");
            this.imageListMenuIcons.Images.SetKeyName(5, "Credential30.png");
            this.imageListMenuIcons.Images.SetKeyName(6, "New.png");
            this.imageListMenuIcons.Images.SetKeyName(7, "Edit.png");
            this.imageListMenuIcons.Images.SetKeyName(8, "Delete.png");
            this.imageListMenuIcons.Images.SetKeyName(9, "Reload-30.png");
            this.imageListMenuIcons.Images.SetKeyName(10, "View Delaer Contacts.png");
            this.imageListMenuIcons.Images.SetKeyName(11, "Viewing Dealer Contacts.png");
            this.imageListMenuIcons.Images.SetKeyName(12, "view-password.png");
            this.imageListMenuIcons.Images.SetKeyName(13, "hide-password.png");
            // 
            // lblClearDealersSearch
            // 
            this.lblClearDealersSearch.AutoSize = true;
            this.lblClearDealersSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearDealersSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClearDealersSearch.Location = new System.Drawing.Point(150, 20);
            this.lblClearDealersSearch.Name = "lblClearDealersSearch";
            this.lblClearDealersSearch.Size = new System.Drawing.Size(15, 13);
            this.lblClearDealersSearch.TabIndex = 6;
            this.lblClearDealersSearch.Text = "X";
            this.lblClearDealersSearch.Visible = false;
            this.lblClearDealersSearch.Click += new System.EventHandler(this.lblClearDealersSearch_Click);
            this.lblClearDealersSearch.MouseLeave += new System.EventHandler(this.lblClearDealersSearch_MouseLeave);
            this.lblClearDealersSearch.MouseHover += new System.EventHandler(this.lblClearDealersSearch_MouseHover);
            // 
            // txtDealers
            // 
            this.txtDealers.Location = new System.Drawing.Point(5, 17);
            this.txtDealers.Name = "txtDealers";
            this.txtDealers.Size = new System.Drawing.Size(164, 20);
            this.txtDealers.TabIndex = 2;
            this.txtDealers.TextChanged += new System.EventHandler(this.txtDealers_TextChanged);
            // 
            // dgvDealers
            // 
            this.dgvDealers.AllowUserToAddRows = false;
            this.dgvDealers.AllowUserToDeleteRows = false;
            this.dgvDealers.AllowUserToOrderColumns = true;
            this.dgvDealers.AllowUserToResizeRows = false;
            this.dgvDealers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDealers.Location = new System.Drawing.Point(5, 50);
            this.dgvDealers.Name = "dgvDealers";
            this.dgvDealers.ReadOnly = true;
            this.dgvDealers.RowHeadersVisible = false;
            this.dgvDealers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDealers.Size = new System.Drawing.Size(604, 410);
            this.dgvDealers.TabIndex = 3;
            this.dgvDealers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDealers_CellClick);
            this.dgvDealers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDealers_CellMouseDown);
            this.dgvDealers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDealers_MouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnEditApplication);
            this.tabPage3.Controls.Add(this.btnNewApplication);
            this.tabPage3.Controls.Add(this.btnDeleteApplication);
            this.tabPage3.Controls.Add(this.lblClearAppSearch);
            this.tabPage3.Controls.Add(this.chkHidePasswords);
            this.tabPage3.Controls.Add(this.txtAppSearch);
            this.tabPage3.Controls.Add(this.treeView1);
            this.tabPage3.ImageKey = "Applications.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(615, 453);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Applications";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnEditApplication
            // 
            this.btnEditApplication.Enabled = false;
            this.btnEditApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditApplication.ImageIndex = 1;
            this.btnEditApplication.ImageList = this.imageListButtons;
            this.btnEditApplication.Location = new System.Drawing.Point(526, 7);
            this.btnEditApplication.Name = "btnEditApplication";
            this.btnEditApplication.Size = new System.Drawing.Size(36, 35);
            this.btnEditApplication.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnEditApplication, "Edit Application Link");
            this.btnEditApplication.UseVisualStyleBackColor = true;
            this.btnEditApplication.Click += new System.EventHandler(this.btnEditApplication_Click);
            // 
            // btnNewApplication
            // 
            this.btnNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewApplication.ImageIndex = 0;
            this.btnNewApplication.ImageList = this.imageListButtons;
            this.btnNewApplication.Location = new System.Drawing.Point(484, 7);
            this.btnNewApplication.Name = "btnNewApplication";
            this.btnNewApplication.Size = new System.Drawing.Size(36, 35);
            this.btnNewApplication.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnNewApplication, "New Application Link");
            this.btnNewApplication.UseVisualStyleBackColor = true;
            this.btnNewApplication.Click += new System.EventHandler(this.btnNewApplication_Click);
            // 
            // btnDeleteApplication
            // 
            this.btnDeleteApplication.Enabled = false;
            this.btnDeleteApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteApplication.ImageIndex = 2;
            this.btnDeleteApplication.ImageList = this.imageListButtons;
            this.btnDeleteApplication.Location = new System.Drawing.Point(568, 7);
            this.btnDeleteApplication.Name = "btnDeleteApplication";
            this.btnDeleteApplication.Size = new System.Drawing.Size(36, 35);
            this.btnDeleteApplication.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnDeleteApplication, "Delete Application Link");
            this.btnDeleteApplication.UseVisualStyleBackColor = true;
            this.btnDeleteApplication.Click += new System.EventHandler(this.btnDeleteApplication_Click);
            // 
            // lblClearAppSearch
            // 
            this.lblClearAppSearch.AutoSize = true;
            this.lblClearAppSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearAppSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClearAppSearch.Location = new System.Drawing.Point(150, 20);
            this.lblClearAppSearch.Name = "lblClearAppSearch";
            this.lblClearAppSearch.Size = new System.Drawing.Size(15, 13);
            this.lblClearAppSearch.TabIndex = 7;
            this.lblClearAppSearch.Text = "X";
            this.lblClearAppSearch.Visible = false;
            this.lblClearAppSearch.Click += new System.EventHandler(this.lblClearAppSearch_Click);
            this.lblClearAppSearch.MouseLeave += new System.EventHandler(this.lblClearAppSearch_MouseLeave);
            this.lblClearAppSearch.MouseHover += new System.EventHandler(this.lblClearAppSearch_MouseHover);
            // 
            // chkHidePasswords
            // 
            this.chkHidePasswords.AutoSize = true;
            this.chkHidePasswords.Location = new System.Drawing.Point(175, 20);
            this.chkHidePasswords.Name = "chkHidePasswords";
            this.chkHidePasswords.Size = new System.Drawing.Size(107, 17);
            this.chkHidePasswords.TabIndex = 5;
            this.chkHidePasswords.Text = "Show Passwords";
            this.chkHidePasswords.UseVisualStyleBackColor = true;
            this.chkHidePasswords.CheckedChanged += new System.EventHandler(this.chkHidePasswords_CheckedChanged);
            // 
            // txtAppSearch
            // 
            this.txtAppSearch.Location = new System.Drawing.Point(5, 17);
            this.txtAppSearch.Name = "txtAppSearch";
            this.txtAppSearch.Size = new System.Drawing.Size(164, 20);
            this.txtAppSearch.TabIndex = 3;
            this.txtAppSearch.TextChanged += new System.EventHandler(this.txtAppSearch_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.imageList;
            this.treeView1.Indent = 20;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Location = new System.Drawing.Point(5, 50);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.Size = new System.Drawing.Size(604, 410);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "AR.png");
            this.imageList.Images.SetKeyName(1, "BR.png");
            this.imageList.Images.SetKeyName(2, "CL.png");
            this.imageList.Images.SetKeyName(3, "CO.png");
            this.imageList.Images.SetKeyName(4, "PE.png");
            this.imageList.Images.SetKeyName(5, "database.png");
            this.imageList.Images.SetKeyName(6, "Apps.png");
            this.imageList.Images.SetKeyName(7, "Link.png");
            this.imageList.Images.SetKeyName(8, "User.png");
            this.imageList.Images.SetKeyName(9, "Password.png");
            this.imageList.Images.SetKeyName(10, "folder.png");
            this.imageList.Images.SetKeyName(11, "SubApps.png");
            this.imageList.Images.SetKeyName(12, "Valid.png");
            this.imageList.Images.SetKeyName(13, "Production.png");
            this.imageList.Images.SetKeyName(14, "QA.png");
            this.imageList.Images.SetKeyName(15, "bullet.png");
            this.imageList.Images.SetKeyName(16, "Refresh.png");
            this.imageList.Images.SetKeyName(17, "CogWheel.png");
            this.imageList.Images.SetKeyName(18, "Volvo.jpg");
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuSystemTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Links";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuSystemTray
            // 
            this.contextMenuSystemTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripSeparator6,
            this.toolStripSeparator5});
            this.contextMenuSystemTray.Name = "contextMenuStrip1";
            this.contextMenuSystemTray.Size = new System.Drawing.Size(108, 38);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(104, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(104, 6);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspConfig});
            this.menuStrip1.Location = new System.Drawing.Point(0, 495);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(631, 32);
            this.menuStrip1.TabIndex = 2;
            // 
            // tspConfig
            // 
            this.tspConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataAdminToolStripMenuItem,
            this.toolStripSeparator1,
            this.reloadDataToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutToolStripMenuItem1,
            this.toolStripSeparator3,
            this.exitApplicationToolStripMenuItem});
            this.tspConfig.Image = global::Links.Properties.Resources.Menu_squared_30;
            this.tspConfig.Name = "tspConfig";
            this.tspConfig.Size = new System.Drawing.Size(36, 28);
            // 
            // dataAdminToolStripMenuItem
            // 
            this.dataAdminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countriesToolStripMenuItem,
            this.applicationsToolStripMenuItem,
            this.toolStripSeparator4,
            this.dealersToolStripMenuItem,
            this.dealerBranchesToolStripMenuItem,
            this.toolStripSeparator2,
            this.credentialsToolStripMenuItem});
            this.dataAdminToolStripMenuItem.Image = global::Links.Properties.Resources.DataAdmin30;
            this.dataAdminToolStripMenuItem.Name = "dataAdminToolStripMenuItem";
            this.dataAdminToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.dataAdminToolStripMenuItem.Text = "Data Admin";
            // 
            // countriesToolStripMenuItem
            // 
            this.countriesToolStripMenuItem.Image = global::Links.Properties.Resources.Countries30_;
            this.countriesToolStripMenuItem.Name = "countriesToolStripMenuItem";
            this.countriesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.countriesToolStripMenuItem.Text = "Countries";
            this.countriesToolStripMenuItem.Click += new System.EventHandler(this.countriesToolStripMenuItem_Click_1);
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.Image = global::Links.Properties.Resources.Applications;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.applicationsToolStripMenuItem.Text = "Applications";
            this.applicationsToolStripMenuItem.Click += new System.EventHandler(this.applicationsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(223, 6);
            // 
            // dealersToolStripMenuItem
            // 
            this.dealersToolStripMenuItem.Image = global::Links.Properties.Resources.Main_Dealer;
            this.dealersToolStripMenuItem.Name = "dealersToolStripMenuItem";
            this.dealersToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.dealersToolStripMenuItem.Text = "Dealers (Main Partner Name)";
            this.dealersToolStripMenuItem.Click += new System.EventHandler(this.dealersToolStripMenuItem_Click);
            // 
            // dealerBranchesToolStripMenuItem
            // 
            this.dealerBranchesToolStripMenuItem.Image = global::Links.Properties.Resources.Truck_40__2_;
            this.dealerBranchesToolStripMenuItem.Name = "dealerBranchesToolStripMenuItem";
            this.dealerBranchesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.dealerBranchesToolStripMenuItem.Text = "Dealers (Partner Branches)";
            this.dealerBranchesToolStripMenuItem.Click += new System.EventHandler(this.dealerBranchesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // credentialsToolStripMenuItem
            // 
            this.credentialsToolStripMenuItem.Image = global::Links.Properties.Resources.Credential30;
            this.credentialsToolStripMenuItem.Name = "credentialsToolStripMenuItem";
            this.credentialsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.credentialsToolStripMenuItem.Text = "Credentials";
            this.credentialsToolStripMenuItem.Click += new System.EventHandler(this.credentialsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // reloadDataToolStripMenuItem
            // 
            this.reloadDataToolStripMenuItem.Image = global::Links.Properties.Resources.Reload_30;
            this.reloadDataToolStripMenuItem.Name = "reloadDataToolStripMenuItem";
            this.reloadDataToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.reloadDataToolStripMenuItem.Text = "Data Reload";
            this.reloadDataToolStripMenuItem.Click += new System.EventHandler(this.reloadDataToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::Links.Properties.Resources.CogWheelBoarder;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(154, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Image = global::Links.Properties.Resources.About_30;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(154, 6);
            // 
            // exitApplicationToolStripMenuItem
            // 
            this.exitApplicationToolStripMenuItem.Image = global::Links.Properties.Resources.Shutdown_301;
            this.exitApplicationToolStripMenuItem.Name = "exitApplicationToolStripMenuItem";
            this.exitApplicationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitApplicationToolStripMenuItem.Text = "Exit Application";
            this.exitApplicationToolStripMenuItem.Click += new System.EventHandler(this.exitApplicationToolStripMenuItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 250;
            this.toolTip1.BackColor = System.Drawing.Color.Khaki;
            // 
            // contextMenuStripApps
            // 
            this.contextMenuStripApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatePasswordToolStripMenuItem});
            this.contextMenuStripApps.Name = "contextMenuStripApps";
            this.contextMenuStripApps.Size = new System.Drawing.Size(166, 26);
            this.contextMenuStripApps.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStripApps_Closed);
            // 
            // updatePasswordToolStripMenuItem
            // 
            this.updatePasswordToolStripMenuItem.Name = "updatePasswordToolStripMenuItem";
            this.updatePasswordToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.updatePasswordToolStripMenuItem.Text = "Update Password";
            this.updatePasswordToolStripMenuItem.Visible = false;
            this.updatePasswordToolStripMenuItem.Click += new System.EventHandler(this.updatePasswordToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // contextMenuStripContacts
            // 
            this.contextMenuStripContacts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextMenuStripContacts.Name = "contextMenuStrip2";
            this.contextMenuStripContacts.Size = new System.Drawing.Size(103, 26);
            this.contextMenuStripContacts.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripContacts_Opening);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            // 
            // contextMenuStripDealers
            // 
            this.contextMenuStripDealers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1});
            this.contextMenuStripDealers.Name = "contextMenuStripDealers";
            this.contextMenuStripDealers.Size = new System.Drawing.Size(103, 26);
            this.contextMenuStripDealers.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripDealers_Opening);
            // 
            // frmLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 527);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLinks";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLinks_FormClosing);
            this.Load += new System.EventHandler(this.frmLinks_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealers)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.contextMenuSystemTray.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripApps.ResumeLayout(false);
            this.contextMenuStripContacts.ResumeLayout(false);
            this.contextMenuStripDealers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuSystemTray;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.TextBox txtContacts;
        private System.Windows.Forms.TextBox txtDealers;
        private System.Windows.Forms.DataGridView dgvDealers;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tspConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox txtAppSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripApps;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.CheckBox chkHidePasswords;
        private System.Windows.Forms.Label lblClearContactsSearch;
        private System.Windows.Forms.Label lblClearDealersSearch;
        private System.Windows.Forms.ToolStripMenuItem updatePasswordToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkDealerContacts;
        private System.Windows.Forms.Label lblClearAppSearch;
        private System.Windows.Forms.Button btnNewContact;
        private System.Windows.Forms.ImageList imageListButtons;
        private System.Windows.Forms.Button btnDeleteContact;
        private System.Windows.Forms.Button btnEditContact;
        private System.Windows.Forms.Button btnDeleteDealerBranch;
        private System.Windows.Forms.Button btnEditDealerBranch;
        private System.Windows.Forms.Button btnNewDealerBranch;
        private System.Windows.Forms.Button btnEditApplication;
        private System.Windows.Forms.Button btnNewApplication;
        private System.Windows.Forms.Button btnDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem exitApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem credentialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem dealersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem dealerBranchesToolStripMenuItem;
        private System.Windows.Forms.Button btnExportContactsToExcel;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripContacts;
        private System.Windows.Forms.ImageList imageListMenuIcons;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDealers;
        private System.Windows.Forms.Button btnExportDealersToExcel;
    }
}

