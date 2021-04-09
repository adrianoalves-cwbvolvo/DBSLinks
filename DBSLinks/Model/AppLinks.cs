using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksForm.Model
{
    class AppLinks
    {
        public int ListId { get; set; }
        public int AppEnvironmentId { get; set; }
        public string AppEnvironmentName { get; set; }
        public int AppCategoryId { get; set; }
        public string AppCategoryName { get; set; }
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public int ApplicationNodeId { get; set; }
        public string AppNodeName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int CredentialId { get; set; }
        public string CredentialDescription { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SearchString { get; set; }
    }
}
