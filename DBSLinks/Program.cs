using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Links.Properties;
using LinksForm.Controller;

namespace LinksForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            #region "STARTUP OPTIONS"

            //CHECKING IF THE "Start Links when I start Windows" is set to True (checked)
            if (Settings.Default["StartLinksWhenWindowsIsStarted"].ToString() == "true")
            {
                Validation.StartLinksOnStartUp(true);
            }

            #endregion

            #region "CHECKING IF THERE IS ANOTHER INSTANCE OF THE APPLICATION RUNNING"
            Mutex mutex = new Mutex(false, appGuid);
            if (!mutex.WaitOne(0, false))
            {
                MessageBox.Show("The application is already running!", "Links",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            GC.Collect();
            GC.KeepAlive(mutex);

            #endregion

            #region "CHECKING FOR THE VOLVO NETWORK CONNECTION"

            int waitForNetworkMinutes = Convert.ToInt32(Settings.Default["ApplicationWaitForNetworkMinutes"].ToString());

            ////THE APPLICATION WILL CHECK FOR THE NETWORK CONNECTION ON THE STARTUP BECAUSE WHEN WORKING FROM HOME, PULSE CAN TAKE A FEW MINUTES TO CONNECT
            ////TO AVOID ERRORS, IF THE APPLICATION IS UNABLE TO CONNECT TO THE VOLVO NETWORK IT WILL KEEP CHECKING FOR THE DURATION IN MINUTES THAT WAS SET IN THE GENERAL SETTINGS

            bool IsNetworkAvailable = Validation.IsNetworkAvailable(waitForNetworkMinutes, true);

            #endregion

            if (IsNetworkAvailable == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLinks());
            }
        }

        //Single Instance appGuid
        private static string appGuid = "0de4e393-b58d-4098-9104-bc960cd9e8d9";
    }
}
