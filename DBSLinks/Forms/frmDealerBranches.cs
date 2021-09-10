using LinksForm.Controller;
using LinksForm.DAL;
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
            btnEditDealer.Enabled = true;
            btnDeleteDealer.Enabled = true;
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

        }

        private void btnEditDealer_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteDealer_Click(object sender, EventArgs e)
        {

        }

        private void lblClearSearchDealer_Click(object sender, EventArgs e)
        {
            txtSearchDealer.Clear();
        }


        public void loadDealerBranches()
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
        }


        private void StyleCountryButtons()
        {
            btnNewDealer.TabStop = false;
            btnNewDealer.FlatStyle = FlatStyle.Flat;
            btnNewDealer.FlatAppearance.BorderSize = 0;

            btnEditDealer.TabStop = false;
            btnEditDealer.FlatStyle = FlatStyle.Flat;
            btnEditDealer.FlatAppearance.BorderSize = 0;

            btnDeleteDealer.TabStop = false;
            btnDeleteDealer.FlatStyle = FlatStyle.Flat;
            btnDeleteDealer.FlatAppearance.BorderSize = 0;
        }
    }
}
