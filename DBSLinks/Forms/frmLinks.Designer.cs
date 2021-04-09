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
            this.lblClearContactsSearch = new System.Windows.Forms.Label();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.txtContacts = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkDealerContacts = new System.Windows.Forms.CheckBox();
            this.lblClearDealersSearch = new System.Windows.Forms.Label();
            this.txtDealers = new System.Windows.Forms.TextBox();
            this.dgvDealers = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblClearAppSearch = new System.Windows.Forms.Label();
            this.chkHidePasswords = new System.Windows.Forms.CheckBox();
            this.txtAppSearch = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripContacts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tspExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tspConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMenuContacts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dealersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subDealersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.applicationsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.credentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripDealers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPwdSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.updatePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealers)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.contextMenuSystemTray.SuspendLayout();
            this.contextMenuStripContacts.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripDealers.SuspendLayout();
            this.contextMenuStripApps.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.ItemSize = new System.Drawing.Size(88, 20);
            this.tabMain.Location = new System.Drawing.Point(4, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(520, 475);
            this.tabMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblClearContactsSearch);
            this.tabPage1.Controls.Add(this.dgvContacts);
            this.tabPage1.Controls.Add(this.txtContacts);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(512, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Phone Contacts";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.dgvContacts.Location = new System.Drawing.Point(5, 40);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.RowHeadersVisible = false;
            this.dgvContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvContacts.Size = new System.Drawing.Size(500, 400);
            this.dgvContacts.TabIndex = 3;
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
            this.tabPage2.Controls.Add(this.chkDealerContacts);
            this.tabPage2.Controls.Add(this.lblClearDealersSearch);
            this.tabPage2.Controls.Add(this.txtDealers);
            this.tabPage2.Controls.Add(this.dgvDealers);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(512, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dealers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkDealerContacts
            // 
            this.chkDealerContacts.AutoSize = true;
            this.chkDealerContacts.Location = new System.Drawing.Point(175, 20);
            this.chkDealerContacts.Name = "chkDealerContacts";
            this.chkDealerContacts.Size = new System.Drawing.Size(102, 17);
            this.chkDealerContacts.TabIndex = 7;
            this.chkDealerContacts.Text = "Dealer Contacts";
            this.chkDealerContacts.UseVisualStyleBackColor = true;
            this.chkDealerContacts.CheckedChanged += new System.EventHandler(this.chkDealerContacts_CheckedChanged);
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
            this.dgvDealers.Location = new System.Drawing.Point(5, 40);
            this.dgvDealers.Name = "dgvDealers";
            this.dgvDealers.ReadOnly = true;
            this.dgvDealers.RowHeadersVisible = false;
            this.dgvDealers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDealers.Size = new System.Drawing.Size(500, 400);
            this.dgvDealers.TabIndex = 3;
            this.dgvDealers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDealers_CellMouseDown);
            this.dgvDealers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDealers_MouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblClearAppSearch);
            this.tabPage3.Controls.Add(this.chkHidePasswords);
            this.tabPage3.Controls.Add(this.txtAppSearch);
            this.tabPage3.Controls.Add(this.treeView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(512, 447);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Applications";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.treeView1.Location = new System.Drawing.Point(5, 40);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.Size = new System.Drawing.Size(500, 400);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
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
            this.refreshDataToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.contextMenuSystemTray.Name = "contextMenuStrip1";
            this.contextMenuSystemTray.Size = new System.Drawing.Size(160, 104);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(156, 6);
            // 
            // refreshDataToolStripMenuItem
            // 
            this.refreshDataToolStripMenuItem.Name = "refreshDataToolStripMenuItem";
            this.refreshDataToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.refreshDataToolStripMenuItem.Text = "Refresh Data";
            this.refreshDataToolStripMenuItem.Click += new System.EventHandler(this.refreshDataToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.configurationToolStripMenuItem.Text = "General Settings";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.generalSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(156, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // contextMenuStripContacts
            // 
            this.contextMenuStripContacts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextMenuStripContacts.Name = "contextMenuStrip2";
            this.contextMenuStripContacts.Size = new System.Drawing.Size(103, 26);
            this.contextMenuStripContacts.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripContacts_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspExit,
            this.tspConfig});
            this.menuStrip1.Location = new System.Drawing.Point(0, 469);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 32);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // tspExit
            // 
            this.tspExit.Image = global::Links.Properties.Resources.Exit;
            this.tspExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspExit.Name = "tspExit";
            this.tspExit.Size = new System.Drawing.Size(36, 28);
            this.tspExit.Click += new System.EventHandler(this.tspExit_Click);
            // 
            // tspConfig
            // 
            this.tspConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspMenuContacts,
            this.toolStripSeparator2,
            this.dealersToolStripMenuItem,
            this.subDealersToolStripMenuItem,
            this.toolStripSeparator1,
            this.applicationToolStripMenuItem});
            this.tspConfig.Image = global::Links.Properties.Resources.CogWheel;
            this.tspConfig.Name = "tspConfig";
            this.tspConfig.Size = new System.Drawing.Size(32, 28);
            this.tspConfig.Visible = false;
            // 
            // tspMenuContacts
            // 
            this.tspMenuContacts.Image = ((System.Drawing.Image)(resources.GetObject("tspMenuContacts.Image")));
            this.tspMenuContacts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspMenuContacts.Name = "tspMenuContacts";
            this.tspMenuContacts.Size = new System.Drawing.Size(140, 30);
            this.tspMenuContacts.Text = "Contacts";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // dealersToolStripMenuItem
            // 
            this.dealersToolStripMenuItem.Image = global::Links.Properties.Resources.Dealer_Truck;
            this.dealersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dealersToolStripMenuItem.Name = "dealersToolStripMenuItem";
            this.dealersToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.dealersToolStripMenuItem.Text = "Dealers";
            // 
            // subDealersToolStripMenuItem
            // 
            this.subDealersToolStripMenuItem.Image = global::Links.Properties.Resources.SubDealer_Truck;
            this.subDealersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subDealersToolStripMenuItem.Name = "subDealersToolStripMenuItem";
            this.subDealersToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.subDealersToolStripMenuItem.Text = "SubDealers";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appLinksToolStripMenuItem,
            this.toolStripSeparator3,
            this.applicationsListToolStripMenuItem,
            this.toolStripSeparator4,
            this.credentialsToolStripMenuItem});
            this.applicationToolStripMenuItem.Image = global::Links.Properties.Resources.AppsBW;
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.applicationToolStripMenuItem.Text = "Links";
            // 
            // appLinksToolStripMenuItem
            // 
            this.appLinksToolStripMenuItem.Image = global::Links.Properties.Resources.Link;
            this.appLinksToolStripMenuItem.Name = "appLinksToolStripMenuItem";
            this.appLinksToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.appLinksToolStripMenuItem.Text = "Application Links";
            this.appLinksToolStripMenuItem.Click += new System.EventHandler(this.appLinksToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
            // 
            // applicationsListToolStripMenuItem
            // 
            this.applicationsListToolStripMenuItem.Image = global::Links.Properties.Resources.ApplicationList;
            this.applicationsListToolStripMenuItem.Name = "applicationsListToolStripMenuItem";
            this.applicationsListToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.applicationsListToolStripMenuItem.Text = "Applications";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(162, 6);
            // 
            // credentialsToolStripMenuItem
            // 
            this.credentialsToolStripMenuItem.Image = global::Links.Properties.Resources.PadLock_BW;
            this.credentialsToolStripMenuItem.Name = "credentialsToolStripMenuItem";
            this.credentialsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 250;
            this.toolTip1.BackColor = System.Drawing.Color.Khaki;
            // 
            // contextMenuStripDealers
            // 
            this.contextMenuStripDealers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1});
            this.contextMenuStripDealers.Name = "contextMenuStripDealers";
            this.contextMenuStripDealers.Size = new System.Drawing.Size(103, 26);
            this.contextMenuStripDealers.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripDealers_Opening);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            // 
            // contextMenuStripApps
            // 
            this.contextMenuStripApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem2,
            this.toolStripPwdSeparator,
            this.updatePasswordToolStripMenuItem});
            this.contextMenuStripApps.Name = "contextMenuStripApps";
            this.contextMenuStripApps.Size = new System.Drawing.Size(166, 54);
            this.contextMenuStripApps.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStripApps_Closed);
            // 
            // copyToolStripMenuItem2
            // 
            this.copyToolStripMenuItem2.Name = "copyToolStripMenuItem2";
            this.copyToolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
            this.copyToolStripMenuItem2.Text = "Copy";
            this.copyToolStripMenuItem2.Click += new System.EventHandler(this.copyToolStripMenuItem2_Click);
            // 
            // toolStripPwdSeparator
            // 
            this.toolStripPwdSeparator.Name = "toolStripPwdSeparator";
            this.toolStripPwdSeparator.Size = new System.Drawing.Size(162, 6);
            this.toolStripPwdSeparator.Visible = false;
            // 
            // updatePasswordToolStripMenuItem
            // 
            this.updatePasswordToolStripMenuItem.Name = "updatePasswordToolStripMenuItem";
            this.updatePasswordToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.updatePasswordToolStripMenuItem.Text = "Update Password";
            this.updatePasswordToolStripMenuItem.Visible = false;
            this.updatePasswordToolStripMenuItem.Click += new System.EventHandler(this.updatePasswordToolStripMenuItem_Click);
            // 
            // frmLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 482);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLinks";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmContacts_FormClosing);
            this.Load += new System.EventHandler(this.frmContacts_Load);
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
            this.contextMenuStripContacts.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripDealers.ResumeLayout(false);
            this.contextMenuStripApps.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuSystemTray;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.TextBox txtContacts;
        private System.Windows.Forms.TextBox txtDealers;
        private System.Windows.Forms.DataGridView dgvDealers;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripContacts;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tspConfig;
        private System.Windows.Forms.ToolStripMenuItem tspMenuContacts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem dealersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subDealersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem applicationsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem credentialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tspExit;
        private System.Windows.Forms.TextBox txtAppSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDealers;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripApps;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem refreshDataToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkHidePasswords;
        private System.Windows.Forms.Label lblClearContactsSearch;
        private System.Windows.Forms.Label lblClearDealersSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripPwdSeparator;
        private System.Windows.Forms.ToolStripMenuItem updatePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkDealerContacts;
        private System.Windows.Forms.Label lblClearAppSearch;
    }
}

