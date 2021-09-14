namespace Links.Forms
{
    partial class frmCountry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCountry));
            this.grpCountry = new System.Windows.Forms.GroupBox();
            this.btnDeleteCountry = new System.Windows.Forms.Button();
            this.imageListButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnEditCountry = new System.Windows.Forms.Button();
            this.btnNewCountry = new System.Windows.Forms.Button();
            this.lblClearSearchCountry = new System.Windows.Forms.Label();
            this.txtSearchCountry = new System.Windows.Forms.TextBox();
            this.dgvCountries = new System.Windows.Forms.DataGridView();
            this.grpCountry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountries)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCountry
            // 
            this.grpCountry.Controls.Add(this.btnDeleteCountry);
            this.grpCountry.Controls.Add(this.btnEditCountry);
            this.grpCountry.Controls.Add(this.btnNewCountry);
            this.grpCountry.Controls.Add(this.lblClearSearchCountry);
            this.grpCountry.Controls.Add(this.txtSearchCountry);
            this.grpCountry.Controls.Add(this.dgvCountries);
            this.grpCountry.Location = new System.Drawing.Point(9, 3);
            this.grpCountry.Name = "grpCountry";
            this.grpCountry.Size = new System.Drawing.Size(358, 270);
            this.grpCountry.TabIndex = 28;
            this.grpCountry.TabStop = false;
            // 
            // btnDeleteCountry
            // 
            this.btnDeleteCountry.Enabled = false;
            this.btnDeleteCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCountry.ImageIndex = 2;
            this.btnDeleteCountry.ImageList = this.imageListButtons;
            this.btnDeleteCountry.Location = new System.Drawing.Point(308, 16);
            this.btnDeleteCountry.Name = "btnDeleteCountry";
            this.btnDeleteCountry.Size = new System.Drawing.Size(36, 35);
            this.btnDeleteCountry.TabIndex = 26;
            this.btnDeleteCountry.UseVisualStyleBackColor = true;
            this.btnDeleteCountry.Click += new System.EventHandler(this.btnDeleteCountry_Click);
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
            // btnEditCountry
            // 
            this.btnEditCountry.Enabled = false;
            this.btnEditCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCountry.ImageIndex = 1;
            this.btnEditCountry.ImageList = this.imageListButtons;
            this.btnEditCountry.Location = new System.Drawing.Point(266, 16);
            this.btnEditCountry.Name = "btnEditCountry";
            this.btnEditCountry.Size = new System.Drawing.Size(36, 35);
            this.btnEditCountry.TabIndex = 27;
            this.btnEditCountry.UseVisualStyleBackColor = true;
            this.btnEditCountry.Click += new System.EventHandler(this.btnEditCountry_Click);
            // 
            // btnNewCountry
            // 
            this.btnNewCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCountry.ImageIndex = 0;
            this.btnNewCountry.ImageList = this.imageListButtons;
            this.btnNewCountry.Location = new System.Drawing.Point(224, 16);
            this.btnNewCountry.Name = "btnNewCountry";
            this.btnNewCountry.Size = new System.Drawing.Size(36, 35);
            this.btnNewCountry.TabIndex = 28;
            this.btnNewCountry.UseVisualStyleBackColor = true;
            this.btnNewCountry.Click += new System.EventHandler(this.btnNewCountry_Click);
            // 
            // lblClearSearchCountry
            // 
            this.lblClearSearchCountry.AutoSize = true;
            this.lblClearSearchCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearSearchCountry.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClearSearchCountry.Location = new System.Drawing.Point(158, 34);
            this.lblClearSearchCountry.Name = "lblClearSearchCountry";
            this.lblClearSearchCountry.Size = new System.Drawing.Size(15, 13);
            this.lblClearSearchCountry.TabIndex = 25;
            this.lblClearSearchCountry.Text = "X";
            this.lblClearSearchCountry.Visible = false;
            this.lblClearSearchCountry.Click += new System.EventHandler(this.lblClearSearchCountry_Click);
            // 
            // txtSearchCountry
            // 
            this.txtSearchCountry.Location = new System.Drawing.Point(13, 31);
            this.txtSearchCountry.Name = "txtSearchCountry";
            this.txtSearchCountry.Size = new System.Drawing.Size(164, 20);
            this.txtSearchCountry.TabIndex = 24;
            this.txtSearchCountry.TextChanged += new System.EventHandler(this.txtSearchCountry_TextChanged);
            // 
            // dgvCountries
            // 
            this.dgvCountries.AllowUserToAddRows = false;
            this.dgvCountries.AllowUserToDeleteRows = false;
            this.dgvCountries.AllowUserToOrderColumns = true;
            this.dgvCountries.AllowUserToResizeColumns = false;
            this.dgvCountries.AllowUserToResizeRows = false;
            this.dgvCountries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountries.Location = new System.Drawing.Point(14, 57);
            this.dgvCountries.MultiSelect = false;
            this.dgvCountries.Name = "dgvCountries";
            this.dgvCountries.ReadOnly = true;
            this.dgvCountries.RowHeadersVisible = false;
            this.dgvCountries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCountries.Size = new System.Drawing.Size(330, 196);
            this.dgvCountries.TabIndex = 6;
            this.dgvCountries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountries_CellClick);
            // 
            // frmCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 281);
            this.Controls.Add(this.grpCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCountry";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Data Admin = Countries";
            this.grpCountry.ResumeLayout(false);
            this.grpCountry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCountry;
        private System.Windows.Forms.Button btnDeleteCountry;
        private System.Windows.Forms.Button btnEditCountry;
        private System.Windows.Forms.Button btnNewCountry;
        private System.Windows.Forms.Label lblClearSearchCountry;
        private System.Windows.Forms.TextBox txtSearchCountry;
        private System.Windows.Forms.DataGridView dgvCountries;
        private System.Windows.Forms.ImageList imageListButtons;
    }
}