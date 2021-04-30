using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinksForm.DAL;
using LinksForm.Forms;
using LinksForm.Model;
using System.Reflection;
using Links.Properties;
using System.IO;

namespace LinksForm.Controller
{
    public class Validation
    {
        #region Assembly Attribute Accessors

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
        public static void startLinksOnStartUp(bool startup)
        {
            string username = Environment.UserName;
            string localFile = "C:\\Users\\" + username + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + "LinksStartup.appref-ms";

            if (startup == true)
            {
                //CHECKING IF THE FILE ALREADY EXISTS IN THE FOLDER
                if (File.Exists(localFile))
                {
                    //DELETING THE SHORTCUT FILE
                    File.Delete(localFile);

                    //COPYING THE SHORTCUT FILE FROM RESOURCES TO THE WINDOWS STARTUP FOLDER
                    File.Copy(@"Resources\LinksStartup.appref-ms", localFile);
                }
                else
                {
                    //COPYING THE SHORTCUT FILE FROM RESOURCES TO THE WINDOWS STARTUP FOLDER
                    File.Copy(@"Resources\LinksStartup.appref-ms", localFile);
                }
            }
            else
            {
                //CHECKING IF THE FILE EXISTS IN THE FOLDER
                if (File.Exists(localFile))
                {
                    //DELETING THE SHORTCUT FILE
                    File.Delete(localFile);
                }
            }
        }

        public static void localDatabaseConfig(bool reload)
        {

            string localDatabaseFolder = "C:\\Temp\\Links";
            string localDatabaseFile = "C:\\Temp\\Links\\NewLinksDB.accdb";
            string networkDatabaseFile = "//vcn.ds.volvo.net/it-cta/ITPROJ02/002378/DESENV/DBS/AUTOMATOR/LINKS FORM/Database/NewLinksDB.accdb";


            Directory.CreateDirectory(localDatabaseFolder);

            if (File.Exists(localDatabaseFile) || (reload = true))
            {
                try
                {
                    File.Delete(localDatabaseFile);
                    File.Copy(networkDatabaseFile, localDatabaseFile);
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                File.Copy(networkDatabaseFile, localDatabaseFile);
            }
        }
        public static bool IsNetworkAvailable(int waitForNetworkMinutes, bool Showdialog)
        {
            //Getting the application path form the Application Settings
            string ApplicationPath = Settings.Default["ApplicationPath"].ToString();

            bool IsNetworkAvailable = false;

            //Getting the current DateTime
            DateTime systemDate = DateTime.Now;

            //Add the minutes set in the variable waitForNetworkMinutes
            TimeSpan timeToADD = new TimeSpan(0, 0, waitForNetworkMinutes, 0);

            //Combining the DateTimes
            DateTime timeCombined = systemDate.Add(timeToADD);

            do
            {
                // Checking if the application can access the Volvo shared network folder
                if (Directory.Exists(ApplicationPath))
                {
                    IsNetworkAvailable = true;
                }
                else // The Volvo network folder is unavailable
                {
                    if (Showdialog == true)
                    {
                        //COMPARING THE CURRENT DATETIME WITH THE TIME SET ABOVE
                        if (DateTime.Now >= timeCombined)
                        {
                            DialogResult dialog = new DialogResult();

                            dialog = MessageBox.Show("The application is unable to load as the VOLVO NETWORK is unavailable. Click 'RETRY' to try to load the application again or click 'CANCEL' to close the application.", "Links - Unable to connect to the Volvo network!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                            if (dialog == DialogResult.Cancel)
                            {
                                //THE USER DECIDED TO END THE APPLICATION
                                Environment.Exit(1);
                            }
                            else
                            {
                                //THE USER DECIDED TO KEEP TRYING TO CONNECT TO THE VOLVO NETWORK
                                //RESETING THE WAITING FOR THE NETWORK MINUTES
                                systemDate = DateTime.Now;
                                timeCombined = systemDate.Add(timeToADD);
                            }
                        }
                    }

                }

            } while (IsNetworkAvailable == false);

            return true;

        }  
        public static bool ContactDataValidation(Contact contact)
        {
            bool IsEmpty = false;

            if ((contact.TeamId == 0) || (contact.Id == string.Empty) || (contact.Name == string.Empty) || (contact.Phone == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static bool AppLinkDataValidation(string cmbCountries, string cmbApplication, string cmbCategory, string Description, string Link, string CredendialUsername)
        {
            bool IsEmpty = false;

            if ((cmbCountries == string.Empty) || (cmbApplication == string.Empty) || (cmbCategory == string.Empty) || (Description == string.Empty) || (Link == string.Empty) || (CredendialUsername == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static bool CredentialDataValidation(string Username, string Password)
        {
            bool IsEmpty = false;

            if ((Username == string.Empty) || (Password == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static bool SubDealerDataValidation(string DealerCode, string DealerName, string comboCountries, string comboDealers)
        {
            bool IsEmpty = false;

            if ((DealerCode == string.Empty) || (DealerName == string.Empty) || (comboCountries == string.Empty) || (comboDealers == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static bool DealerDataValidation(string DealerCode, string DealerName, string comboCountries)
        {
            bool IsEmpty = false;

            if ((DealerCode == string.Empty) || (DealerName == string.Empty) || (comboCountries == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static bool DealerBranchDataValidation(DealerBranch dealerBranch)
        {
            bool IsEmpty = false;

            if ((dealerBranch.DealerId == 0) || (dealerBranch.DealerName == string.Empty) || (dealerBranch.CountryId == 0) || (dealerBranch.CTDI == 0) || (dealerBranch.BaldoPartner == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                              UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }
        public static int GetCountryFlagId(string country)
        {

            switch (country)
            {
                case "Brazil":
                    return 1;
                case "Peru":
                    return 4;
                case "Colombia":
                    return 3;
                case "Chile":
                    return 2;
                case "Argentina":
                    return 0;
            };
            //Default
            return 13;
        }
    }
}
