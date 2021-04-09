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
            this.label4 = new System.Windows.Forms.Label();
            this.cmbApplication = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOk = new System.Windows.Forms.Label();
            this.btnSelectCredential = new System.Windows.Forms.Button();
            this.dgvCredentials = new System.Windows.Forms.DataGridView();
            this.txtCredentialUsername = new System.Windows.Forms.TextBox();
            this.txtCredentialId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredentials)).BeginInit();
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
            this.cmbApplication.Size = new System.Drawing.Size(151, 21);
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
            this.cmbCategory.Size = new System.Drawing.Size(151, 21);
            this.cmbCategory.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(125, 143);
            this.txtDescription.MaxLength = 25;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(353, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Link Description:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(368, 256);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 43);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(268, 256);
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
            this.txtURL.MaxLength = 25;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbCountry);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtURL);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.cmbApplication);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 216);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "App Link";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOk);
            this.groupBox2.Controls.Add(this.btnSelectCredential);
            this.groupBox2.Controls.Add(this.dgvCredentials);
            this.groupBox2.Controls.Add(this.txtCredentialUsername);
            this.groupBox2.Location = new System.Drawing.Point(513, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 216);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credential";
            // 
            // lblOk
            // 
            this.lblOk.AutoSize = true;
            this.lblOk.Location = new System.Drawing.Point(174, 188);
            this.lblOk.Name = "lblOk";
            this.lblOk.Size = new System.Drawing.Size(22, 13);
            this.lblOk.TabIndex = 23;
            this.lblOk.Text = "OK";
            this.lblOk.Visible = false;
            // 
            // btnSelectCredential
            // 
            this.btnSelectCredential.Location = new System.Drawing.Point(8, 184);
            this.btnSelectCredential.Name = "btnSelectCredential";
            this.btnSelectCredential.Size = new System.Drawing.Size(62, 22);
            this.btnSelectCredential.TabIndex = 7;
            this.btnSelectCredential.Text = "Select";
            this.btnSelectCredential.UseVisualStyleBackColor = true;
            this.btnSelectCredential.Click += new System.EventHandler(this.btnSelectCredential_Click);
            // 
            // dgvCredentials
            // 
            this.dgvCredentials.AllowUserToAddRows = false;
            this.dgvCredentials.AllowUserToDeleteRows = false;
            this.dgvCredentials.AllowUserToOrderColumns = true;
            this.dgvCredentials.AllowUserToResizeColumns = false;
            this.dgvCredentials.AllowUserToResizeRows = false;
            this.dgvCredentials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCredentials.Location = new System.Drawing.Point(9, 19);
            this.dgvCredentials.MultiSelect = false;
            this.dgvCredentials.Name = "dgvCredentials";
            this.dgvCredentials.ReadOnly = true;
            this.dgvCredentials.RowHeadersVisible = false;
            this.dgvCredentials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCredentials.Size = new System.Drawing.Size(215, 159);
            this.dgvCredentials.TabIndex = 6;
            // 
            // txtCredentialUsername
            // 
            this.txtCredentialUsername.Enabled = false;
            this.txtCredentialUsername.Location = new System.Drawing.Point(72, 185);
            this.txtCredentialUsername.MaxLength = 25;
            this.txtCredentialUsername.Name = "txtCredentialUsername";
            this.txtCredentialUsername.Size = new System.Drawing.Size(96, 20);
            this.txtCredentialUsername.TabIndex = 8;
            // 
            // txtCredentialId
            // 
            this.txtCredentialId.Location = new System.Drawing.Point(574, 249);
            this.txtCredentialId.MaxLength = 25;
            this.txtCredentialId.Name = "txtCredentialId";
            this.txtCredentialId.Size = new System.Drawing.Size(130, 20);
            this.txtCredentialId.TabIndex = 22;
            this.txtCredentialId.Visible = false;
            // 
            // frmAddOrUpdateAppLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 311);
            this.Controls.Add(this.txtCredentialId);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddOrUpdateAppLinks";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddOrUpdateAppLinks_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredentials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbApplication;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCredentialUsername;
        private System.Windows.Forms.DataGridView dgvCredentials;
        private System.Windows.Forms.Button btnSelectCredential;
        private System.Windows.Forms.TextBox txtCredentialId;
        private System.Windows.Forms.Label lblOk;
    }
}