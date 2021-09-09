using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Links.Properties;
using LinksForm;
using LinksForm.Controller;
using LinksForm.DAL;
using LinksForms.Model;

namespace Links.Forms
{
    public partial class frmGeneralSettings : Form
    {
        public frmGeneralSettings(int left, int top, int width, int height)
        {
            InitializeComponent();

            //SETTING THE FORM LOCATION
            left = left + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            //GETTING THE TOP MOST SETTINGS AND UPDATING THE CHECK BOX
            getTopMostCheckBoxSettings();

            //GETTING THE WAITFORNETWORK SETTINGS AND UPDATING THE CHECK BOX
            getWaitForNetworkSettings();

            //GETTING THE APPLICATION STARTUP CONFIGURATION
            getStartLinksWhenWindowsIsStarted();
        }

        #region "BUTTONS"

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region "TOP MOST"

            //SAVING THE TOPMOST SETTINGS
            if (chkTopMost.Checked == true)
            {
                Settings.Default["TopMost"] = "true";
            }
            else
            {
                Settings.Default["TopMost"] = "false";
            }

            #endregion

            #region "WAIT FOR NETWORK MINUTES"

            if (chkWaitForNetwork.Checked == true)
            {
                Settings.Default["ApplicationWaitForNetworkMinutes"] = cmbWaitForNetwork.Text;
                Settings.Default["ApplicationWaitForNetwork"] = "true";
            }
            else
            {
                Settings.Default["ApplicationWaitForNetworkMinutes"] = "1";
                Settings.Default["ApplicationWaitForNetwork"] = "false";
            }


            #endregion

            #region "WINDOWS STARTUP"

            if (chkStartup.Checked == true)
            {
                Validation.startLinksOnStartUp(true); //Copy the shortcut file to the Windows startup folder
                Settings.Default["StartLinksWhenWindowsIsStarted"] = "true"; //Updating the Application Settings
            }
            else
            {
                Validation.startLinksOnStartUp(false); //Remove the shortcut file to the Windows startup folder
                Settings.Default["StartLinksWhenWindowsIsStarted"] = "false"; //Updating the Application Settings
            }

            #endregion

            //SAVING THE CHANGES MADE BY THE USER
            Settings.Default.Save(); //Saving the Application Settings

            this.Close();
        }

        #endregion

        #region "METHODS AND FUNCTIONS"

        //GETTING THE TOPMOST SETTINGS AND UPDATING THE CHECKBOX
        private void getTopMostCheckBoxSettings()
        {
            if (Settings.Default["TopMost"].ToString() == "true")
            {
                chkTopMost.Checked = true;
            }else
            {
                chkTopMost.Checked = false;
            }
        }

        private void getWaitForNetworkSettings()
        {
            if (Settings.Default["ApplicationWaitForNetwork"].ToString() == "true")
            {
                cmbWaitForNetwork.Text = Settings.Default["ApplicationWaitForNetworkMinutes"].ToString();
                chkWaitForNetwork.Checked = true;
            }else
            {
                chkWaitForNetwork.Checked = false;
                cmbWaitForNetwork.Text = "1";
            }
            
        }

        private void getStartLinksWhenWindowsIsStarted()
        {
            if (Settings.Default["StartLinksWhenWindowsIsStarted"].ToString() == "true")
            {
                chkStartup.Checked = true;
            }
            else
            {
                chkStartup.Checked = false;
            }
        }
        #endregion

        private void chkWaitForNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWaitForNetwork.Checked == true)
            {
                cmbWaitForNetwork.Enabled = true;
            }
            else
            {
                cmbWaitForNetwork.Enabled = false;
            }
        }

        private void btnCheckForUpdates_Click(object sender, EventArgs e)
        {
            ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
            UpdateCheckInfo info = updateCheck.CheckForDetailedUpdate();
            //
            if (info.UpdateAvailable)
            {
                updateCheck.Update();
                MessageBox.Show("The application has been upgraded, and will now restart.");
                Application.Restart();
            }

        }
    }
}
