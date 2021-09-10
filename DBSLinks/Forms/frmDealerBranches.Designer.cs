namespace Links.Forms
{
    partial class frmDealerBranches
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDealerBranches));
            this.dgvDealer = new System.Windows.Forms.DataGridView();
            this.grpCountry = new System.Windows.Forms.GroupBox();
            this.btnDeleteDealer = new System.Windows.Forms.Button();
            this.imageListButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnEditDealer = new System.Windows.Forms.Button();
            this.btnNewDealer = new System.Windows.Forms.Button();
            this.lblClearSearchDealer = new System.Windows.Forms.Label();
            this.txtSearchDealer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealer)).BeginInit();
            this.grpCountry.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDealer
            // 
            this.dgvDealer.AllowUserToAddRows = false;
            this.dgvDealer.AllowUserToDeleteRows = false;
            this.dgvDealer.AllowUserToOrderColumns = true;
            this.dgvDealer.AllowUserToResizeColumns = false;
            this.dgvDealer.AllowUserToResizeRows = false;
            this.dgvDealer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDealer.Location = new System.Drawing.Point(14, 57);
            this.dgvDealer.MultiSelect = false;
            this.dgvDealer.Name = "dgvDealer";
            this.dgvDealer.ReadOnly = true;
            this.dgvDealer.RowHeadersVisible = false;
            this.dgvDealer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDealer.Size = new System.Drawing.Size(584, 196);
            this.dgvDealer.TabIndex = 6;
            this.dgvDealer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDealer_CellClick);
            // 
            // grpCountry
            // 
            this.grpCountry.Controls.Add(this.btnDeleteDealer);
            this.grpCountry.Controls.Add(this.btnEditDealer);
            this.grpCountry.Controls.Add(this.btnNewDealer);
            this.grpCountry.Controls.Add(this.lblClearSearchDealer);
            this.grpCountry.Controls.Add(this.txtSearchDealer);
            this.grpCountry.Controls.Add(this.dgvDealer);
            this.grpCountry.Location = new System.Drawing.Point(5, 7);
            this.grpCountry.Name = "grpCountry";
            this.grpCountry.Size = new System.Drawing.Size(614, 271);
            this.grpCountry.TabIndex = 35;
            this.grpCountry.TabStop = false;
            // 
            // btnDeleteDealer
            // 
            this.btnDeleteDealer.Enabled = false;
            this.btnDeleteDealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDealer.ImageIndex = 2;
            this.btnDeleteDealer.ImageList = this.imageListButtons;
            this.btnDeleteDealer.Location = new System.Drawing.Point(562, 16);
            this.btnDeleteDealer.Name = "btnDeleteDealer";
            this.btnDeleteDealer.Size = new System.Drawing.Size(36, 35);
            this.btnDeleteDealer.TabIndex = 26;
            this.btnDeleteDealer.UseVisualStyleBackColor = true;
            this.btnDeleteDealer.Click += new System.EventHandler(this.btnDeleteDealer_Click);
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
            // btnEditDealer
            // 
            this.btnEditDealer.Enabled = false;
            this.btnEditDealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDealer.ImageIndex = 1;
            this.btnEditDealer.ImageList = this.imageListButtons;
            this.btnEditDealer.Location = new System.Drawing.Point(520, 16);
            this.btnEditDealer.Name = "btnEditDealer";
            this.btnEditDealer.Size = new System.Drawing.Size(36, 35);
            this.btnEditDealer.TabIndex = 27;
            this.btnEditDealer.UseVisualStyleBackColor = true;
            this.btnEditDealer.Click += new System.EventHandler(this.btnEditDealer_Click);
            // 
            // btnNewDealer
            // 
            this.btnNewDealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDealer.ImageIndex = 0;
            this.btnNewDealer.ImageList = this.imageListButtons;
            this.btnNewDealer.Location = new System.Drawing.Point(478, 16);
            this.btnNewDealer.Name = "btnNewDealer";
            this.btnNewDealer.Size = new System.Drawing.Size(36, 35);
            this.btnNewDealer.TabIndex = 28;
            this.btnNewDealer.UseVisualStyleBackColor = true;
            this.btnNewDealer.Click += new System.EventHandler(this.btnNewDealer_Click);
            // 
            // lblClearSearchDealer
            // 
            this.lblClearSearchDealer.AutoSize = true;
            this.lblClearSearchDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearSearchDealer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClearSearchDealer.Location = new System.Drawing.Point(158, 34);
            this.lblClearSearchDealer.Name = "lblClearSearchDealer";
            this.lblClearSearchDealer.Size = new System.Drawing.Size(15, 13);
            this.lblClearSearchDealer.TabIndex = 25;
            this.lblClearSearchDealer.Text = "X";
            this.lblClearSearchDealer.Visible = false;
            this.lblClearSearchDealer.Click += new System.EventHandler(this.lblClearSearchDealer_Click);
            // 
            // txtSearchDealer
            // 
            this.txtSearchDealer.Location = new System.Drawing.Point(13, 31);
            this.txtSearchDealer.Name = "txtSearchDealer";
            this.txtSearchDealer.Size = new System.Drawing.Size(164, 20);
            this.txtSearchDealer.TabIndex = 24;
            this.txtSearchDealer.TextChanged += new System.EventHandler(this.txtSearchDealer_TextChanged);
            // 
            // frmDealerBranches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 288);
            this.Controls.Add(this.grpCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDealerBranches";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealer)).EndInit();
            this.grpCountry.ResumeLayout(false);
            this.grpCountry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDealer;
        private System.Windows.Forms.GroupBox grpCountry;
        private System.Windows.Forms.Button btnDeleteDealer;
        private System.Windows.Forms.ImageList imageListButtons;
        private System.Windows.Forms.Button btnEditDealer;
        private System.Windows.Forms.Button btnNewDealer;
        private System.Windows.Forms.Label lblClearSearchDealer;
        private System.Windows.Forms.TextBox txtSearchDealer;
    }
}