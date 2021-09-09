namespace Links.Forms
{
    partial class frmAddOrUpdateCountry
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCountryName = new System.Windows.Forms.TextBox();
            this.lblCountryName = new System.Windows.Forms.Label();
            this.lblCountryCode = new System.Windows.Forms.Label();
            this.txtCountryCode = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCountryName);
            this.groupBox1.Controls.Add(this.lblCountryName);
            this.groupBox1.Controls.Add(this.lblCountryCode);
            this.groupBox1.Controls.Add(this.txtCountryCode);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 110);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // txtCountryName
            // 
            this.txtCountryName.Location = new System.Drawing.Point(112, 60);
            this.txtCountryName.MaxLength = 150;
            this.txtCountryName.Name = "txtCountryName";
            this.txtCountryName.Size = new System.Drawing.Size(128, 20);
            this.txtCountryName.TabIndex = 2;
            // 
            // lblCountryName
            // 
            this.lblCountryName.AutoSize = true;
            this.lblCountryName.Location = new System.Drawing.Point(31, 63);
            this.lblCountryName.Name = "lblCountryName";
            this.lblCountryName.Size = new System.Drawing.Size(77, 13);
            this.lblCountryName.TabIndex = 0;
            this.lblCountryName.Text = "Country Name:";
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.AutoSize = true;
            this.lblCountryCode.Location = new System.Drawing.Point(31, 37);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(74, 13);
            this.lblCountryCode.TabIndex = 0;
            this.lblCountryCode.Text = "Country Code:";
            // 
            // txtCountryCode
            // 
            this.txtCountryCode.Location = new System.Drawing.Point(112, 34);
            this.txtCountryCode.MaxLength = 15;
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.Size = new System.Drawing.Size(71, 20);
            this.txtCountryCode.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(156, 131);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 43);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(56, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 43);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddOrUpdateCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 186);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddOrUpdateCountry";
            this.ShowIcon = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCountryName;
        private System.Windows.Forms.Label lblCountryName;
        private System.Windows.Forms.Label lblCountryCode;
        private System.Windows.Forms.TextBox txtCountryCode;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
    }
}