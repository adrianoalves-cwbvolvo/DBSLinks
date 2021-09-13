namespace Links.Forms
{
    partial class frmCredential
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCredential));
            this.dgvCredentials = new System.Windows.Forms.DataGridView();
            this.grpCountry = new System.Windows.Forms.GroupBox();
            this.btnDeleteCredential = new System.Windows.Forms.Button();
            this.imageListButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnEditCredential = new System.Windows.Forms.Button();
            this.btnNewCredential = new System.Windows.Forms.Button();
            this.lblClearSearchCredential = new System.Windows.Forms.Label();
            this.txtSearchCredential = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredentials)).BeginInit();
            this.grpCountry.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCredentials
            // 
            this.dgvCredentials.AllowUserToAddRows = false;
            this.dgvCredentials.AllowUserToDeleteRows = false;
            this.dgvCredentials.AllowUserToOrderColumns = true;
            this.dgvCredentials.AllowUserToResizeColumns = false;
            this.dgvCredentials.AllowUserToResizeRows = false;
            this.dgvCredentials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCredentials.Location = new System.Drawing.Point(14, 57);
            this.dgvCredentials.MultiSelect = false;
            this.dgvCredentials.Name = "dgvCredentials";
            this.dgvCredentials.ReadOnly = true;
            this.dgvCredentials.RowHeadersVisible = false;
            this.dgvCredentials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCredentials.Size = new System.Drawing.Size(489, 196);
            this.dgvCredentials.TabIndex = 6;
            this.dgvCredentials.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCredentials_CellClick);
            // 
            // grpCountry
            // 
            this.grpCountry.Controls.Add(this.btnDeleteCredential);
            this.grpCountry.Controls.Add(this.btnEditCredential);
            this.grpCountry.Controls.Add(this.btnNewCredential);
            this.grpCountry.Controls.Add(this.lblClearSearchCredential);
            this.grpCountry.Controls.Add(this.txtSearchCredential);
            this.grpCountry.Controls.Add(this.dgvCredentials);
            this.grpCountry.Location = new System.Drawing.Point(9, 7);
            this.grpCountry.Name = "grpCountry";
            this.grpCountry.Size = new System.Drawing.Size(516, 268);
            this.grpCountry.TabIndex = 31;
            this.grpCountry.TabStop = false;
            // 
            // btnDeleteCredential
            // 
            this.btnDeleteCredential.Enabled = false;
            this.btnDeleteCredential.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCredential.ImageIndex = 2;
            this.btnDeleteCredential.ImageList = this.imageListButtons;
            this.btnDeleteCredential.Location = new System.Drawing.Point(466, 16);
            this.btnDeleteCredential.Name = "btnDeleteCredential";
            this.btnDeleteCredential.Size = new System.Drawing.Size(36, 35);
            this.btnDeleteCredential.TabIndex = 26;
            this.btnDeleteCredential.UseVisualStyleBackColor = true;
            this.btnDeleteCredential.Click += new System.EventHandler(this.btnDeleteCredential_Click);
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
            // btnEditCredential
            // 
            this.btnEditCredential.Enabled = false;
            this.btnEditCredential.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCredential.ImageIndex = 1;
            this.btnEditCredential.ImageList = this.imageListButtons;
            this.btnEditCredential.Location = new System.Drawing.Point(424, 16);
            this.btnEditCredential.Name = "btnEditCredential";
            this.btnEditCredential.Size = new System.Drawing.Size(36, 35);
            this.btnEditCredential.TabIndex = 27;
            this.btnEditCredential.UseVisualStyleBackColor = true;
            this.btnEditCredential.Click += new System.EventHandler(this.btnEditCredential_Click);
            // 
            // btnNewCredential
            // 
            this.btnNewCredential.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCredential.ImageIndex = 0;
            this.btnNewCredential.ImageList = this.imageListButtons;
            this.btnNewCredential.Location = new System.Drawing.Point(382, 16);
            this.btnNewCredential.Name = "btnNewCredential";
            this.btnNewCredential.Size = new System.Drawing.Size(36, 35);
            this.btnNewCredential.TabIndex = 28;
            this.btnNewCredential.UseVisualStyleBackColor = true;
            this.btnNewCredential.Click += new System.EventHandler(this.btnNewCredential_Click);
            // 
            // lblClearSearchCredential
            // 
            this.lblClearSearchCredential.AutoSize = true;
            this.lblClearSearchCredential.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearSearchCredential.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClearSearchCredential.Location = new System.Drawing.Point(158, 34);
            this.lblClearSearchCredential.Name = "lblClearSearchCredential";
            this.lblClearSearchCredential.Size = new System.Drawing.Size(15, 13);
            this.lblClearSearchCredential.TabIndex = 25;
            this.lblClearSearchCredential.Text = "X";
            this.lblClearSearchCredential.Visible = false;
            this.lblClearSearchCredential.Click += new System.EventHandler(this.lblClearSearchCredential_Click);
            // 
            // txtSearchCredential
            // 
            this.txtSearchCredential.Location = new System.Drawing.Point(13, 31);
            this.txtSearchCredential.Name = "txtSearchCredential";
            this.txtSearchCredential.Size = new System.Drawing.Size(164, 20);
            this.txtSearchCredential.TabIndex = 24;
            this.txtSearchCredential.TextChanged += new System.EventHandler(this.txtSearchCredential_TextChanged);
            // 
            // frmCredential
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 282);
            this.Controls.Add(this.grpCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCredential";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredentials)).EndInit();
            this.grpCountry.ResumeLayout(false);
            this.grpCountry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCredentials;
        private System.Windows.Forms.GroupBox grpCountry;
        private System.Windows.Forms.Button btnDeleteCredential;
        private System.Windows.Forms.ImageList imageListButtons;
        private System.Windows.Forms.Button btnEditCredential;
        private System.Windows.Forms.Button btnNewCredential;
        private System.Windows.Forms.Label lblClearSearchCredential;
        private System.Windows.Forms.TextBox txtSearchCredential;
    }
}