using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksForm.Model
{
    public class DealerBranch
    {
        public int DealerBranchId { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string BranchName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CTDI { get; set; }
        public string PhoneNumber { get; set; }
        public string BaldoPartner { get; set; }
       

    }
}
