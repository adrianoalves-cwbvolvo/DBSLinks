using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksForm.Model
{
    class Dealer
    {
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string Branch { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CTDI { get; set; }
        public string CNPJ { get; set; }
        public string PhoneNumber { get; set; }
        public string BaldoPartner { get; set; }
        public int IsActive { get; set; }
        public int MainDealerId { get; set; }

    }
}
