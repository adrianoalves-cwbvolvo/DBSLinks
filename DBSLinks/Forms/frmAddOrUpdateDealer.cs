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
        List<Dealer> mainDealerList = new List<Dealer>();
        List<Country> countryList = new List<Country>();
        private int GlobalDealerId;

        public frmAddOrUpdateDealer(int DealerId, string DealerCode, string DealerName, int CountryId)
        {
            InitializeComponent();

            GlobalDealerId = DealerId;

            #region "DEALER - UPDATE"

            if (!string.IsNullOrEmpty(DealerName))
            {
                int counter = 0;

                this.Text = "Update Dealer";
                txtDealerCode.Text = DealerCode;
                txtDealerName.Text = DealerName;

                countryList = DALHelpers.GetCountries();

                Dictionary<int, Dealer> comboDealer = new Dictionary<int, Dealer>();
                Dictionary<int, Country> comboBox = new Dictionary<int, Country>();

                foreach (Country country in countryList)
                {
                    cmbCountries.Items.Add(country.CountryName.ToString());
                    comboBox.Add(counter, country);

                    if (CountryId == country.CountryId)
                    {
                        cmbCountries.SelectedIndex = counter;
                    }

                    counter++;
                }
            }

            #endregion

            #region "DEALER - NEW"
            else
            {
                //LOAD DATA FOR NEW SUBDEALER
                countryList = DALHelpers.GetCountries();

                foreach (Country country in countryList)
                {
                    cmbCountries.Items.Add(country.CountryName.ToString());
                }
            }

            #endregion
        }

        #region "SAVE"
        private void btnSave_Click(object sender, EventArgs e)
        {
            Dealer dealer = new Dealer();
            bool ok = false;
            string comboCountries;

            comboCountries = cmbCountries.Text;

            if (Validation.DealerDataValidation(txtDealerCode.Text, txtDealerName.Text, comboCountries))
            {
                MessageBox.Show("Please enter the Dealer details.");
                return;
            }
            else
            {
                dealer.DealerName = txtDealerName.Text;
                dealer.DealerId = GlobalDealerId;

                foreach (Country country in countryList)
                {
                    if (cmbCountries.Text == country.CountryName)
                    {
                        dealer.CountryId = country.CountryId;
                    }
                }
            }

            #endregion

            #region "UPDATE"

            //UPDATE
            if (GlobalDealerId > 0)
            {

                //ok = DALHelpers.UpdateDealer(dealer);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the Dealer!");
                }

                this.Close();
            }

            #endregion

            #region "NEW"

            else
            {
                //NEW
                //ok = DALHelpers.AddDealer(dealer);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to add a new Dealer!");
                }

                this.Close();
            }

            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
