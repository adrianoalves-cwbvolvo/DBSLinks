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
            this.btnDeleteDealerBranch = new System.Windows.Forms.Button();
            this.imageListButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnEditDealerBranch = new System.Windows.Forms.Button();
            this.btnNewDealerBranch = new System.Windows.Forms.Button();
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
            this.grpCountry.Controls.Add(this.btnDeleteDealerBranch);
            this.grpCountry.Controls.Add(this.btnEditDealerBranch);
            this.grpCountry.Controls.Add(this.btnNewDealerBranch);
            this.grpCountry.Controls.Add(this.lblClearSearchDealer);
            this.grpCountry.Controls.Add(this.txtSearchDealer);
            this.grpCountry.Controls.Add(this.dgvDealer);
            this.grpCountry.Location = new System.Drawing.Point(5, 7);
            this.grpCountry.Name = "grpCountry";
            this.grpCountry.Size = new System.Drawing.Size(614, 269);
            this.grpCountry.TabIndex = 35;
            this.grpCountry.TabStop = false;
            // 
            // btnDeleteDealerBranch
            // 
            this.btnDeleteDealerBranch.Enabled = false;
            this.btnDeleteDealerBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDealerBranch.ImageIndex = 2;
            this.btnDeleteDealerBranch.ImageList = this.imageListButtons;
            this.btnDeleteDealerBranch.Location = new System.Drawing.Point(562, 16);
            this.btnDeleteDealerBranch.Name = "btnDeleteDealerBranch";
            this.btnDeleteDealerBranch.Size = new System.Drawing.Size(36, 35);
            this.btnDeleteDealerBranch.TabIndex = 26;
            this.btnDeleteDealerBranch.UseVisualStyleBackColor = true;
            this.btnDeleteDealerBranch.Click += new System.EventHandler(this.btnDeleteDealer_Click);
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
            // btnEditDealerBranch
            // 
            this.btnEditDealerBranch.Enabled = false;
            this.btnEditDealerBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDealerBranch.ImageIndex = 1;
            this.btnEditDealerBranch.ImageList = this.imageListButtons;
            this.btnEditDealerBranch.Location = new System.Drawing.Point(520, 16);
            this.btnEditDealerBranch.Name = "btnEditDealerBranch";
            this.btnEditDealerBranch.Size = new System.Drawing.Size(36, 35);
            this.btnEditDealerBranch.TabIndex = 27;
            this.btnEditDealerBranch.UseVisualStyleBackColor = true;
            this.btnEditDealerBranch.Click += new System.EventHandler(this.btnEditDealer_Click);
            // 
            // btnNewDealerBranch
            // 
            this.btnNewDealerBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDealerBranch.ImageIndex = 0;
            this.btnNewDealerBranch.ImageList = this.imageListButtons;
            this.btnNewDealerBranch.Location = new System.Drawing.Point(478, 16);
            this.btnNewDealerBranch.Name = "btnNewDealerBranch";
            this.btnNewDealerBranch.Size = new System.Drawing.Size(36, 35);
            this.btnNewDealerBranch.TabIndex = 28;
            this.btnNewDealerBranch.UseVisualStyleBackColor = true;
            this.btnNewDealerBranch.Click += new System.EventHandler(this.btnNewDealer_Click);
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
            this.ClientSize = new System.Drawing.Size(631, 285);
            this.Controls.Add(this.grpCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDealerBranches";
            this.ShowIcon = false;
            this.Text = "Data Admin = Dealer (Partner Branches)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealer)).EndInit();
            this.grpCountry.ResumeLayout(false);
            this.grpCountry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDealer;
        private System.Windows.Forms.GroupBox grpCountry;
        private System.Windows.Forms.Button btnDeleteDealerBranch;
        private System.Windows.Forms.ImageList imageListButtons;
        private System.Windows.Forms.Button btnEditDealerBranch;
        private System.Windows.Forms.Button btnNewDealerBranch;
        private System.Windows.Forms.Label lblClearSearchDealer;
        private System.Windows.Forms.TextBox txtSearchDealer;
    }
}