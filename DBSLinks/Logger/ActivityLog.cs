using LinksForm.Model;
using System;
using System.IO;

namespace Links.Logger
{
    public static class ActivityLog
    {
        public static void ContactLogger(Contact contact, string action, string screenName, string UserId)
        {
            string filePath = "//vcn.ds.volvo.net/it-cta/ITPROJ02/002378/DESENV/DBS/AUTOMATOR/LINKS FORM/ActivityLogs/";

            string fileName = screenName + ".txt";
            string fullFilePath = Path.Combine(filePath, fileName);

            try
            {
                if(!File.Exists(fullFilePath))
                {
                    FileStream file = File.Create(fullFilePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(fullFilePath))
                {
                    writer.Write("\r\n");
                    writer.WriteLine("DateTime (UTC): " + DateTime.UtcNow);
                    writer.WriteLine("Action Performed By: " + UserId.ToUpper());
                    writer.WriteLine("Action Performed: " + action);
                    writer.WriteLine("Data Modified: ");
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
    }
}
