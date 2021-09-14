using Links.Model.ModelView;
using LinksForm.DAL;
using LinksForm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using excel = Microsoft.Office.Interop.Excel;

namespace Links.Controller
{
    public static class Services
    {
        public static DatabaseViewModel GetDataFromDatabase()
        {
            DatabaseViewModel databaseViewModel = new DatabaseViewModel();

            databaseViewModel.ContactList = DALHelpers.GetContacts();
            databaseViewModel.DealerContactList = DALHelpers.GetDealerContacts();
            databaseViewModel.MainDealerList = DALHelpers.GetDealers();
            databaseViewModel.DealerBranchesList = DALHelpers.GetDealerBranchs();
            databaseViewModel.ApplicationsList = DALHelpers.GetApplications();
            databaseViewModel.AppLinksList = DALHelpers.GetAppLinks();
            databaseViewModel.CountryList = DALHelpers.GetCountries();

            return databaseViewModel;
        }

        public static void ExportToExcel(DataTable dataTable)
        {
            try
            {
                excel.Application app = new excel.Application();
                excel.Workbook workbook = app.Workbooks.Add();
                excel.Worksheet worksheet = null;

                app.Visible = false;

                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                for (int i = 0; i < dataTable.Columns.Count - 1; i++)
                {
                    worksheet.Cells[1, i + 1] = dataTable.Columns[i].Caption.ToString();
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count - 1; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j].ToString();
                    }
                }

                worksheet.Columns.AutoFit();
                app.Visible = true;

            }
            catch (Exception err)
            {
                MessageBox.Show("An error has ocurred when trying to export the data to Excel: " + err.Message);
            }
        }
    }
}
