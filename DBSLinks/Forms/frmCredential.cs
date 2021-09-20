using Links.Controller;
using Links.Logger;
using Links.Model.ModelView;
using LinksForm.Controller;
using LinksForm.DAL;
using LinksForm.Forms;
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
    public partial class frmCredential : Form
    {
        private List<Credential> credentialList = new List<Credential>();
        private DataTable dtCredentials = new DataTable();
        private string FilterCredentialField = "StringToSearch";

        //private DatabaseViewModel databaseViewModel = new DatabaseViewModel();

        public frmCredential()
        {
            InitializeComponent();

            StyleCountryButtons();

            dtCredentials.Columns.Add("CredentialId", typeof(int));
            dtCredentials.Columns.Add("Description", typeof(string));
            dtCredentials.Columns.Add("Username", typeof(string));
            dtCredentials.Columns.Add("Password", typeof(string));
            dtCredentials.Columns.Add("StringToSearch", typeof(string));

            credentialList = loadCredentials();

        }


        private void txtSearchCredential_TextChanged(object sender, EventArgs e)
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

            dtCredentials.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterCredentialField, txtSearchCredential.Text);

            if (string.IsNullOrEmpty(txtSearchCredential.Text))
            {
                lblClearSearchCredential.Visible = false;
            }
            else
            {
                lblClearSearchCredential.Visible = true;
            }
        }

        private void btnNewCredential_Click(object sender, EventArgs e)
        {
            bool hasTheSaveButtonPressed;

            Credential credential = new Credential();

            frmAddOrUpdateCredential _frmAddOrUpdateCredential= new frmAddOrUpdateCredential(credential);
            _frmAddOrUpdateCredential.TopMost = true;
            _frmAddOrUpdateCredential.StartPosition = FormStartPosition.CenterParent;
            _frmAddOrUpdateCredential.ShowDialog();

            hasTheSaveButtonPressed = _frmAddOrUpdateCredential.hasTheSaveButtonPressed;

            if (hasTheSaveButtonPressed == true)
            {
                Validation.LocalDatabaseConfig(true);
                //databaseViewModel = Services.GetDataFromDatabase();
                credentialList = loadCredentials();
            }

            dgvCredentials.ClearSelection();
            txtSearchCredential.Clear();
            btnEditCredential.Enabled = false;
            btnDeleteCredential.Enabled = false;

            _frmAddOrUpdateCredential.Dispose();
        }

        private void btnEditCredential_Click(object sender, EventArgs e)
        {
            if ((dgvCredentials.Rows.Count > 0))
            {
                Credential credential = new Credential();
                bool hasTheSaveButtonPressed;

                credential.CredentialId = Convert.ToInt32(dgvCredentials.CurrentRow.Cells[0].Value.ToString());
                credential.CredentialDescription = dgvCredentials.CurrentRow.Cells[1].Value.ToString();
                credential.Username = dgvCredentials.CurrentRow.Cells[2].Value.ToString();
                credential.Password = dgvCredentials.CurrentRow.Cells[3].Value.ToString();

                frmAddOrUpdateCredential _frmAddOrUpdateCredential = new frmAddOrUpdateCredential(credential);
                this.TopMost = false;
                _frmAddOrUpdateCredential.StartPosition = FormStartPosition.CenterParent;
                _frmAddOrUpdateCredential.ShowDialog();

                hasTheSaveButtonPressed = _frmAddOrUpdateCredential.hasTheSaveButtonPressed;

                if (hasTheSaveButtonPressed == true)
                {
                    Validation.LocalDatabaseConfig(true);
                    //databaseViewModel = Services.GetDataFromDatabase();
                    credentialList = loadCredentials();
                }

                dgvCredentials.ClearSelection();
                txtSearchCredential.Clear();
                btnEditCredential.Enabled = false;
                btnDeleteCredential.Enabled = false;

                _frmAddOrUpdateCredential.Dispose();

            }
        }

        private void btnDeleteCredential_Click(object sender, EventArgs e)
        {
            if (dgvCredentials.Rows.Count > 0)
            {
                int CredentialId = Convert.ToInt32(dgvCredentials.CurrentRow.Cells[0].Value.ToString());
                string CredentialDescription = dgvCredentials.CurrentRow.Cells[1].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete the credential " + CredentialDescription + "?", "Delete Credential", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Credential credential = new Credential();

                    credential.CredentialId = Convert.ToInt32(dgvCredentials.CurrentRow.Cells[0].Value.ToString());
                    credential.CredentialDescription = dgvCredentials.CurrentRow.Cells[1].Value.ToString();
                    credential.Username = dgvCredentials.CurrentRow.Cells[2].Value.ToString();
                    credential.Password = dgvCredentials.CurrentRow.Cells[3].Value.ToString();

                    DALHelpers.DeleteCredential(CredentialId);

                    ActivityLog.CredentialLogger(credential, "DELETE", "Credential", Environment.UserName);

                    Validation.LocalDatabaseConfig(true);
                    //databaseViewModel = Services.GetDataFromDatabase();
                    loadCredentials();
                }

                dgvCredentials.ClearSelection();
                txtSearchCredential.Clear();
                btnEditCredential.Enabled = false;
                btnDeleteCredential.Enabled = false;
            }
        }

        private void dgvCredentials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditCredential.Enabled = true;
            btnDeleteCredential.Enabled = true;
        }

        private void lblClearSearchCredential_Click(object sender, EventArgs e)
        {
            txtSearchCredential.Clear();
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
            dgvCredentials.Columns[1].Width = 189;
            dgvCredentials.Columns[2].Width = 140;
            dgvCredentials.Columns[3].Width = 140;
            dgvCredentials.Columns[0].Visible = false;
            dgvCredentials.Columns[4].Visible = false;

            dgvCredentials.Sort(dgvCredentials.Columns["Description"], ListSortDirection.Ascending);

            return credentialList;
        }

        private void StyleCountryButtons()
        {
            btnNewCredential.TabStop = false;
            btnNewCredential.FlatStyle = FlatStyle.Flat;
            btnNewCredential.FlatAppearance.BorderSize = 0;

            btnEditCredential.TabStop = false;
            btnEditCredential.FlatStyle = FlatStyle.Flat;
            btnEditCredential.FlatAppearance.BorderSize = 0;

            btnDeleteCredential.TabStop = false;
            btnDeleteCredential.FlatStyle = FlatStyle.Flat;
            btnDeleteCredential.FlatAppearance.BorderSize = 0;
        }
    }
}
