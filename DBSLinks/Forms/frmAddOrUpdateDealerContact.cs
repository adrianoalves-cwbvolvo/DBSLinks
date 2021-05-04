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
using LinksForm.Model;
using LinksForm.DAL;
using Links.Model;
using Links.Logger;

namespace LinksForm.Forms
{
    public partial class frmAddOrUpdateDealerContact : Form
    {
        private List<Dealer> dealerList = new List<Dealer>();
        private List<Country> countryList = new List<Country>();

        public bool HasTheCancelButtonPressed { get; set; }

        int DealerContactId;

        public frmAddOrUpdateDealerContact(DealerContact dealerContact)
        {
            InitializeComponent();

            countryList = DALHelpers.GetCountries();
            dealerList = DALHelpers.GetDealersByCountry(dealerContact.CountryId);

            DealerContactId = dealerContact.DealerContactId;

            HasTheCancelButtonPressed = false;

            int counter = 0;

            if (dealerContact.DealerContactId != 0)
            {
                foreach (Country country in countryList)
                {
                    cmbCountries.Items.Add(country.CountryName.ToString());

                    if (dealerContact.CountryId == country.CountryId)
                    {
                        cmbCountries.SelectedIndex = counter;
                        dealerList = DALHelpers.GetDealersByCountry(country.CountryId);
                    }

                    counter++;
                }

                counter = 0;

                foreach (Dealer dealer in dealerList)
                {
                    cmbDealerName.Items.Add(dealer.DealerName.ToString());

                    if (dealerContact.CountryId == dealer.CountryId)
                    {
                        cmbDealerName.SelectedIndex = counter;
                    }

                    counter++;
                }

                this.Text = "Update Dealer Contact";
                txtDealerContactName.Text = dealerContact.DealerContactName;
                txtDepartment.Text = dealerContact.Department;
                txtPhone.Text = dealerContact.Phone;
                txtCellPhone.Text = dealerContact.CellPhone;
                txtEmail.Text = dealerContact.Email;
            }
            else
            {
                foreach (Country country in countryList)
                {
                    cmbCountries.Items.Add(country.CountryName.ToString());
                }

                counter = 0;

                foreach (Dealer dealer in dealerList)
                {
                    cmbDealerName.Items.Add(dealer.DealerName.ToString());

                    if (dealerContact.CountryId == dealer.CountryId)
                    {
                        cmbDealerName.SelectedIndex = counter;
                    }

                    counter++;
                }

                this.Text = "New Dealer Brach";
            }

            cmbDealerName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            HasTheCancelButtonPressed = true;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DealerContact dealerContact = new DealerContact();
            bool ok = false;

            dealerContact.DealerContactName = txtDealerContactName.Text;
            dealerContact.Department = txtDepartment.Text;
            dealerContact.Phone = txtPhone.Text;
            dealerContact.CellPhone = txtCellPhone.Text;
            dealerContact.Email = txtEmail.Text;

            foreach (Country country in countryList)
            {
                if (cmbCountries.Text == country.CountryName)
                {
                    dealerContact.CountryId = country.CountryId;
                }
            }

            foreach (Dealer dealer in dealerList)
            {
                if (cmbDealerName.Text == dealer.DealerName)
                {
                    dealerContact.DealerId = dealer.DealerId;
                }
            }

            if (Validation.DealerContacthDataValidation(dealerContact))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (DealerContactId != 0)
            {
                dealerContact.DealerContactId = DealerContactId;
                //UPDATE
                ok = DALHelpers.UpdateDealerContact(dealerContact);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the Dealer Contact!");
                }

                this.Close();
            }
            else //NEW CONTACT
            {

                ok = DALHelpers.AddDealerContact(dealerContact);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                
                this.Close();
            }

        }

        private void cmbCountries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (Country country in countryList)
            {
                if (cmbCountries.SelectedItem.ToString() == country.CountryName)
                {
                    cmbDealerName.Items.Clear();
                    dealerList.Clear();
                    dealerList = DALHelpers.GetDealersByCountry(country.CountryId);
                }
            }

            foreach (Dealer dealer in dealerList)
            {
                cmbDealerName.Items.Add(dealer.DealerName.ToString());
            }
        }
    }
}
