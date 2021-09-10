using Links.Controller;
using Links.Logger;
using Links.Model.ModelView;
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
    public partial class frmCountry : Form
    {
        private List<Country> countryList = new List<Country>();
        private DataTable dtCountries = new DataTable();
        private string FilterContactField = "StringToSearch";

        //private DatabaseViewModel databaseViewModel = new DatabaseViewModel();

        private int left, top, width, height;

        public frmCountry(int _left, int _top, int _width, int _height)
        {
            left = _left;
            top = _top;
            width = _width;
            height = _height;

            InitializeComponent();

            left = (left -20) + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            StyleCountryButtons();

            dtCountries.Columns.Add("Country Code", typeof(int));
            dtCountries.Columns.Add("Country Name", typeof(string));
            dtCountries.Columns.Add("StringToSearch", typeof(string));

            countryList = loadCountries();
        }

        private void StyleCountryButtons()
        {
            btnNewCountry.TabStop = false;
            btnNewCountry.FlatStyle = FlatStyle.Flat;
            btnNewCountry.FlatAppearance.BorderSize = 0;

            btnEditCountry.TabStop = false;
            btnEditCountry.FlatStyle = FlatStyle.Flat;
            btnEditCountry.FlatAppearance.BorderSize = 0;

            btnDeleteCountry.TabStop = false;
            btnDeleteCountry.FlatStyle = FlatStyle.Flat;
            btnDeleteCountry.FlatAppearance.BorderSize = 0;
        }

        private List<Country> loadCountries()
        {
            var countryList = new List<Country>();

            countryList = DALHelpers.GetCountries();

            dgvCountries.DataSource = null;
            dgvCountries.Rows.Clear();
            dtCountries.Clear();

            foreach (Country country in countryList)
            {
                dtCountries.Rows.Add(

                    country.CountryId.ToString(),
                    country.CountryName.ToString(),
                    country.CountryId.ToString() + country.CountryName.ToString());
            }

            dgvCountries.DataSource = dtCountries;
            dgvCountries.Columns[0].Width = 100;
            dgvCountries.Columns[1].Width = 210;
            dgvCountries.Columns[2].Visible = false;

            dgvCountries.Columns["Country Code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCountries.Sort(dgvCountries.Columns["Country Code"], ListSortDirection.Ascending);

            return countryList;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchCountry_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;

            oldText = txtSearchCountry.Text;

            if ((txtSearchCountry.Text.All(chr => char.IsLetterOrDigit(chr))) || (txtSearchCountry.Text.Contains(" ")) || (txtSearchCountry.Text.Contains("-")) || (txtSearchCountry.Text.Contains(".")))
            {
                txtSearchCountry.Text = oldText;
            }
            else
            {
                txtSearchCountry.Text = oldText.Remove(oldText.Length - 1);
            }

            txtSearchCountry.SelectionStart = txtSearchCountry.Text.Length;

            dtCountries.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterContactField, txtSearchCountry.Text);

            if (string.IsNullOrEmpty(txtSearchCountry.Text))
            {
                lblClearSearchCountry.Visible = false;
            }
            else
            {
                lblClearSearchCountry.Visible = true;
            }
        }

        private void dgvCountries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditCountry.Enabled = true;
            btnDeleteCountry.Enabled = true;
        }

        private void lblClearSearchCountry_Click(object sender, EventArgs e)
        {
            txtSearchCountry.Clear();
        }

        private void btnNewCountry_Click(object sender, EventArgs e)
        {
            bool HasTheCancelButtonPressed;

            Country country = new Country();

            frmAddOrUpdateCountry _frmAddOrUpdateCountry = new frmAddOrUpdateCountry(left, top, width, height, country);
            _frmAddOrUpdateCountry.TopMost = true;
            _frmAddOrUpdateCountry.ShowDialog();

            HasTheCancelButtonPressed = _frmAddOrUpdateCountry.HasTheSaveButtonPressed;

            if (HasTheCancelButtonPressed == false)
            {
                Validation.localDatabaseConfig(true);
                //databaseViewModel = Services.GetDataFromDatabase();
                countryList = loadCountries();
            }

            dgvCountries.ClearSelection();
            txtSearchCountry.Clear();
            btnEditCountry.Enabled = false;
            btnDeleteCountry.Enabled = false;

            _frmAddOrUpdateCountry.Dispose();
        }

        private void btnEditCountry_Click(object sender, EventArgs e)
        {
            if ((dgvCountries.Rows.Count > 0))
            {
                Country country = new Country();
                bool HasTheCancelButtonPressed;

                country.CountryId = Convert.ToInt32(dgvCountries.CurrentRow.Cells[0].Value.ToString());
                country.CountryName = dgvCountries.CurrentRow.Cells[1].Value.ToString();

                frmAddOrUpdateCountry _frmAddOrUpdateCountry = new frmAddOrUpdateCountry(left, top, width, height, country);
                this.TopMost = false;
                _frmAddOrUpdateCountry.StartPosition = FormStartPosition.CenterParent;
                _frmAddOrUpdateCountry.ShowDialog();

                HasTheCancelButtonPressed = _frmAddOrUpdateCountry.HasTheSaveButtonPressed;

                if (HasTheCancelButtonPressed == false)
                {
                    Validation.localDatabaseConfig(true);
                    //databaseViewModel = Services.GetDataFromDatabase();
                    countryList = loadCountries();
                }

                dgvCountries.ClearSelection();
                txtSearchCountry.Clear();
                btnEditCountry.Enabled = false;
                btnDeleteCountry.Enabled = false;

                _frmAddOrUpdateCountry.Dispose();

            }
        }
        private void btnDeleteCountry_Click(object sender, EventArgs e)
        {
            if (dgvCountries.Rows.Count > 0)
            {
                int CountryId = Convert.ToInt32(dgvCountries.CurrentRow.Cells[0].Value.ToString());
                string CountryName = dgvCountries.CurrentRow.Cells[1].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete the country " + CountryId.ToString() + "?", "Delete Country", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var dealerList = new List<Dealer>();
                    var appLinksList = new List<AppLinks>();

                    dealerList = DALHelpers.GetDealersByCountry(CountryId);
                    appLinksList = DALHelpers.GetAppLinksByCountryId(CountryId);

                    if (countryList.Count == 0 || appLinksList.Count == 0)
                    {
                        Country country = new Country();

                        country.CountryId = Convert.ToInt32(dgvCountries.CurrentRow.Cells[0].Value.ToString());
                        country.CountryName = dgvCountries.CurrentRow.Cells[1].Value.ToString();

                        DALHelpers.DeleteCountry(CountryId);

                        ActivityLog.CountryLogger(country, "DELETE", "", 0, Environment.UserName);

                        Validation.localDatabaseConfig(true);
                        //databaseViewModel = Services.GetDataFromDatabase();
                        countryList = loadCountries();

                    }else                      
                    {
                        MessageBox.Show("Unable to Delete the Country: " + CountryName + ". This record is used by: " + dealerList.Count + " Main Dealers and " + appLinksList.Count + " Application Links.", "Unable to Delete the Main Dealer!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

                dgvCountries.ClearSelection();
                txtSearchCountry.Clear();
                btnDeleteCountry.Enabled = false;
                btnEditCountry.Enabled = false;
            }
        }
    }
}
