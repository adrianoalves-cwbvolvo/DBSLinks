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
        private DataTable dtCredentials = new DataTable();

        private List<Country> countryList = new List<Country>();
        private List<App> appList = new List<App>();
        private List<Category> categoryList = new List<Category>();
        private List<Credential> credentialList = new List<Credential>();

        public frmAddOrUpdateAppLinks(int LinkId, int CountryId, int ApplicationId, int CategoryId, string Description, string Link, int CredentialId)
        {
            InitializeComponent();

            GlobalLinkId = LinkId;

            #region "Loading Credentials"

            dtCredentials.Columns.Add("CredentialId", typeof(int));
            dtCredentials.Columns.Add("Username", typeof(string));
            dtCredentials.Columns.Add("Password", typeof(string));
            dtCredentials.Columns.Add("CredentialDescription", typeof(string));

            #endregion

            countryList = DALHelpers.GetCountries();
            appList = DALHelpers.GetApplications();
            categoryList = DALHelpers.GetCategories();

            if (LinkId > 0)
            {
                txtDescription.Text = Description;
                txtURL.Text = Link;

                int counter = 0;

                foreach (Country country in countryList)
                {
                    cmbCountry.Items.Add(country.CountryName.ToString());

                    if (CountryId == country.CountryId)
                    {
                        cmbCountry.SelectedIndex = counter;
                    }

                    counter++;
                }

                counter = 0;
                foreach (App app in appList)
                {
                    cmbApplication.Items.Add(app.ApplicationName.ToString());

                    if (ApplicationId == app.ApplicationId)
                    {
                        cmbApplication.SelectedIndex = counter;
                    }

                    counter++;
                }

                counter = 0;
                foreach (Category category in categoryList)
                {
                    cmbCategory.Items.Add(category.CategoryName.ToString());

                    if (CategoryId == category.CategoryId)
                    {
                        cmbCategory.SelectedIndex = counter;
                    }

                    counter++;
                }

                credentialList = loadCredentials();

                counter = 0;
                foreach (Credential credential in credentialList)
                {
                    if (CredentialId == credential.CredentialId)
                    {
                        txtCredentialUsername.Text = credential.Username;
                        txtCredentialId.Text = credential.CredentialId.ToString();
                        lblOk.Visible = true;
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
            bool ok = false;

            AppLinks appLinks = new AppLinks();

            if (Validation.AppLinkDataValidation(cmbCountry.Text, cmbApplication.Text, cmbCategory.Text,txtDescription.Text, txtURL.Text, txtCredentialUsername.Text))
            {
                MessageBox.Show("Please enter the AppLink details.");
                return;
            }
            else
            {
                appLinks.Description = txtDescription.Text;
                appLinks.Link = txtURL.Text;
                appLinks.CredentialId = Convert.ToInt32(txtCredentialId.Text);

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
                appLinks.ListId = GlobalLinkId;

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
                dtCredentials.Rows.Add(credential.CredentialId.ToString(), credential.Username.ToString(), Encryption.Decrypt(credential.Password.ToString()), credential.CredentialDescription.ToString());
            }

            dgvCredentials.DataSource = dtCredentials;
            dgvCredentials.Columns[0].Width = 135;
            dgvCredentials.Columns[1].Width = 75;
            dgvCredentials.Columns[2].Width = 60;
            dgvCredentials.Columns[3].Width = 120;
            dgvCredentials.Columns[0].Visible = false;

            dgvCredentials.Sort(dgvCredentials.Columns["Username"], ListSortDirection.Ascending);

            return credentialList;
        }

        private void frmAddOrUpdateAppLinks_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectCredential_Click(object sender, EventArgs e)
        {
            if((dgvCredentials.Rows.Count > 0) || (dgvCredentials.SelectedRows.Count > 0))
            {
                if (btnSelectCredential.Text == "Select")
                {
                    txtCredentialId.Text = dgvCredentials.CurrentRow.Cells[0].Value.ToString();
                    txtCredentialUsername.Text = dgvCredentials.CurrentRow.Cells[1].Value.ToString();
                    lblOk.Visible = true;
                    btnSelectCredential.Text = "UnSelect";
                }
                else
                {
                    txtCredentialId.Clear();
                    txtCredentialUsername.Clear();
                    lblOk.Visible = false;
                    btnSelectCredential.Text = "Select";
                }
            }
        }
    }
}
