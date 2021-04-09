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
    public partial class frmAddOrUpdateCredential : Form
    {
        private int globalCredentialId = 0;
        public frmAddOrUpdateCredential(int Credentialid, string Username, string Password, string Description)
        {
            InitializeComponent();

            globalCredentialId = Credentialid;

            if (!string.IsNullOrEmpty(Username))
            {
                this.Text = "Update Credential";
                txtDescription.Text = Description;
                txtUsername.Text = Username;
                txtUsername.Enabled = false;
                txtPassword.Text = Password;
            }
            else
            {
                this.Text = "New Credential";
                txtUsername.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Credential credential = new Credential();
            bool ok = false;

            if (Validation.CredentialDataValidation(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Please enter the Credential details.");
                return;
            }
            else
            {
                credential.CredentialDescription = txtDescription.Text;
                credential.Username = txtUsername.Text;
                credential.Password = Encryption.Encrypt(txtPassword.Text);
            }

            if (globalCredentialId > 0)
            {
                //UPDATE
                credential.CredentialId = globalCredentialId;
                ok = DALHelpers.UpdateCredential(credential);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the Credential!");
                }

                this.Close();
            }
            else //NEW CREDENTIAL
            {
                List<Credential> credentialList = new List<Credential>();

                credentialList = DALHelpers.GetCredentialByUsername(credential.Username);
                if (credentialList.Count > 0)
                {
                    MessageBox.Show("Error: The ID: " + credential.Username + " ,already exists in the database!");
                }
                else
                {
                    //credential.CredentialId = DALHelpers.GetCredentialMaxId() + 1;
                    ok = DALHelpers.AddCredential(credential);

                    if (ok == true)
                    {
                        MessageBox.Show("The record was successfully saved!");
                    }
                }

                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
