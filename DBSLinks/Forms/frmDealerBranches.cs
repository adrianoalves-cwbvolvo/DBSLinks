using LinksForm.Model;
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
    public partial class frmDealerBranches : Form
    {
        private List<DealerBranch> dealerlList = new List<DealerBranch>();
        private DataTable dtDealers = new DataTable();
        private string FilteDealerField = "StringToSearch";

        private int left, top, width, height;

        public frmDealerBranches(int _left, int _top, int _width, int _height)
        {
            left = _left;
            top = _top;
            width = _width;
            height = _height;

            InitializeComponent();

            left = (left - 100) + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            StyleCountryButtons();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
        private void StyleCountryButtons()
        {
            btnNewDealer.TabStop = false;
            btnNewDealer.FlatStyle = FlatStyle.Flat;
            btnNewDealer.FlatAppearance.BorderSize = 0;

            btnEditDealer.TabStop = false;
            btnEditDealer.FlatStyle = FlatStyle.Flat;
            btnEditDealer.FlatAppearance.BorderSize = 0;

            btnDeleteDealer.TabStop = false;
            btnDeleteDealer.FlatStyle = FlatStyle.Flat;
            btnDeleteDealer.FlatAppearance.BorderSize = 0;
        }
    }
}
