using Links.Logger;
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
    public partial class frmDealer : Form
    {
        private List<Dealer> dealerlList = new List<Dealer>();
        private DataTable dtDealers= new DataTable();
        private string FilteDealerField = "StringToSearch";

        private int left, top, width, height;

        public frmDealer(int _left, int _top, int _width, int _height)
        {
            left = _left;
            top = _top;
            width = _width;
            height = _height;

            InitializeComponent();

            left = (left - 100) + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            StyleCountryButtons();

            dtDealers.Columns.Add("DealerId", typeof(int));
            dtDealers.Columns.Add("Dealer Name", typeof(string));
            dtDealers.Columns.Add("CountryId", typeof(int));
            dtDealers.Columns.Add("Country Name", typeof(string));
            dtDealers.Columns.Add("StringToSearch", typeof(string));

            dealerlList = loadDealers();

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

        private void lblClearSearchDealer_Click(object sender, EventArgs e)
        {
            txtSearchDealer.Clear();
        }

        private void btnNewDealer_Click(object sender, EventArgs e)
        {
            bool HasTheCancelButtonPressed;

            Dealer dealer = new Dealer();

            frmAddOrUpdateDealer _frmAddOrUpdateDealer = new frmAddOrUpdateDealer(left, top, width, height, dealer);
            _frmAddOrUpdateDealer.TopMost = true;
            _frmAddOrUpdateDealer.ShowDialog();

            HasTheCancelButtonPressed = _frmAddOrUpdateDealer.HasTheCancelButtonPressed;

            if (HasTheCancelButtonPressed == false)
            {
                Validation.localDatabaseConfig(true);
                //databaseViewModel = Services.GetDataFromDatabase();
                dealerlList = loadDealers();
            }

            dgvDealer.ClearSelection();
            txtSearchDealer.Clear();
            btnEditDealer.Enabled = false;
            btnDeleteDealer.Enabled = false;

            _frmAddOrUpdateDealer.Dispose();
        }

        private void btnEditDealer_Click(object sender, EventArgs e)
        {
            if ((dgvDealer.Rows.Count > 0))
            {
                Dealer dealer = new Dealer();

                bool HasTheCancelButtonPressed;

                dealer.DealerId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[0].Value.ToString());
                dealer.DealerName = dgvDealer.CurrentRow.Cells[1].Value.ToString();
                dealer.CountryId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[2].Value.ToString());

                frmAddOrUpdateDealer _frmAddOrUpdateDealer = new frmAddOrUpdateDealer(left, top, width, height, dealer);
                this.TopMost = false;
                _frmAddOrUpdateDealer.StartPosition = FormStartPosition.CenterParent;
                _frmAddOrUpdateDealer.ShowDialog();

                HasTheCancelButtonPressed = _frmAddOrUpdateDealer.HasTheCancelButtonPressed;

                if (HasTheCancelButtonPressed == false)
                {
                    Validation.localDatabaseConfig(true);
                    //databaseViewModel = Services.GetDataFromDatabase();
                    dealerlList = loadDealers();
                }

                dgvDealer.ClearSelection();
                txtSearchDealer.Clear();
                btnEditDealer.Enabled = false;
                btnDeleteDealer.Enabled = false;

                _frmAddOrUpdateDealer.Dispose();

            }
        }

        private void btnDeleteDealer_Click(object sender, EventArgs e)
        {
            if (dgvDealer.Rows.Count > 0)
            {
                int DealerId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[0].Value.ToString());
                string DealerName = dgvDealer.CurrentRow.Cells[1].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete the Main Dealer: " + DealerName.ToString() + "?", "Delete Main Dealer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    var dealerList = new List<DealerBranch>();
                    dealerList = DALHelpers.GetDealerBranchByDealerId(DealerId);

                    if (dealerList.Count == 0)
                    {
                        Dealer dealer = new Dealer();

                        dealer.DealerId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[0].Value.ToString());
                        dealer.CountryName = dgvDealer.CurrentRow.Cells[1].Value.ToString();
                        dealer.CountryId = Convert.ToInt32(dgvDealer.CurrentRow.Cells[2].Value.ToString());

                        DALHelpers.DeleteMainDealer(DealerId);

                        ActivityLog.DealerLogger(dealer, "DELETE", "Main Dealer", Environment.UserName);

                        Validation.localDatabaseConfig(true);
                        //databaseViewModel = Services.GetDataFromDatabase();
                        dealerlList = loadDealers();
                    }
                    else
                    {
                        MessageBox.Show("Unable to Delete the Main Dealer: " + DealerName.ToString() + ". Found " + dealerList.Count + " Dealer Branches created for this Main Dealer","Unable to Delete the Main Dealer!",MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    }
                }

                dgvDealer.ClearSelection();
                txtSearchDealer.Clear();
                btnEditDealer.Enabled = false;
                btnDeleteDealer.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<Dealer> loadDealers()
        {
            var dealerlList = new List<Dealer>();

            dealerlList = DALHelpers.GetDealers();

            dgvDealer.DataSource = null;
            dgvDealer.Rows.Clear();
            dtDealers.Clear();

            foreach (Dealer dealer in dealerlList)
            {
                dtDealers.Rows.Add(

                    dealer.DealerId.ToString(),
                    dealer.DealerName.ToString(),
                    dealer.CountryId.ToString(),
                    dealer.CountryName.ToString(),
                    dealer.DealerName.ToString() + dealer.CountryId.ToString() + dealer.CountryName.ToString());
            }

            dgvDealer.DataSource = dtDealers;

            dgvDealer.Columns[1].Width = 300;
            dgvDealer.Columns[3].Width = 100;
      
            dgvDealer.Columns[0].Visible = false;
            dgvDealer.Columns[2].Visible = false;
            dgvDealer.Columns[4].Visible = false;

            dgvDealer.Sort(dgvDealer.Columns["Country Name"], ListSortDirection.Ascending);

            return dealerlList;
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
