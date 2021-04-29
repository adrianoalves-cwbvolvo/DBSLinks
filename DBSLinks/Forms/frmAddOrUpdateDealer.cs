using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinksForm.Controller;
using LinksForm.DAL;
using LinksForm.Model;

namespace LinksForm.Forms
{
    public partial class frmAddOrUpdateDealer : Form
    {
        List<Dealer> dealerList = new List<Dealer>();
        List<Dealer> mainDealerList = new List<Dealer>();
        List<Country> countryList = new List<Country>();

        int CountryId;

        public bool HasTheCancelButtonPressed { get; set; }

        public frmAddOrUpdateDealer(Dealer dealer)
        {
            InitializeComponent();

            CountryId = dealer.CountryId;

            dealerList = DALHelpers.GetDealers();
            countryList = DALHelpers.GetCountries();

            HasTheCancelButtonPressed = false;

            int counter = 0;

            if (dealer.DealerId != 0)
            {
                foreach (Country country in countryList)
                {
                    cmbCountries.Items.Add(country.CountryName.ToString());

                    if (dealer.CountryId == country.CountryId)
                    {
                        cmbCountries.SelectedIndex = counter;
                    }

                    counter++;
                }

                this.Text = "Update Dealer Branch";
                txtBranchName.Text = dealer.DealerName;
                txtPhoneNumber.Text = dealer.PhoneNumber;
                txtCTDI.Text = dealer.CTDI;
                txtBaldoPartner.Text = dealer.BaldoPartner;
            }
            else
            {
                foreach (Country country in countryList)
                {
                    cmbCountries.Items.Add(country.CountryName.ToString());
                }

                this.Text = "New Dealer Brach";

            }

            cmbCountries.Focus();
        }
   
        private void btnExit_Click(object sender, EventArgs e)
        {
            HasTheCancelButtonPressed = true;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void cmbCountries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (Country country in countryList)
            {
                if (cmbCountries.SelectedItem.ToString() == country.CountryName)
                {
                    cmbMainDealer.Items.Clear();
                    mainDealerList.Clear();
                    mainDealerList = DALHelpers.GetMainDealersByCountry(country.CountryId);
                }
            }

            foreach (Dealer mainDealer in mainDealerList)
            {
                cmbMainDealer.Items.Add(mainDealer.DealerName.ToString());
            }
        }

        private void cmbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
