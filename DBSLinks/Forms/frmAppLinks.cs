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
    public partial class frmAppLinks : Form
    {
        private DataTable dtAppLinks = new DataTable();
        private DataTable dtCredentials = new DataTable();

        private string FilterField;

        public frmAppLinks()
        {
            InitializeComponent();


        }

        private void frmAppLinks_Load(object sender, EventArgs e)
        {

            dtAppLinks.Columns.Add("ListId", typeof(int));                      //0
            dtAppLinks.Columns.Add("Link Description", typeof(string));         //1
            dtAppLinks.Columns.Add("App Link", typeof(string));                 //2
            dtAppLinks.Columns.Add("AppCategoryId", typeof(int));               //3
            dtAppLinks.Columns.Add("Category", typeof(string));                 //4
            dtAppLinks.Columns.Add("ApplicationId", typeof(int));               //5
            dtAppLinks.Columns.Add("Application", typeof(string));              //6
            dtAppLinks.Columns.Add("CountryId", typeof(int));                   //7
            dtAppLinks.Columns.Add("Country", typeof(string));                  //8
            dtAppLinks.Columns.Add("CredentialId", typeof(int));                //9
            dtAppLinks.Columns.Add("Credential Description", typeof(string));   //10
            dtAppLinks.Columns.Add("Username", typeof(string));                 //11
            dtAppLinks.Columns.Add("Password", typeof(string));                 //12

            dtAppLinks.Columns.Add("SearchString", typeof(string));

            FilterField = "SearchString";

            loadAppLinks();
            dgvAppLinks.ClearSelection();
        }

        private void txtAppLinkSearch_TextChanged(object sender, EventArgs e)
        {
            dtAppLinks.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterField, txtAppLinkSearch.Text);
        }

        private void loadAppLinks()
        {
            try
            {
                var appLinksList = new List<AppLinks>();

                appLinksList.Clear();

                appLinksList = DALHelpers.GetAppLinks();

                dgvAppLinks.DataSource = null;
                dgvAppLinks.Rows.Clear();
                dtAppLinks.Clear();

                foreach (AppLinks link in appLinksList)
                {
                    string tempPassword = link.Password.ToString();

                    if (!string.IsNullOrEmpty(tempPassword))
                    {
                        tempPassword = Encryption.Decrypt(tempPassword);
                    }

                    dtAppLinks.Rows.Add(link.ListId.ToString(), link.Description.ToString(), link.Link.ToString(), 
                                            link.AppCategoryId.ToString(),link.AppCategoryName.ToString(),
                                            link.ApplicationId.ToString(), link.ApplicationName.ToString(),
                                            link.CountryId.ToString(), link.CountryName.ToString(),
                                            link.CredentialId.ToString(), link.CredentialDescription.ToString(), link.Username.ToString(), tempPassword,
                                            link.AppCategoryName.ToString() + link.ApplicationName.ToString() + link.CountryName.ToString() + link.Description.ToString() + link.Link.ToString() + link.CredentialDescription.ToString() + link.Username.ToString());
                }

                dgvAppLinks.DataSource = dtAppLinks;
                dgvAppLinks.Columns[0].Visible = false;
                dgvAppLinks.Columns[3].Visible = false;
                dgvAppLinks.Columns[5].Visible = false;
                dgvAppLinks.Columns[7].Visible = false;
                dgvAppLinks.Columns[9].Visible = false;
                dgvAppLinks.Columns[13].Visible = false;

                dgvAppLinks.Columns[1].Width = 200;
                dgvAppLinks.Columns[2].Width = 300;
                dgvAppLinks.Columns[4].Width = 70;
                dgvAppLinks.Columns[6].Width = 70;
                dgvAppLinks.Columns[8].Width = 70;
                dgvAppLinks.Columns[10].Width = 140;
                dgvAppLinks.Columns[11].Width = 70;

                dgvAppLinks.Sort(dgvAppLinks.Columns["Link Description"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((dgvAppLinks.Rows.Count > 0) && (dgvAppLinks.SelectedRows.Count > 0))
            {
                int LinkId;
                int CountryId;
                int ApplicationId;
                int CategoryId;
                string Description;
                string Link;
                int CredentialId;

                LinkId = Convert.ToInt32(dgvAppLinks.CurrentRow.Cells[0].Value.ToString());
                Description = dgvAppLinks.CurrentRow.Cells[1].Value.ToString();
                Link = dgvAppLinks.CurrentRow.Cells[2].Value.ToString();
                CategoryId = Convert.ToInt32(dgvAppLinks.CurrentRow.Cells[3].Value.ToString());
                ApplicationId = Convert.ToInt32(dgvAppLinks.CurrentRow.Cells[5].Value.ToString());
                CountryId = Convert.ToInt32(dgvAppLinks.CurrentRow.Cells[7].Value.ToString());
                CredentialId = Convert.ToInt32(dgvAppLinks.CurrentRow.Cells[9].Value.ToString());

                frmAddOrUpdateAppLinks formAppLinks = new frmAddOrUpdateAppLinks(LinkId, CountryId, ApplicationId, CategoryId, Description, Link, CredentialId);
                formAppLinks.ShowDialog();
                loadAppLinks();
                dgvAppLinks.ClearSelection();
                formAppLinks.Dispose();
                txtAppLinkSearch.Clear();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateAppLinks formAppLinks = new frmAddOrUpdateAppLinks(0, 0, 0, 0, "", "",0);
            formAppLinks.ShowDialog();
            loadAppLinks();
            dgvAppLinks.ClearSelection();
            formAppLinks.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((dgvAppLinks.Rows.Count > 0) && (dgvAppLinks.SelectedRows.Count > 0))
            {
                int LinkId;
                string Description = dgvAppLinks.CurrentRow.Cells[1].Value.ToString();
                LinkId = Convert.ToInt32(dgvAppLinks.CurrentRow.Cells[0].Value.ToString());
                
                if (MessageBox.Show("Are you sure you want to delete the App Link: " + Description, "Delete App Link", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DALHelpers.DeleteAppLink(LinkId);
                    System.Threading.Thread.Sleep(1000);
                    loadAppLinks();
                    dgvAppLinks.ClearSelection();
                }
                else
                {
                    dgvAppLinks.ClearSelection();
                }
                txtAppLinkSearch.Clear();
            }
        }
    }
}
