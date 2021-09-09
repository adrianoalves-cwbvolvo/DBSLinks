using LinksForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Links.Model.ModelView
{
    public class DatabaseViewModel
    {
        public List<Contact> ContactList = new List<Contact>();
        public List<DealerContact> DealerContactList = new List<DealerContact>();
        public List<Dealer> MainDealerList = new List<Dealer>();
        public List<DealerBranch> DealerBranchesList = new List<DealerBranch>();
        public List<App> ApplicationsList = new List<App>();
        public List<AppLinks> AppLinksList = new List<AppLinks>();
        public List<Country> CountryList = new List<Country>();
    }
}
