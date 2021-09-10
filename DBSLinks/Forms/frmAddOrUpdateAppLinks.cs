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
    public partial class frmAddOrUpdateAppLinks : Form
    {
        private int GlobalLinkId = 0;
        private int CredentialId = 0;

        private DataTable dtCredentials = new DataTable();
        private string FilterContactField = "StringToSearch";

        private List<Country> countryList = new List<Country>();
        private List<App> appList = new List<App>();
        private List<Category> categoryList = new List<Category>();
        private List<Credential> credentialList = new List<Credential>();

        public bool HasTheSaveButtonPressed { get; set; }

        public frmAddOrUpdateAppLinks(AppLinks appLinks)
        {
            InitializeComponent();

            GlobalLinkId = appLinks.AppLinkId;

            #region "Loading Credentials"

            dtCredentials.Columns.Add("CredentialId", typeof(int));
            dtCredentials.Columns.Add("CredentialDescription", typeof(string));
            dtCredentials.Columns.Add("Username", typeof(string));
            dtCredentials.Columns.Add("Password", typeof(string));
            dtCredentials.Columns.Add("StringToSearch", typeof(string));

            #endregion

            countryList = DALHelpers.GetCountries();
            appList = DALHelpers.GetApplications();
            categoryList = DALHelpers.GetCategories();

            if (GlobalLinkId > 0)
            {
                txtDescription.Text = appLinks.Description;
                txtURL.Text = appLinks.Link;

                int counter = 0;

                foreach (Country country in countryList)
                {
                    cmbCountry.Items.Add(country.CountryName.ToString());

                    if (appLinks.CountryId == country.CountryId)
                    {
                        cmbCountry.SelectedIndex = counter;
                    }

                    counter++;
                }

                counter = 0;
                foreach (App app in appList)
                {
                    cmbApplication.Items.Add(app.ApplicationName.ToString());

                    if (appLinks.ApplicationId == app.ApplicationId)
                    {
                        cmbApplication.SelectedIndex = counter;
                    }

                    counter++;
                }

                counter = 0;
                foreach (Category category in categoryList)
                {
                    cmbCategory.Items.Add(category.CategoryName.ToString());

                    if (appLinks.AppCategoryId == category.CategoryId)
                    {
                        cmbCategory.SelectedIndex = counter;
                    }

                    counter++;
                }

                credentialList = loadCredentials();

                counter = 0;
                foreach (Credential credential in credentialList)
                {
                    if (appLinks.CredentialId == credential.CredentialId)
                    {
                        CredentialId = credential.CredentialId;
                        txtCredentialId.Text = credential.Username;
                        btnRemoveCredential.Text = "Remove Credential";
                    }
                }
                dgvCredentials.ClearSelection();
            }
            else
            {
                foreach (Country country in countryList)
                {
                    cmbCountry.Items.Add(country.CountryName.ToString());
                }

                foreach (App app in appList)
                {
                    cmbApplication.Items.Add(app.ApplicationName.ToString());
                }

                foreach (Category category in categoryList)
                {
                    cmbCategory.Items.Add(category.CategoryName.ToString());
                }

                credentialList = loadCredentials();
                dgvCredentials.ClearSelection();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HasTheSaveButtonPressed = true;

            bool ok = false;

            AppLinks appLinks = new AppLinks();

            if (Validation.AppLinkDataValidation(cmbCountry.Text, cmbApplication.Text, cmbCategory.Text,txtDescription.Text, txtURL.Text))
            {
                MessageBox.Show("Please enter the AppLink details.");
                return;
            }
            else
            {
                appLinks.Description = txtDescription.Text;
                appLinks.Link = txtURL.Text;

                if (txtCredentialId.Text == "")
                {
                    appLinks.CredentialId = 0;
                }
                else
                {
                    appLinks.CredentialId = CredentialId;
                }

                foreach (Country country in countryList)
                {
                    if (cmbCountry.Text == country.CountryName)
                    {
                        appLinks.CountryId = country.CountryId;
                    }
                }

                foreach (App app in appList)
                {
                    if (cmbApplication.Text == app.ApplicationName)
                    {
                        appLinks.ApplicationId = app.ApplicationId;
                    }
                }

                foreach (Category category in categoryList)
                {
                    if (cmbCategory.Text == category.CategoryName)
                    {
                        appLinks.AppCategoryId = category.CategoryId;
                    }
                }
            }

            #region "UPDATE"

            //UPDATE
            if (GlobalLinkId > 0)
            {
                appLinks.AppLinkId = GlobalLinkId;

                ok = DALHelpers.UpdateAppLink(appLinks);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the App Link!");
                }

                this.Close();
            }

            #endregion

            #region "NEW"

            else
            {
                //NEW
                ok = DALHelpers.AddAppLink(appLinks);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to add a new App Link!");
                }

                this.Close();
            }

            #endregion
        }

        private List<Credential> loadCredentials()
        {
            var credentialList = new List<Credential>();

            credentialList = DALHelpers.GetCredentials();

            dgvCredentials.DataSource = null;
            dgvCredentials.Rows.Clear();
            dtCredentials.Clear();

            foreach (Credential credential in credentialList)
            {
                dtCredentials.Rows.Add(
                    
                    credential.CredentialId.ToString(),
                    credential.CredentialDescription.ToString(),
                    credential.Username.ToString(), 
                    Encryption.Decrypt(credential.Password.ToString()), 
                    credential.Username.ToString() + credential.CredentialDescription.ToString());
            }

            dgvCredentials.DataSource = dtCredentials;
            dgvCredentials.Columns[1].Width = 200;
            dgvCredentials.Columns[2].Width = 150;
            dgvCredentials.Columns[3].Width = 150;

            dgvCredentials.Columns[0].Visible = false;
            dgvCredentials.Columns[4].Visible = false;

            dgvCredentials.Sort(dgvCredentials.Columns["Username"], ListSortDirection.Ascending);

            return credentialList;
        }

        private void btnSelectCredential_Click(object sender, EventArgs e)
        {
            if((dgvCredentials.Rows.Count > 0) || (dgvCredentials.SelectedRows.Count > 0))
            {
                CredentialId = Convert.ToInt32(dgvCredentials.CurrentRow.Cells[0].Value.ToString());
                txtCredentialId.Text = dgvCredentials.CurrentRow.Cells[2].Value.ToString();

                btnRemoveCredential.Text = "Remove Credential";

                grpAppLink.Visible = true;
                grpCredential.Visible = false;

                btnSave.Enabled = true;
            }
        }

        private void txSearchCredential_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;

            oldText = txtSearchCredential.Text;

            if ((txtSearchCredential.Text.All(chr => char.IsLetterOrDigit(chr))) || (txtSearchCredential.Text.Contains(" ")) || (txtSearchCredential.Text.Contains("-")) || (txtSearchCredential.Text.Contains(".")))
            {

                txtSearchCredential.Text = oldText;
            }
            else
            {
                txtSearchCredential.Text = oldText.Remove(oldText.Length - 1);
            }

            txtSearchCredential.SelectionStart = txtSearchCredential.Text.Length;

            dtCredentials.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterContactField, txtSearchCredential.Text);

            if (string.IsNullOrEmpty(txtSearchCredential.Text))
            {
                lblClearSearchCredential.Visible = false;
            }
            else
            {
                lblClearSearchCredential.Visible = true;
            }
        }

        private void lblClearSearchCredential_Click(object sender, EventArgs e)
        {
            txtSearchCredential.Clear();
        }

        private void btnRemoveCredential_Click(object sender, EventArgs e)
        {
            if (btnRemoveCredential.Text == "Remove Credential")
            {
                btnRemoveCredential.Text = "Select Credential";
                txtCredentialId.Clear();
                CredentialId = 0;
                
            }
            else
            {   
                btnRemoveCredential.Text = "Remove Credential";
                grpAppLink.Visible = false;
                grpCredential.Visible = true;
                btnSave.Enabled = false;
            }
        }
    }
}
