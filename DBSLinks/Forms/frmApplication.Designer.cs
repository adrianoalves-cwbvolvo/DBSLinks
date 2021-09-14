namespace Links.Forms
{
    partial class frmApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApplication));
            this.grpCountry = new System.Windows.Forms.GroupBox();
            this.btnDeleteApplication = new System.Windows.Forms.Button();
            this.imageListButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnEditApplication = new System.Windows.Forms.Button();
            this.btnNewApplication = new System.Windows.Forms.Button();
            this.lblClearSearchApplication = new System.Windows.Forms.Label();
            this.txtSearchApplication = new System.Windows.Forms.TextBox();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.grpCountry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCountry
            // 
            this.grpCountry.Controls.Add(this.btnDeleteApplication);
            this.grpCountry.Controls.Add(this.btnEditApplication);
            this.grpCountry.Controls.Add(this.btnNewApplication);
            this.grpCountry.Controls.Add(this.lblClearSearchApplication);
            this.grpCountry.Controls.Add(this.txtSearchApplication);
            this.grpCountry.Controls.Add(this.dgvApplications);
            this.grpCountry.Location = new System.Drawing.Point(9, 9);
            this.grpCountry.Name = "grpCountry";
            this.grpCountry.Size = new System.Drawing.Size(329, 270);
            this.grpCountry.TabIndex = 30;
            this.grpCountry.TabStop = false;
            // 
            // btnDeleteApplication
            // 
            this.btnDeleteApplication.Enabled = false;
            this.btnDeleteApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteApplication.ImageIndex = 2;
            this.btnDeleteApplication.ImageList = this.imageListButtons;
            this.btnDeleteApplication.Location = new System.Drawing.Point(280, 16);
            this.btnDeleteApplication.Name = "btnDeleteApplication";
            this.btnDeleteApplication.Size = new System.Drawing.Size(36, 35);
            this.btnDeleteApplication.TabIndex = 26;
            this.btnDeleteApplication.UseVisualStyleBackColor = true;
            this.btnDeleteApplication.Click += new System.EventHandler(this.btnDeleteApplication_Click);
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
            // 
            // btnEditApplication
            // 
            this.btnEditApplication.Enabled = false;
            this.btnEditApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditApplication.ImageIndex = 1;
            this.btnEditApplication.ImageList = this.imageListButtons;
            this.btnEditApplication.Location = new System.Drawing.Point(238, 16);
            this.btnEditApplication.Name = "btnEditApplication";
            this.btnEditApplication.Size = new System.Drawing.Size(36, 35);
            this.btnEditApplication.TabIndex = 27;
            this.btnEditApplication.UseVisualStyleBackColor = true;
            this.btnEditApplication.Click += new System.EventHandler(this.btnEditApplication_Click);
            // 
            // btnNewApplication
            // 
            this.btnNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewApplication.ImageIndex = 0;
            this.btnNewApplication.ImageList = this.imageListButtons;
            this.btnNewApplication.Location = new System.Drawing.Point(196, 16);
            this.btnNewApplication.Name = "btnNewApplication";
            this.btnNewApplication.Size = new System.Drawing.Size(36, 35);
            this.btnNewApplication.TabIndex = 28;
            this.btnNewApplication.UseVisualStyleBackColor = true;
            this.btnNewApplication.Click += new System.EventHandler(this.btnNewApplication_Click);
            // 
            // lblClearSearchApplication
            // 
            this.lblClearSearchApplication.AutoSize = true;
            this.lblClearSearchApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearSearchApplication.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClearSearchApplication.Location = new System.Drawing.Point(158, 34);
            this.lblClearSearchApplication.Name = "lblClearSearchApplication";
            this.lblClearSearchApplication.Size = new System.Drawing.Size(15, 13);
            this.lblClearSearchApplication.TabIndex = 25;
            this.lblClearSearchApplication.Text = "X";
            this.lblClearSearchApplication.Visible = false;
            this.lblClearSearchApplication.Click += new System.EventHandler(this.lblClearSearchApplication_Click);
            // 
            // txtSearchApplication
            // 
            this.txtSearchApplication.Location = new System.Drawing.Point(13, 31);
            this.txtSearchApplication.Name = "txtSearchApplication";
            this.txtSearchApplication.Size = new System.Drawing.Size(164, 20);
            this.txtSearchApplication.TabIndex = 24;
            this.txtSearchApplication.TextChanged += new System.EventHandler(this.txtSearchApplication_TextChanged);
            // 
            // dgvApplications
            // 
            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.AllowUserToOrderColumns = true;
            this.dgvApplications.AllowUserToResizeColumns = false;
            this.dgvApplications.AllowUserToResizeRows = false;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.Location = new System.Drawing.Point(14, 57);
            this.dgvApplications.MultiSelect = false;
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.RowHeadersVisible = false;
            this.dgvApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplications.Size = new System.Drawing.Size(302, 196);
            this.dgvApplications.TabIndex = 6;
            this.dgvApplications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplications_CellClick);
            // 
            // frmApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 290);
            this.Controls.Add(this.grpCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApplication";
            this.ShowIcon = false;
            this.Text = "Data Admin = Applications";
            this.grpCountry.ResumeLayout(false);
            this.grpCountry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCountry;
        private System.Windows.Forms.Button btnDeleteApplication;
        private System.Windows.Forms.ImageList imageListButtons;
        private System.Windows.Forms.Button btnEditApplication;
        private System.Windows.Forms.Button btnNewApplication;
        private System.Windows.Forms.Label lblClearSearchApplication;
        private System.Windows.Forms.TextBox txtSearchApplication;
        private System.Windows.Forms.DataGridView dgvApplications;
    }
}