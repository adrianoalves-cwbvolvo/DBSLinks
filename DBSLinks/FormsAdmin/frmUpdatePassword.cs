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

namespace Links.FormsAdmin
{
    public partial class frmUpdatePassword : Form
    {
        private int GlobalCredentialId;

        public frmUpdatePassword(int CredentialId, int left,int top, int width, int height)
        {
            InitializeComponent();

            //SETTING THE FORM LOCATION
            left = left + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            //NEW OBJECT credential
            Credential credential = new Credential();

            //GETTING THE CREDENTIAL FROM THE DABASE, SEARCHING BY THE ID
            credential = DALHelpers.GetCredentialById(CredentialId);

            //LOADING THE DATA TO THE FORM
            GlobalCredentialId = credential.CredentialId;
            txtDescription.Text = credential.CredentialDescription.ToString();
            txtUsername.Text = credential.Username.ToString();
            txtPassword.Text = credential.Password.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool ok;

            if (!string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length > 2)
            {
                Credential credential = new Credential();

                credential.CredentialId = GlobalCredentialId;
                credential.CredentialDescription = txtDescription.Text;
                credential.Username = txtUsername.Text;
                credential.Password = txtPassword.Text;

                //UPDATE
                ok = DALHelpers.UpdateCredential(credential);

                if (ok == false)
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the Password!");
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
