namespace Links.Forms
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtDealerName = new System.Windows.Forms.TextBox();
            this.cmbCountries = new System.Windows.Forms.ComboBox();
            this.lblDealerName = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpSubDealer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSubDealer
            // 
            this.grpSubDealer.Controls.Add(this.label3);
            this.grpSubDealer.Controls.Add(this.txtDealerName);
            this.grpSubDealer.Controls.Add(this.cmbCountries);
            this.grpSubDealer.Controls.Add(this.lblDealerName);
            this.grpSubDealer.Location = new System.Drawing.Point(8, 8);
            this.grpSubDealer.Name = "grpSubDealer";
            this.grpSubDealer.Size = new System.Drawing.Size(512, 108);
            this.grpSubDealer.TabIndex = 19;
            this.grpSubDealer.TabStop = false;
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
            // txtDealerName
            // 
            this.txtDealerName.Location = new System.Drawing.Point(102, 63);
            this.txtDealerName.MaxLength = 200;
            this.txtDealerName.Name = "txtDealerName";
            this.txtDealerName.Size = new System.Drawing.Size(379, 20);
            this.txtDealerName.TabIndex = 2;
            // 
            // cmbCountries
            // 
            this.cmbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountries.FormattingEnabled = true;
            this.cmbCountries.Location = new System.Drawing.Point(102, 36);
            this.cmbCountries.Name = "cmbCountries";
            this.cmbCountries.Size = new System.Drawing.Size(151, 21);
            this.cmbCountries.TabIndex = 1;
            this.cmbCountries.SelectionChangeCommitted += new System.EventHandler(this.cmbCountries_SelectionChangeCommitted);
            // 
            // lblDealerName
            // 
            this.lblDealerName.AutoSize = true;
            this.lblDealerName.Location = new System.Drawing.Point(16, 66);
            this.lblDealerName.Name = "lblDealerName";
            this.lblDealerName.Size = new System.Drawing.Size(72, 13);
            this.lblDealerName.TabIndex = 0;
            this.lblDealerName.Text = "Dealer Name:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(268, 130);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 43);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(168, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 43);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddOrUpdateDealer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 184);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpSubDealer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddOrUpdateDealer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.grpSubDealer.ResumeLayout(false);
            this.grpSubDealer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSubDealer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDealerName;
        private System.Windows.Forms.ComboBox cmbCountries;
        private System.Windows.Forms.Label lblDealerName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
    }
}