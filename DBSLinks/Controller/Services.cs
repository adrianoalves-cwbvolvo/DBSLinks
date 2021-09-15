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

        public static void ExportToExcel(List<ExportToExcelViewModel> exportToExcelList)
        {
            excel.Application app = new excel.Application();
            excel.Workbook workbook = app.Workbooks.Add();
            excel.Worksheet worksheet = null;

            app.Visible = false;

            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            foreach (ExportToExcelViewModel list in exportToExcelList)
            {
                worksheet.Cells[list.Row, list.Col] = list.Text;
            }

            worksheet.Columns.AutoFit();
            app.Visible = true;
        }
    }
}
