using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using LinksForm.Controller;

namespace Links.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout(int left, int top, int width, int height)
        {
            InitializeComponent();

            left = left + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            this.Text = String.Format("About {0}", Validation.AssemblyTitle);
            this.labelProductName.Text = Validation.AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", Validation.AssemblyVersion);
            this.labelCopyright.Text = Validation.AssemblyCopyright;

            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }        
    }
}
