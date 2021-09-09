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
    public partial class frmAddOrUpdateCountry : Form
    {
        private int CountryID;
        private string CountryName;
        public bool HasTheCancelButtonPressed { get; set; }

        public frmAddOrUpdateCountry(int left, int top, int width, int height, Country country)
        {
            InitializeComponent();

            left = (left - 120) + (width / 4);
            top = (top - 20) + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            CountryID = country.CountryId;
            CountryName = country.CountryName;

            HasTheCancelButtonPressed = false;

            if (country.CountryId > 0)
            {
                this.Text = "Update Country";
                txtCountryCode.Text = country.CountryId.ToString();
                txtCountryName.Text = country.CountryName.ToString();

            }
            else
            {
                this.Text = "New Country";
            }

            txtCountryCode.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            HasTheCancelButtonPressed = true;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Country country = new Country();
            bool ok = false;

            country.CountryId = Convert.ToInt32(txtCountryCode.Text);
            country.CountryName = txtCountryName.Text;

            if (Validation.CountryDataValidation(country))
            {
                MessageBox.Show("Please enter the Contact details.");
                return;
            }

            if (CountryID > 0)
            {
                //UPDATE
                ok = DALHelpers.UpdateCountry(country, CountryID);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the Country!");
                }

                ActivityLog.CountryLogger(country, "UPDATE", CountryName, CountryID, Environment.UserName);
                this.Close();
            }
            else //NEW COUNTRY
            {
                List<Country> countryList = new List<Country>();

                countryList = DALHelpers.GetCountryById(country.CountryId);
                if (countryList.Count > 0)
                {
                    MessageBox.Show("Error: The ID: " + country.CountryId + " already exists in the database!");
                    return;
                }
                else
                {
                    ok = DALHelpers.AddCrountry(country);

                    if (ok == true)
                    {
                        ActivityLog.CountryLogger(country, "CREATE", "", 0, Environment.UserName);
                        MessageBox.Show("The record was successfully saved!");
                    }
                }

                this.Close();
            }
        }
    }
}
