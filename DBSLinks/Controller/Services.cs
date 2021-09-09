using Links.Model.ModelView;
using LinksForm.DAL;
using LinksForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
