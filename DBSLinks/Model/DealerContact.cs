using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksForm.Model
{
    public class DealerContact
    {
        public int DealerContactId { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerContactName { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
    }
}
