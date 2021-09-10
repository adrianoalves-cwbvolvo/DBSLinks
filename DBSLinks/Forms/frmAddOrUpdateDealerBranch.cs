using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Links.Logger;
using LinksForm.Controller;
using LinksForm.DAL;
using LinksForm.Model;

namespace LinksForm.Forms
{
    public partial class frmAddOrUpdateDealerBranch : Form
    {
        List<DealerBranch> dealerBranchList = new List<DealerBranch>();
        List<Dealer> dealerList = new List<Dealer>();
        List<Country> countryList = new List<Country>();

        int CountryId;

        int DealerBranchId;

        public bool HasTheSaveButtonPressed { get; set; }

        public frmAddOrUpdateDealerBranch(DealerBranch dealerBranch)
        {
            InitializeComponent();

            CountryId = dealerBranch.CountryId;
            DealerBranchId = dealerBranch.DealerBranchId;

            dealerBranchList = DALHelpers.GetDealerBranchs();
            countryList = DALHelpers.GetCountries();

            HasTheSaveButtonPressed = false;

            int counter = 0;

            if (dealerBranch.DealerBranchId != 0)
            {
                foreach (Country _country in countryList)
                {
                    cmbCountries.Items.Add(_country.CountryName.ToString());

                    if (dealerBranch.CountryId == _country.CountryId)
                    {
                        cmbCountries.SelectedIndex = counter;
                        dealerList = DALHelpers.GetDealersByCountry(_country.CountryId);
                    }

                    counter++;
                }

                counter = 0;

                foreach (Dealer dealer in dealerList)
                {
                    cmbMainDealer.Items.Add(dealer.DealerName.ToString());

                    if (dealerBranch.CountryId == dealer.CountryId)
                    {
                        cmbMainDealer.SelectedIndex = counter;
                    }

                    counter++;
                }

                this.Text = "Update Dealer Branch";
                txtBranchName.Text = dealerBranch.BranchName;
                txtPhoneNumber.Text = dealerBranch.PhoneNumber;
                txtCTDI.Text = dealerBranch.CTDI.ToString();
                txtBaldoPartner.Text = dealerBranch.BaldoPartner;
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
                    cmbMainDealer.Items.Add(dealer.DealerName.ToString());

                    if (dealerBranch.CountryId == dealer.CountryId)
                    {
                        cmbMainDealer.SelectedIndex = counter;
                    }

                    counter++;
                }

                this.Text = "New Dealer Brach";

            }

            cmbCountries.Focus();
        }
   
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HasTheSaveButtonPressed = true;

            DealerBranch dealerBranch = new DealerBranch();
            bool ok = false;

            if (txtCTDI.Text == "")
            {
                dealerBranch.CTDI = 0;
            }
            else
            {
                dealerBranch.CTDI = Convert.ToInt32(txtCTDI.Text);
            }
            dealerBranch.BranchName = txtBranchName.Text;
            dealerBranch.PhoneNumber = txtPhoneNumber.Text;
            
            dealerBranch.BaldoPartner = txtBaldoPartner.Text;

            foreach (Country country in countryList)
            {
                if (cmbCountries.Text == country.CountryName)
                {
                    dealerBranch.CountryId = country.CountryId;
                }
            }

            foreach (Dealer dealer in dealerList)
            {
                if (cmbMainDealer.Text == dealer.DealerName)
                {
                    dealerBranch.DealerId = dealer.DealerId;
                }
            }

            if (Validation.DealerBranchDataValidation(dealerBranch))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (DealerBranchId != 0)
            {
                dealerBranch.DealerBranchId = DealerBranchId;
                //UPDATE
                ok = DALHelpers.UpdateDealerBranch(dealerBranch);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the Branch!");
                }

                ActivityLog.DealerBranchLogger(dealerBranch, "UPDATE", "Dealer Branch", Environment.UserName);
                this.Close();
            }
            else //NEW CONTACT
            {
                bool CTDI = false;
                bool BranchName = false;
                bool BaldoPartner = false;

                foreach (DealerBranch db in dealerBranchList)
                {
                    if (dealerBranch.CTDI == db.CTDI)
                    {
                        CTDI = true;
                    }

                    if (dealerBranch.BranchName == db.BranchName)
                    {
                        BranchName = true;
                    }

                    if (dealerBranch.BaldoPartner == db.BaldoPartner)
                    {
                        BaldoPartner = true;
                    }
                }

                if (CTDI == true || BranchName == true || BaldoPartner == true)
                {
                    MessageBox.Show("Error: The Branch Name, CTDI or Baldo Partner already exists in the database!");
                    return;
                }
                else
                {
                    ok = DALHelpers.AddDealerBranch(dealerBranch);

                    if (ok == true)
                    {
                        MessageBox.Show("The record was successfully saved!");
                    }
                }

                ActivityLog.DealerBranchLogger(dealerBranch, "CREATE", "Dealer Branch", Environment.UserName);
                this.Close();
            }
        }

        private void cmbCountries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (Country country in countryList)
            {
                if (cmbCountries.SelectedItem.ToString() == country.CountryName)
                {
                    cmbMainDealer.Items.Clear();
                    dealerList.Clear();
                    dealerList = DALHelpers.GetDealersByCountry(country.CountryId);
                }
            }

            foreach (Dealer dealer in dealerList)
            {
                cmbMainDealer.Items.Add(dealer.DealerName.ToString());
            }
        }

        private void txtCTDI_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
