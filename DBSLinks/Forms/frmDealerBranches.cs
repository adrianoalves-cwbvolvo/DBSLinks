using Links.Logger;
using LinksForm.Controller;
using LinksForm.DAL;
using LinksForm.Forms;
using LinksForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Links.Forms
{
    public partial class frmDealerBranches : Form
    {
        private List<DealerBranch> dealerBranchesList = new List<DealerBranch>();
        private DataTable dtDealers = new DataTable();
        private string FilteDealerField = "StringToSearch";

        private int left, top, width, height;

        public frmDealerBranches(int _left, int _top, int _width, int _height)
        {
            left = _left;
            top = _top;
            width = _width;
            height = _height;

            InitializeComponent();

            left = (left - 160) + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            StyleCountryButtons();

            dtDealers.Columns.Add("BranchId", typeof(string));
            dtDealers.Columns.Add("CTDI", typeof(string));
            dtDealers.Columns.Add("Dealer", typeof(string));
            dtDealers.Columns.Add("Branch", typeof(string));
            dtDealers.Columns.Add("Phone Number", typeof(string));
            dtDealers.Columns.Add("BaldoPartner", typeof(string));
            dtDealers.Columns.Add("CountryId", typeof(string));
            dtDealers.Columns.Add("Country", typeof(string));
            dtDealers.Columns.Add("DealerId", typeof(string));
            dtDealers.Columns.Add("StringToSearch", typeof(string));
            dtDealers.Columns.Add("Sort", typeof(string));

            loadDealerBranches();
        }

        private void dgvDealer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditDealerBranch.Enabled = true;
            btnDeleteDealerBranch.Enabled = true;
        }

        private void txtSearchDealer_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;

            oldText = txtSearchDealer.Text;

            if ((txtSearchDealer.Text.All(chr => char.IsLetterOrDigit(chr))) || (txtSearchDealer.Text.Contains(" ")) || (txtSearchDealer.Text.Contains("-")) || (txtSearchDealer.Text.Contains(".")))
            {
                txtSearchDealer.Text = oldText;
            }
            else
            {
                txtSearchDealer.Text = oldText.Remove(oldText.Length - 1);
            }

            txtSearchDealer.SelectionStart = txtSearchDealer.Text.Length;

            dtDealers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilteDealerField, txtSearchDealer.Text);

            if (string.IsNullOrEmpty(txtSearchDealer.Text))
            {
                lblClearSearchDealer.Visible = false;
            }
            else
            {
                lblClearSearchDealer.Visible = true;
            }
        }

        private void btnNewDealer_Click(object sender, EventArgs e)
        {
            bool hasTheSaveButtonPressed = false;

            DealerBranch dealerBranch = new DealerBranch();

            frmAddOrUpdateDealerBranch _frmAddOrUpdateDealerBranch = new frmAddOrUpdateDealerBranch(dealerBranch);
            _frmAddOrUpdateDealerBranch.TopMost = true;
            _frmAddOrUpdateDealerBranch.StartPosition = FormStartPosition.CenterParent;
            _frmAddOrUpdateDealerBranch.ShowDialog();

            hasTheSaveButtonPressed = _frmAddOrUpdateDealerBranch.hasTheSaveButtonPressed;

            if (hasTheSaveButtonPressed == true)
            {
                Validation.LocalDatabaseConfig(true);
                //databaseViewModel = Services.GetDataFromDatabase();
                dealerBranchesList = loadDealerBranches();
            }

            dgvDealer.ClearSelection();
            txtSearchDealer.Clear();
            btnEditDealerBranch.Enabled = false;
            btnDeleteDealerBranch.Enabled = false;

            _frmAddOrUpdateDealerBranch.Dispose();
        }

        private void btnEditDealer_Click(object sender, EventArgs e)
        {
            if ((dgvDealer.Rows.Count > 0))
            {
                DealerBranch dealerBranch = new DealerBranch();

                bool hasTheSaveButtonPressed = false;

                dealerBranch.DealerBranchId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[0].Value.ToString());
                dealerBranch.CTDI = Convert.ToInt32(dgvDealer.CurrentRow.Cells[1].Value.ToString());
                dealerBranch.DealerName = dgvDealer.CurrentRow.Cells[2].Value.ToString();
                dealerBranch.BranchName = dgvDealer.CurrentRow.Cells[3].Value.ToString();
                dealerBranch.PhoneNumber = dgvDealer.CurrentRow.Cells[4].Value.ToString();
                dealerBranch.BaldoPartner = dgvDealer.CurrentRow.Cells[5].Value.ToString();
                dealerBranch.CountryId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[6].Value.ToString());
                dealerBranch.CountryName = dgvDealer.CurrentRow.Cells[7].Value.ToString();
                dealerBranch.DealerId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[8].Value.ToString());

                frmAddOrUpdateDealerBranch _frmAddOrUpdateDealerBranch = new frmAddOrUpdateDealerBranch(dealerBranch);
                this.TopMost = false;
                _frmAddOrUpdateDealerBranch.StartPosition = FormStartPosition.CenterParent;
                _frmAddOrUpdateDealerBranch.ShowDialog();

                hasTheSaveButtonPressed = _frmAddOrUpdateDealerBranch.hasTheSaveButtonPressed;

                if (hasTheSaveButtonPressed == true)
                {
                    Validation.LocalDatabaseConfig(true);
                    //databaseViewModel = Services.GetDataFromDatabase();
                    dealerBranchesList = loadDealerBranches();
                }

                dgvDealer.ClearSelection();
                txtSearchDealer.Clear();
                btnEditDealerBranch.Enabled = false;
                btnDeleteDealerBranch.Enabled = false;

                _frmAddOrUpdateDealerBranch.Dispose();
            }
        }

        private void btnDeleteDealer_Click(object sender, EventArgs e)
        {
            if (dgvDealer.Rows.Count > 0)
            {

                DealerBranch dealerBranch = new DealerBranch();

                dealerBranch.DealerBranchId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[0].Value.ToString());
                dealerBranch.CTDI = Convert.ToInt32(dgvDealer.CurrentRow.Cells[1].Value.ToString());
                dealerBranch.DealerName = dgvDealer.CurrentRow.Cells[2].Value.ToString();
                dealerBranch.BranchName = dgvDealer.CurrentRow.Cells[3].Value.ToString();
                dealerBranch.PhoneNumber = dgvDealer.CurrentRow.Cells[4].Value.ToString();
                dealerBranch.BaldoPartner = dgvDealer.CurrentRow.Cells[5].Value.ToString();
                dealerBranch.CountryId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[6].Value.ToString());
                dealerBranch.CountryName = dgvDealer.CurrentRow.Cells[7].Value.ToString();
                dealerBranch.DealerId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[8].Value.ToString());

                if (MessageBox.Show("Are you sure you want to delete the Dealer Branch: " + dealerBranch.BranchName + "?", "Delete Dealer Branch", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DALHelpers.DeleteDealerBranch(dealerBranch.DealerBranchId);

                    ActivityLog.DealerBranchLogger(dealerBranch, "DELETE", "Dealer Branch", Environment.UserName);

                    Validation.LocalDatabaseConfig(true);
                    dealerBranchesList = loadDealerBranches();
                }

                dgvDealer.ClearSelection();
                txtSearchDealer.Clear();
                btnDeleteDealerBranch.Enabled = false;
                btnEditDealerBranch.Enabled = false;
            }
        }

        private void lblClearSearchDealer_Click(object sender, EventArgs e)
        {
            txtSearchDealer.Clear();
        }


        public List<DealerBranch> loadDealerBranches()
        {
            dgvDealer.DataSource = null;
            dgvDealer.Rows.Clear();
            dtDealers.Clear();

            dealerBranchesList = DALHelpers.GetDealerBranchs();

            foreach (DealerBranch dealer in dealerBranchesList)
            {
                dtDealers.Rows.Add(
                    dealer.DealerBranchId.ToString(),
                    dealer.CTDI.ToString(),
                    dealer.DealerName.ToString(),
                    dealer.BranchName.ToString(),
                    dealer.PhoneNumber.ToString(),
                    dealer.BaldoPartner.ToString(),
                    dealer.CountryId.ToString(),
                    dealer.CountryName.ToString(),
                    dealer.DealerId.ToString(),
                    dealer.CTDI.ToString() + dealer.PhoneNumber.ToString() + dealer.BaldoPartner.ToString() + dealer.CountryName.ToString() + dealer.DealerName.ToString() + Validation.RemoveDiacritics(dealer.DealerName.ToString()) + dealer.BranchName.ToString() + Validation.RemoveDiacritics(dealer.BranchName.ToString()),
                    dealer.DealerName.ToString() + dealer.BranchName.ToString());
            }

            dgvDealer.DataSource = dtDealers;

            dgvDealer.Columns[0].Visible = false;
            dgvDealer.Columns[6].Visible = false;
            dgvDealer.Columns[8].Visible = false;
            dgvDealer.Columns[9].Visible = false;
            dgvDealer.Columns[10].Visible = false;

            dgvDealer.Columns[1].Width = 50;
            dgvDealer.Columns[2].Width = 150;
            dgvDealer.Columns[3].Width = 150;
            dgvDealer.Columns[4].Width = 110;
            dgvDealer.Columns[5].Width = 70;
            dgvDealer.Columns[7].Width = 70;

            dgvDealer.Sort(dgvDealer.Columns["Sort"], ListSortDirection.Ascending);

            dgvDealer.ClearSelection();

            return dealerBranchesList;
        }

        private void StyleCountryButtons()
        {
            btnNewDealerBranch.TabStop = false;
            btnNewDealerBranch.FlatStyle = FlatStyle.Flat;
            btnNewDealerBranch.FlatAppearance.BorderSize = 0;

            btnEditDealerBranch.TabStop = false;
            btnEditDealerBranch.FlatStyle = FlatStyle.Flat;
            btnEditDealerBranch.FlatAppearance.BorderSize = 0;

            btnDeleteDealerBranch.TabStop = false;
            btnDeleteDealerBranch.FlatStyle = FlatStyle.Flat;
            btnDeleteDealerBranch.FlatAppearance.BorderSize = 0;
        }
    }
}
