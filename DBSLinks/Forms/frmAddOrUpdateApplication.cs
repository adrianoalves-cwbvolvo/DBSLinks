using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Links.Logger;
using LinksForm.DAL;
using LinksForm.Model;

namespace LinksForm.Forms
{
    public partial class frmAddOrUpdateApplication : Form
    {
        int GlobalApplicationId;
        string GlobalApplicationName;

        string GlobalEditOrNew = "";

        public bool hasTheSaveButtonPressed { get; set; }

        public frmAddOrUpdateApplication(int left, int top, int width, int height, App app)
        {
            InitializeComponent();

            left = (left - 130) + (width / 4);
            top = (top - 20) + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            hasTheSaveButtonPressed = false;

            GlobalApplicationId = app.ApplicationId;
            GlobalApplicationName = app.ApplicationName;

            if (GlobalApplicationId > 0)
            {
                this.Text = "Update Application";
                txtApplicationName.Text = app.ApplicationName;
                GlobalEditOrNew = "Edit";
            }
            else
            {
                this.Text = "New Application";
                GlobalEditOrNew = "New";
            }

            txtApplicationName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            hasTheSaveButtonPressed = true;

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

                ActivityLog.ApplicationLogger(application, "UPDATE", GlobalApplicationName, Environment.UserName);
                this.Close();
            }
            else //NEW APPLICATION
            {

                ok = DALHelpers.AddApplication(application);

                if (ok == true)
                {
                    ActivityLog.ApplicationLogger(application, "CREATE", "", Environment.UserName);
                    MessageBox.Show("The record was successfully saved!");
                }

                this.Close();
            }
        }
    }
}
