using Links.Controller;
using Links.Model.ModelView;
using LinksForm;
using LinksForm.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Links.Forms
{
    public partial class frmDataReload : Form
    {
        private bool ReloadButtonClicked = false;
        private DatabaseViewModel _databaseViewModel = new DatabaseViewModel();

        public bool hasTheOkButtonPressed { get; set; }

        public DatabaseViewModel databaseViewModel { get; set; }

        public frmDataReload()
        {
            InitializeComponent();

            hasTheOkButtonPressed = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (ReloadButtonClicked == true)
            {
                databaseViewModel = _databaseViewModel;
            }

            this.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            hasTheOkButtonPressed = true;

            prgDataReload.Minimum = 0;
            prgDataReload.Maximum = 100;
            prgDataReload.Value = 0;

            btnReload.Enabled = false;

            Validation.LocalDatabaseConfig(true);

            System.Threading.Thread.Sleep(1000);
            picNetworkChecked.Visible = true;
            picNetworkChecked.Refresh();

            IncrementProgressBar(20);

            _databaseViewModel = Services.GetDataFromDatabase();

            System.Threading.Thread.Sleep(1000);
            picContactsChecked.Visible = true;
            picContactsChecked.Refresh();

            IncrementProgressBar(20);

            System.Threading.Thread.Sleep(1000);
            picDealersChecked.Visible = true;
            picDealersChecked.Refresh();

            IncrementProgressBar(20);

            System.Threading.Thread.Sleep(1000);
            picDealerContactsChecked.Visible = true;
            picDealerContactsChecked.Refresh();

            IncrementProgressBar(20);

            System.Threading.Thread.Sleep(1000);
            picAppLinksChecked.Visible = true;
            picAppLinksChecked.Refresh();

            IncrementProgressBar(20);

            ReloadButtonClicked = true;
        }

        private void IncrementProgressBar(int value)
        {
            prgDataReload.Increment(value);
        }
    }
}
