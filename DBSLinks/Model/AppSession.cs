using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksForms.Model
{
    class AppSession
    {
        public int AppSessionId { get; set; }
        public string ComputerName { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string UserId { get; set; }
        public int IsAppUpdateAvailable { get; set; }
        public int IsDataUpdateAvailable { get; set; }
        public string AppVersion { get; set; }
    }
}
