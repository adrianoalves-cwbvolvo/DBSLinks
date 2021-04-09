using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksForm.Model
{
    class Credential
    {
        public int CredentialId { get; set; }
        public string CredentialDescription { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
