using LinksForm.Model;
using System;
using System.IO;

namespace Links.Logger
{
    public static class ActivityLog
    {
        private static string GetFilePath(string screenName)
        {
            string filePath = "//vcn.ds.volvo.net/it-cta/ITPROJ02/002378/DESENV/DBS/AUTOMATOR/LINKS FORM/ActivityLogs/";
            string fileName = screenName + ".txt";
            string fullFilePath = Path.Combine(filePath, fileName);

            return fullFilePath;
        }
        private static void PrintDefaultText(StreamWriter writer, string fullFilePath, string action, string screenName, string UserId)
        {
            writer.Write("\r\n");
            writer.WriteLine("DateTime (UTC): " + DateTime.UtcNow);
            writer.WriteLine("Action Performed By: " + UserId.ToUpper());
            writer.WriteLine("Action Performed: " + action);
        }
        public static void ContactLogger(Contact contact, string action, string screenName, string UserId)
        {
            string fullFilePath = GetFilePath(screenName);

            try
            {
                if(!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    PrintDefaultText(writer, fullFilePath, action, screenName, UserId);

                    writer.WriteLine("ContactId: " + contact.Id);
                    writer.WriteLine("ContactName: " + contact.Name);
                    writer.WriteLine("Phone: " + contact.Phone);
                    writer.WriteLine("CellPhone: " + contact.CellPhone);
                    writer.WriteLine("ComputerName: " + contact.Computer);
                    writer.WriteLine("TeamName: " + contact.TeamName);
                    writer.WriteLine("-------------------------------------------------------------------------------");
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DealerContactLogger(DealerContact dealerContact, string action, string screenName, string UserId)
        {
            string fullFilePath = GetFilePath(screenName);

            try
            {
                if (!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    PrintDefaultText(writer, fullFilePath, action, screenName, UserId);

                    writer.WriteLine("DealerContactId: " + dealerContact.DealerContactId);
                    writer.WriteLine("DealerId: " + dealerContact.DealerId);
                    writer.WriteLine("DealerName: " + dealerContact.DealerName);
                    writer.WriteLine("DealerContactName: " + dealerContact.DealerContactName);
                    writer.WriteLine("Department: " + dealerContact.Department);
                    writer.WriteLine("Phone: " + dealerContact.Phone);
                    writer.WriteLine("CellPhone: " + dealerContact.CellPhone);
                    writer.WriteLine("Email: " + dealerContact.Email);
                    writer.WriteLine("EmCountryId: " + dealerContact.CountryId);
                    writer.WriteLine("-------------------------------------------------------------------------------");
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CredentialLogger(Credential credential, string action, string screenName, string UserId)
        {
            string fullFilePath = GetFilePath(screenName);

            try
            {
                if (!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    PrintDefaultText(writer, fullFilePath, action, screenName, UserId);

                    writer.WriteLine("CredentialId: " + credential.CredentialId);
                    writer.WriteLine("Credential Description: " + credential.CredentialDescription);
                    writer.WriteLine("Username: " + credential.Username);
                    writer.WriteLine("-------------------------------------------------------------------------------");
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DealerLogger(Dealer dealer, string action, string screenName, string UserId)
        {
            string fullFilePath = GetFilePath(screenName);

            try
            {
                if (!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    PrintDefaultText(writer, fullFilePath, action, screenName, UserId);

                    writer.WriteLine("DealerId: " + dealer.DealerId);
                    writer.WriteLine("DealerName: " + dealer.DealerName);
                    writer.WriteLine("CountryId: " + dealer.CountryId);
                    writer.WriteLine("-------------------------------------------------------------------------------");
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DealerBranchLogger(DealerBranch dealerBranch, string action, string screenName, string UserId)
        {
            string fullFilePath = GetFilePath(screenName);

            try
            {
                if (!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    PrintDefaultText(writer, fullFilePath, action, screenName, UserId);

                    writer.WriteLine("DealerBranchId: " + dealerBranch.DealerBranchId);
                    writer.WriteLine("DealerBranchName: " + dealerBranch.BranchName);
                    writer.WriteLine("DealerId: " + dealerBranch.DealerId);
                    writer.WriteLine("DealerName: " + dealerBranch.DealerName);
                    writer.WriteLine("CountryId: " + dealerBranch.CountryId);
                    writer.WriteLine("CTDI: " + dealerBranch.CTDI);
                    writer.WriteLine("PhoneNumber: " + dealerBranch.PhoneNumber);
                    writer.WriteLine("BaldoPartner: " + dealerBranch.BaldoPartner);
                    writer.WriteLine("-------------------------------------------------------------------------------");
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CategoryLogger(Category category, string action, string screenName, string UserId)
        {
            string fullFilePath = GetFilePath(screenName);

            try
            {
                if (!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    PrintDefaultText(writer, fullFilePath, action, screenName, UserId);

                    writer.WriteLine("CategoryId: " + category.CategoryId);
                    writer.WriteLine("CategoryName: " + category.CategoryName);
                    writer.WriteLine("-------------------------------------------------------------------------------");
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AppLinksLogger(AppLinks appLinks, string action, string screenName, string UserId)
        {
            string fullFilePath = GetFilePath(screenName);

            try
            {
                if (!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    PrintDefaultText(writer, fullFilePath, action, screenName, UserId);

                    writer.WriteLine("AppLinkId: " + appLinks.AppLinkId);
                    writer.WriteLine("AppEnvironmentId: " + appLinks.AppEnvironmentId);
                    writer.WriteLine("AppEnvironmentName: " + appLinks.AppEnvironmentName);
                    writer.WriteLine("AppCategoryId: " + appLinks.AppCategoryId);
                    writer.WriteLine("ApplicationId: " + appLinks.ApplicationId);
                    writer.WriteLine("ApplicationNodeId: " + appLinks.ApplicationNodeId);
                    writer.WriteLine("AppNodeName: " + appLinks.AppNodeName);
                    writer.WriteLine("CountryId: " + appLinks.CountryId);
                    writer.WriteLine("Description: " + appLinks.Description);
                    writer.WriteLine("Link: " + appLinks.Link);
                    writer.WriteLine("CredentialId: " + appLinks.CredentialId);
                    writer.WriteLine("Username: " + appLinks.Username);
                    writer.WriteLine("-------------------------------------------------------------------------------");
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void ApplicationLogger(App application, string action, string oldValue, string UserId)
        {
            string screenName = "Application";
            string fullFilePath = GetFilePath(screenName);

            try
            {
                if (!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    PrintDefaultText(writer, fullFilePath, action, screenName, UserId);

                    writer.WriteLine("ApplicationId: " + application.ApplicationId);

                    if (!string.IsNullOrEmpty(oldValue))
                    {
                        writer.WriteLine("ApplicationName From: " + oldValue.ToString()); ;
                        writer.WriteLine("ApplicationName To: " + application.ApplicationName);
                    }
                    else
                    {
                        writer.WriteLine("ApplicationName: " + application.ApplicationName);
                    }

                    writer.WriteLine("-------------------------------------------------------------------------------");
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CountryLogger(Country country, string action, string oldCountryNameValue, int oldCountryId, string UserId)
        {
            string screenName = "Country";
            string fullFilePath = GetFilePath(screenName);

            try
            {
                if (!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    PrintDefaultText(writer, fullFilePath, action, screenName, UserId);

                    if (oldCountryId == 0)
                    {
                        writer.WriteLine("CountryId: " + country.CountryId);
                    }
                    else
                    {
                        writer.WriteLine("CountryId From: " + oldCountryId.ToString());
                        writer.WriteLine("CountryId To: " + country.CountryId);
                    }

                    if (!string.IsNullOrEmpty(oldCountryNameValue) && oldCountryId == 0)
                    {
                        writer.WriteLine("CountryName From: " + oldCountryNameValue.ToString());
                        writer.WriteLine("CountryName To: " + country.CountryName);
                    }
                    else
                    {
                        writer.WriteLine("CountryName: " + country.CountryName);
                    }

                    writer.WriteLine("-------------------------------------------------------------------------------");
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
