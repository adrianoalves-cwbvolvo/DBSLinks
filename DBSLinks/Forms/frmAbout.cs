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
        public frmAbout()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", Validation.AssemblyTitle);
            this.labelProductName.Text = Validation.AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", Validation.AssemblyVersion);
            this.labelCopyright.Text = Validation.AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }        
    }
}
