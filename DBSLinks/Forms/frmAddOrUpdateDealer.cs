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
    public partial class frmAddOrUpdateDealer : Form
    {
        public bool hasTheSaveButtonPressed { get; set; }
        int GlobalDealerId;

        List<Country> countryList = new List<Country>();
        public frmAddOrUpdateDealer(Dealer dealer)
        {
            InitializeComponent();

            GlobalDealerId = dealer.DealerId;

            countryList = DALHelpers.GetCountries();

            hasTheSaveButtonPressed = false;

            int counter = 0;

            if (dealer.DealerId != 0)
            {
                foreach (Country _country in countryList)
                {
                    cmbCountries.Items.Add(_country.CountryName.ToString());

                    if (dealer.CountryId == _country.CountryId)
                    {
                        cmbCountries.SelectedIndex = counter;
                    }
                    counter++;
                }

                counter = 0;

                this.Text = "Update Dealer";
                txtDealerName.Text = dealer.DealerName;
            }
            else
            {
                foreach (Country country in countryList)
                {
                    cmbCountries.Items.Add(country.CountryName.ToString());
                }

                counter = 0;

                this.Text = "New Dealer";
            }

            cmbCountries.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            hasTheSaveButtonPressed = true;

            Dealer dealer = new Dealer();
            bool ok = false;

            if (Validation.DealerDataValidation(txtDealerName.Text, cmbCountries.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            foreach (Country country in countryList)
            {
                if (cmbCountries.Text == country.CountryName)
                {
                    dealer.CountryId = country.CountryId;
                }
            }

            dealer.DealerName = txtDealerName.Text;

            if (GlobalDealerId != 0)
            {
                dealer.DealerId = GlobalDealerId;
                //UPDATE
                ok = DALHelpers.UpdateMainDealer(dealer);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the Dealer Contact!");
                }

                ActivityLog.DealerLogger(dealer, "UPDATE", "Main Dealer", Environment.UserName);
                this.Close();
            }
            else //NEW MAIN DEALER
            {

                ok = DALHelpers.AddMainDealer(dealer);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }

                ActivityLog.DealerLogger(dealer, "CREATE", "Main Dealer", Environment.UserName);
                this.Close();
            }
        }

        private void cmbCountries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDealerName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
