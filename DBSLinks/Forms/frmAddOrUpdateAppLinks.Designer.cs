namespace LinksForm.Forms
{
    partial class frmAddOrUpdateAppLinks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddOrUpdateAppLinks));
            this.label4 = new System.Windows.Forms.Label();
            this.cmbApplication = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCredential = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpAppLink = new System.Windows.Forms.GroupBox();
            this.btnRemoveCredential = new System.Windows.Forms.Button();
            this.txtCredentialId = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.dgvCredentials = new System.Windows.Forms.DataGridView();
            this.txtSearchCredential = new System.Windows.Forms.TextBox();
            this.lblClearSearchCredential = new System.Windows.Forms.Label();
            this.grpCredential = new System.Windows.Forms.GroupBox();
            this.btnSelectCredential = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpSelectCredential = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpAppLink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredentials)).BeginInit();
            this.grpCredential.SuspendLayout();
            this.grpSelectCredential.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Application:";
            // 
            // cmbApplication
            // 
            this.cmbApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplication.FormattingEnabled = true;
            this.cmbApplication.Location = new System.Drawing.Point(125, 78);
            this.cmbApplication.Name = "cmbApplication";
            this.cmbApplication.Size = new System.Drawing.Size(179, 21);
            this.cmbApplication.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(125, 105);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(179, 21);
            this.cmbCategory.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(125, 143);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(353, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // lblCredential
            // 
            this.lblCredential.AutoSize = true;
            this.lblCredential.Location = new System.Drawing.Point(38, 146);
            this.lblCredential.Name = "lblCredential";
            this.lblCredential.Size = new System.Drawing.Size(86, 13);
            this.lblCredential.TabIndex = 8;
            this.lblCredential.Text = "Link Description:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(257, 382);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 43);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(157, 382);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 43);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Country:";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(125, 42);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(179, 21);
            this.cmbCountry.TabIndex = 1;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(125, 169);
            this.txtURL.MaxLength = 200;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(353, 20);
            this.txtURL.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Link (URL/IP/Server):";
            // 
            // grpAppLink
            // 
            this.grpAppLink.Controls.Add(this.label6);
            this.grpAppLink.Controls.Add(this.txtDescription);
            this.grpAppLink.Controls.Add(this.lblCredential);
            this.grpAppLink.Controls.Add(this.cmbCountry);
            this.grpAppLink.Controls.Add(this.label4);
            this.grpAppLink.Controls.Add(this.txtURL);
            this.grpAppLink.Controls.Add(this.label7);
            this.grpAppLink.Controls.Add(this.label3);
            this.grpAppLink.Controls.Add(this.cmbCategory);
            this.grpAppLink.Controls.Add(this.cmbApplication);
            this.grpAppLink.Location = new System.Drawing.Point(12, 12);
            this.grpAppLink.Name = "grpAppLink";
            this.grpAppLink.Size = new System.Drawing.Size(495, 213);
            this.grpAppLink.TabIndex = 20;
            this.grpAppLink.TabStop = false;
            this.grpAppLink.Text = "Application Link";
            // 
            // btnRemoveCredential
            // 
            this.btnRemoveCredential.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCredential.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoveCredential.ImageKey = "password32.png";
            this.btnRemoveCredential.Location = new System.Drawing.Point(270, 81);
            this.btnRemoveCredential.Name = "btnRemoveCredential";
            this.btnRemoveCredential.Size = new System.Drawing.Size(139, 23);
            this.btnRemoveCredential.TabIndex = 22;
            this.btnRemoveCredential.Text = "Select Credential";
            this.btnRemoveCredential.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveCredential.UseVisualStyleBackColor = true;
            this.btnRemoveCredential.Click += new System.EventHandler(this.btnRemoveCredential_Click);
            // 
            // txtCredentialId
            // 
            this.txtCredentialId.Location = new System.Drawing.Point(133, 82);
            this.txtCredentialId.MaxLength = 25;
            this.txtCredentialId.Name = "txtCredentialId";
            this.txtCredentialId.ReadOnly = true;
            this.txtCredentialId.Size = new System.Drawing.Size(130, 20);
            this.txtCredentialId.TabIndex = 22;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(70, 85);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(57, 13);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Credential:";
            // 
            // dgvCredentials
            // 
            this.dgvCredentials.AllowUserToAddRows = false;
            this.dgvCredentials.AllowUserToDeleteRows = false;
            this.dgvCredentials.AllowUserToOrderColumns = true;
            this.dgvCredentials.AllowUserToResizeColumns = false;
            this.dgvCredentials.AllowUserToResizeRows = false;
            this.dgvCredentials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCredentials.Location = new System.Drawing.Point(13, 64);
            this.dgvCredentials.MultiSelect = false;
            this.dgvCredentials.Name = "dgvCredentials";
            this.dgvCredentials.ReadOnly = true;
            this.dgvCredentials.RowHeadersVisible = false;
            this.dgvCredentials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCredentials.Size = new System.Drawing.Size(470, 273);
            this.dgvCredentials.TabIndex = 6;
            this.dgvCredentials.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCredentials_CellDoubleClick);
            // 
            // txtSearchCredential
            // 
            this.txtSearchCredential.Location = new System.Drawing.Point(13, 36);
            this.txtSearchCredential.Name = "txtSearchCredential";
            this.txtSearchCredential.Size = new System.Drawing.Size(164, 20);
            this.txtSearchCredential.TabIndex = 24;
            this.txtSearchCredential.TextChanged += new System.EventHandler(this.txSearchCredential_TextChanged);
            // 
            // lblClearSearchCredential
            // 
            this.lblClearSearchCredential.AutoSize = true;
            this.lblClearSearchCredential.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearSearchCredential.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClearSearchCredential.Location = new System.Drawing.Point(158, 39);
            this.lblClearSearchCredential.Name = "lblClearSearchCredential";
            this.lblClearSearchCredential.Size = new System.Drawing.Size(15, 13);
            this.lblClearSearchCredential.TabIndex = 25;
            this.lblClearSearchCredential.Text = "X";
            this.lblClearSearchCredential.Visible = false;
            this.lblClearSearchCredential.Click += new System.EventHandler(this.lblClearSearchCredential_Click);
            // 
            // grpCredential
            // 
            this.grpCredential.Controls.Add(this.lblClearSearchCredential);
            this.grpCredential.Controls.Add(this.txtSearchCredential);
            this.grpCredential.Controls.Add(this.btnSelectCredential);
            this.grpCredential.Controls.Add(this.dgvCredentials);
            this.grpCredential.Location = new System.Drawing.Point(513, 12);
            this.grpCredential.Name = "grpCredential";
            this.grpCredential.Size = new System.Drawing.Size(495, 359);
            this.grpCredential.TabIndex = 21;
            this.grpCredential.TabStop = false;
            this.grpCredential.Text = "Credential";
            this.grpCredential.Visible = false;
            // 
            // btnSelectCredential
            // 
            this.btnSelectCredential.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCredential.ImageList = this.imageList1;
            this.btnSelectCredential.Location = new System.Drawing.Point(182, 35);
            this.btnSelectCredential.Name = "btnSelectCredential";
            this.btnSelectCredential.Size = new System.Drawing.Size(139, 23);
            this.btnSelectCredential.TabIndex = 7;
            this.btnSelectCredential.Text = "Select Credential";
            this.btnSelectCredential.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelectCredential.UseVisualStyleBackColor = true;
            this.btnSelectCredential.Click += new System.EventHandler(this.btnSelectCredential_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "password32.png");
            // 
            // grpSelectCredential
            // 
            this.grpSelectCredential.Controls.Add(this.pictureBox1);
            this.grpSelectCredential.Controls.Add(this.label1);
            this.grpSelectCredential.Controls.Add(this.btnRemoveCredential);
            this.grpSelectCredential.Controls.Add(this.lblUsername);
            this.grpSelectCredential.Controls.Add(this.txtCredentialId);
            this.grpSelectCredential.Location = new System.Drawing.Point(12, 231);
            this.grpSelectCredential.Name = "grpSelectCredential";
            this.grpSelectCredential.Size = new System.Drawing.Size(495, 140);
            this.grpSelectCredential.TabIndex = 22;
            this.grpSelectCredential.TabStop = false;
            this.grpSelectCredential.Text = "Select a Credential";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 27);
            this.label1.TabIndex = 17;
            this.label1.Text = "If the Application Link has a Username and a Password, please select an existing " +
    "Credential by clicking on the button Select a Credential";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Links.Properties.Resources.Checked_40;
            this.pictureBox1.Location = new System.Drawing.Point(25, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // frmAddOrUpdateAppLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 432);
            this.Controls.Add(this.grpSelectCredential);
            this.Controls.Add(this.grpCredential);
            this.Controls.Add(this.grpAppLink);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddOrUpdateAppLinks";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpAppLink.ResumeLayout(false);
            this.grpAppLink.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredentials)).EndInit();
            this.grpCredential.ResumeLayout(false);
            this.grpCredential.PerformLayout();
            this.grpSelectCredential.ResumeLayout(false);
            this.grpSelectCredential.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbApplication;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCredential;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpAppLink;
        private System.Windows.Forms.TextBox txtCredentialId;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnRemoveCredential;
        private System.Windows.Forms.DataGridView dgvCredentials;
        private System.Windows.Forms.Button btnSelectCredential;
        private System.Windows.Forms.TextBox txtSearchCredential;
        private System.Windows.Forms.Label lblClearSearchCredential;
        private System.Windows.Forms.GroupBox grpCredential;
        private System.Windows.Forms.GroupBox grpSelectCredential;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}