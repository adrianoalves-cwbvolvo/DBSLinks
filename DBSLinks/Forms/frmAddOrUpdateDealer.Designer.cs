namespace LinksForm.Forms
{
    partial class frmAddOrUpdateDealer
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
            this.grpSubDealer = new System.Windows.Forms.GroupBox();
            this.lblDealer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.cmbMainDealer = new System.Windows.Forms.ComboBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.cmbCountries = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtBaldoPartner = new System.Windows.Forms.TextBox();
            this.lblBaldoPartner = new System.Windows.Forms.Label();
            this.txtCTDI = new System.Windows.Forms.TextBox();
            this.lblCTDI = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpSubDealer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSubDealer
            // 
            this.grpSubDealer.Controls.Add(this.lblDealer);
            this.grpSubDealer.Controls.Add(this.label3);
            this.grpSubDealer.Controls.Add(this.txtPhoneNumber);
            this.grpSubDealer.Controls.Add(this.txtBranchName);
            this.grpSubDealer.Controls.Add(this.cmbMainDealer);
            this.grpSubDealer.Controls.Add(this.lblPhoneNumber);
            this.grpSubDealer.Controls.Add(this.cmbCountries);
            this.grpSubDealer.Controls.Add(this.lblBranch);
            this.grpSubDealer.Controls.Add(this.txtBaldoPartner);
            this.grpSubDealer.Controls.Add(this.lblBaldoPartner);
            this.grpSubDealer.Controls.Add(this.txtCTDI);
            this.grpSubDealer.Controls.Add(this.lblCTDI);
            this.grpSubDealer.Location = new System.Drawing.Point(12, 12);
            this.grpSubDealer.Name = "grpSubDealer";
            this.grpSubDealer.Size = new System.Drawing.Size(512, 211);
            this.grpSubDealer.TabIndex = 18;
            this.grpSubDealer.TabStop = false;
            // 
            // lblDealer
            // 
            this.lblDealer.AutoSize = true;
            this.lblDealer.Location = new System.Drawing.Point(16, 66);
            this.lblDealer.Name = "lblDealer";
            this.lblDealer.Size = new System.Drawing.Size(41, 13);
            this.lblDealer.TabIndex = 0;
            this.lblDealer.Text = "Dealer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Country:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(102, 116);
            this.txtPhoneNumber.MaxLength = 25;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(195, 20);
            this.txtPhoneNumber.TabIndex = 3;
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(102, 90);
            this.txtBranchName.MaxLength = 25;
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(379, 20);
            this.txtBranchName.TabIndex = 2;
            // 
            // cmbMainDealer
            // 
            this.cmbMainDealer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainDealer.FormattingEnabled = true;
            this.cmbMainDealer.Location = new System.Drawing.Point(102, 63);
            this.cmbMainDealer.Name = "cmbMainDealer";
            this.cmbMainDealer.Size = new System.Drawing.Size(379, 21);
            this.cmbMainDealer.TabIndex = 1;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(16, 119);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(81, 13);
            this.lblPhoneNumber.TabIndex = 0;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // cmbCountries
            // 
            this.cmbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountries.FormattingEnabled = true;
            this.cmbCountries.Location = new System.Drawing.Point(102, 36);
            this.cmbCountries.Name = "cmbCountries";
            this.cmbCountries.Size = new System.Drawing.Size(151, 21);
            this.cmbCountries.TabIndex = 1;
            this.cmbCountries.SelectedIndexChanged += new System.EventHandler(this.cmbCountries_SelectedIndexChanged);
            this.cmbCountries.SelectionChangeCommitted += new System.EventHandler(this.cmbCountries_SelectionChangeCommitted);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(16, 93);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(75, 13);
            this.lblBranch.TabIndex = 0;
            this.lblBranch.Text = "Branch Name:";
            // 
            // txtBaldoPartner
            // 
            this.txtBaldoPartner.Location = new System.Drawing.Point(102, 168);
            this.txtBaldoPartner.MaxLength = 5;
            this.txtBaldoPartner.Name = "txtBaldoPartner";
            this.txtBaldoPartner.Size = new System.Drawing.Size(136, 20);
            this.txtBaldoPartner.TabIndex = 5;
            // 
            // lblBaldoPartner
            // 
            this.lblBaldoPartner.AutoSize = true;
            this.lblBaldoPartner.Location = new System.Drawing.Point(16, 172);
            this.lblBaldoPartner.Name = "lblBaldoPartner";
            this.lblBaldoPartner.Size = new System.Drawing.Size(74, 13);
            this.lblBaldoPartner.TabIndex = 0;
            this.lblBaldoPartner.Text = "Baldo Partner:";
            // 
            // txtCTDI
            // 
            this.txtCTDI.Location = new System.Drawing.Point(102, 142);
            this.txtCTDI.MaxLength = 5;
            this.txtCTDI.Name = "txtCTDI";
            this.txtCTDI.Size = new System.Drawing.Size(76, 20);
            this.txtCTDI.TabIndex = 4;
            // 
            // lblCTDI
            // 
            this.lblCTDI.AutoSize = true;
            this.lblCTDI.Location = new System.Drawing.Point(16, 146);
            this.lblCTDI.Name = "lblCTDI";
            this.lblCTDI.Size = new System.Drawing.Size(35, 13);
            this.lblCTDI.TabIndex = 0;
            this.lblCTDI.Text = "CTDI:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(275, 238);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 43);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(175, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 43);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddOrUpdateDealer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 293);
            this.Controls.Add(this.grpSubDealer);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddOrUpdateDealer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpSubDealer.ResumeLayout(false);
            this.grpSubDealer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSubDealer;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.TextBox txtCTDI;
        private System.Windows.Forms.Label lblCTDI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCountries;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDealer;
        private System.Windows.Forms.ComboBox cmbMainDealer;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtBaldoPartner;
        private System.Windows.Forms.Label lblBaldoPartner;
    }
}