using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinksForm.DAL;
using LinksForm.Model;

namespace LinksForm.Forms
{
    public partial class frmAddOrUpdateApplication : Form
    {
        int GlobalApplicationId;
        string GlobalEditOrNew = "";

        public frmAddOrUpdateApplication(int ApplicationId, string ApplicationName)
        {
            InitializeComponent();

            GlobalApplicationId = ApplicationId;

            if (ApplicationId > 0)
            {
                this.Text = "Update Application";
                txtApplicationName.Text = ApplicationName;
                GlobalEditOrNew = "Edit";
            }
            else
            {
                this.Text = "New Application";
                GlobalEditOrNew = "New";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            App application = new App();
            bool ok = false;

            if (string.IsNullOrEmpty(txtApplicationName.Text))
            {
                MessageBox.Show("Please enter the Application name.");
                return;
            }
            else
            {
                application.ApplicationId = GlobalApplicationId;
                application.ApplicationName = txtApplicationName.Text;
            }

            if (GlobalEditOrNew == "Edit")
            {
                //UPDATE APPLICATION
                ok = DALHelpers.UpdateApplication(application);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the Application!");
                }

                this.Close();
            }
            else //NEW APPLICATION
            {

                ok = DALHelpers.AddApplication(application);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }


                this.Close();
            }
        }
    }
}
