using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Links.Forms;
using Links.FormsAdmin;
using Links.Model;
using Links.Properties;
using LinksForm.Controller;
using LinksForm.DAL;
using LinksForm.Forms;
using LinksForm.Model;
using LinksForms.Model;


namespace LinksForm
{
    public partial class frmLinks : Form
    {

        #region "FORM GLOBAL DECLARATIONS"

        private DataTable dtContacts = new DataTable();
        private DataTable dtDealers = new DataTable();
        private DataTable dtDealerContacts = new DataTable();

        private Dictionary<int, string> PasswordList = new Dictionary<int, string>();

        //VARIABLES TO STORE DATA FROM THE DATABASE
        private List<App> ApplicationsList = new List<App>();
        private List<AppLinks> AppLinksFromDatabase = new List<AppLinks>();

        private List<Contact> contactList = new List<Contact>();
        private List<DealerContact> dealerContactList = new List<DealerContact>();
        private List<Dealer> dealerList = new List<Dealer>();

        //SEARCH BOXES VARIABLES
        private string FilterContactField = "StringToSearch";
        private string FilterDealerContactField = "StringToSearch";
        private List<string> CurrentTreeViewNode = new List<string>();

        private List<string> links = new List<string>();

        //MAIN WINDOW POSITION
        private int left;
        private int top;
        private int width;
        private int height;

        #endregion

        #region "FORM INITIALIZING"

        public frmLinks()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);

            setTopMostWindowSetting();
            this.ShowInTaskbar = false;

        }

        #endregion

        #region "FORM LOADING"
        private void frmContacts_Load(object sender, EventArgs e)
        {
            try
            {

                #region "Get App Version"

                //AppVersion appVersion = new AppVersion();

                //appVersion = DALHelpers.GetVersion();

                //string myVersion = Validation.AssemblyVersion;
                ////int result = string.Compare(myVersion, appVersion.LatestVersion.ToString());

                //if (myVersion.ToString() != appVersion.LatestVersion.ToString())
                //{
                //    System.Diagnostics.Process.Start(@"\\vcn.ds.volvo.net\it-cta\ITPROJ02\002378\DESENV\DBS\AUTOMATOR\LINKS FORM\release\setup.exe");

                //    notifyIcon.Visible = false;
                //    Application.Exit();
                //}

                #endregion

                #region "CHECKING FOR THE LOCAL DATABASE"

                Validation.localDatabaseConfig(false);

                #endregion

                #region "RETRIEVING DATA FROM THE DATABASE"

                contactList = DALHelpers.GetContacts();
                dealerContactList = DALHelpers.GetDealerContacts();
                dealerList = DALHelpers.GetDealers();
                ApplicationsList = DALHelpers.GetApplications();
                AppLinksFromDatabase = DALHelpers.GetAppLinks();

                #endregion

                #region "Loading Contacts"

                //dtContacts.Columns.Add("#", typeof(bool));
                dtContacts.Columns.Add("ContactId", typeof(string));
                dtContacts.Columns.Add("Name", typeof(string));
                dtContacts.Columns.Add("Phone", typeof(string));
                dtContacts.Columns.Add("CellPhone", typeof(string));
                dtContacts.Columns.Add("TeamId", typeof(string));
                dtContacts.Columns.Add("TeamName", typeof(string));
                dtContacts.Columns.Add("Computer Name", typeof(string));
                dtContacts.Columns.Add("StringToSearch", typeof(string));

                //contactList = DALHelpers.GetContacts();

                loadContacts();

                #endregion

                #region "Loading DealerContacts"

                dtDealerContacts.Columns.Add("DealerContactId", typeof(string));
                dtDealerContacts.Columns.Add("MainDealerId", typeof(string));
                dtDealerContacts.Columns.Add("Name", typeof(string));
                dtDealerContacts.Columns.Add("Phone", typeof(string));
                dtDealerContacts.Columns.Add("CellPhone", typeof(string));
                dtDealerContacts.Columns.Add("Email", typeof(string));
                dtDealerContacts.Columns.Add("DealerName", typeof(string));
                dtDealerContacts.Columns.Add("Department", typeof(string));
                dtDealerContacts.Columns.Add("CountryId", typeof(string));
                dtDealerContacts.Columns.Add("CountryName", typeof(string));
                dtDealerContacts.Columns.Add("StringToSearch", typeof(string));

                //dealerContactList = DALHelpers.GetDealerContacts();

                //loadDealerContacts();

                #endregion

                #region "Loading Dealers"

                dtDealers.Columns.Add("DealerId", typeof(string));
                dtDealers.Columns.Add("Dealer", typeof(string));
                dtDealers.Columns.Add("Branch", typeof(string));
                dtDealers.Columns.Add("Phone Number", typeof(string));
                dtDealers.Columns.Add("CTDI", typeof(string));
                dtDealers.Columns.Add("BaldoPartner", typeof(string));
                dtDealers.Columns.Add("CountryId", typeof(string));
                dtDealers.Columns.Add("Country", typeof(string));
                dtDealers.Columns.Add("CNPJ", typeof(string));
                dtDealers.Columns.Add("IsActive", typeof(string));
                dtDealers.Columns.Add("MainDealerId", typeof(string));
                dtDealers.Columns.Add("StringToSearch", typeof(string));
                dtDealers.Columns.Add("Sort", typeof(string));

                //dealerList = DALHelpers.GetDealers();

                loadDealers();

                #endregion

                #region "Loading AppLinks TreeView"

                //ApplicationsList = DALHelpers.GetApplications();
                //AppLinksFromDatabase = DALHelpers.GetAppLinks();

                loadTreeview(false, null);

                #endregion

                #region "MAIN WINDOW POSITION"

                left = this.DesktopLocation.X;
                top = this.DesktopLocation.Y;
                width = this.Width;
                height = this.Height;

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        #endregion

        #region "FORM EVENTS"
        private void frmContacts_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }
        private void frmContacts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                notifyIcon.Visible = true;
            }
        }

        #endregion

        #region "COMPONENTS"
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.TopMost = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            setTopMostWindowSetting();
        }

        #endregion

        #region "DATAGRIDVIEW - LOADING CONTACTS DATA"

        private void loadContacts()
        {
            dgvContacts.DataSource = null;
            dgvContacts.Rows.Clear();
            dtContacts.Clear();

            foreach (Contact contact in contactList)
            {
                dtContacts.Rows.Add(
                    contact.Id.ToString(),
                    contact.Name.ToString(),
                    contact.Phone.ToString(),
                    contact.CellPhone.ToString(),
                    contact.TeamId.ToString(),
                    contact.TeamName.ToString(),
                    contact.Computer.ToString(),
                    contact.Name.ToString() + Validation.RemoveDiacritics(contact.Name.ToString()) + contact.Id + contact.Phone.ToString() + contact.CellPhone.ToString() + contact.TeamName.ToString() + contact.Computer.ToString());
            }

            dgvContacts.DataSource = dtContacts;

            dgvContacts.Columns[4].Visible = false;
            dgvContacts.Columns[7].Visible = false;

            dgvContacts.Columns[0].Width = 62;
            dgvContacts.Columns[1].Width = 120;
            dgvContacts.Columns[2].Width = 95;
            dgvContacts.Columns[3].Width = 95;
            dgvContacts.Columns[4].Width = 80;
            dgvContacts.Columns[6].Width = 110;
            dgvContacts.Columns[7].Width = 110;

            dgvContacts.Sort(dgvContacts.Columns["Name"], ListSortDirection.Ascending);
            dgvContacts.Columns["Phone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContacts.Columns["CellPhone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        #endregion

        #region "DATAGRIDVIEW - LOADING DEALER CONTACTS DATA"
        private void loadDealerContacts()
        {
            dgvDealers.DataSource = null;
            dgvDealers.Rows.Clear();
            dtDealerContacts.Clear();

            foreach (DealerContact dealerContact in dealerContactList)
            {
                dtDealerContacts.Rows.Add(
                    dealerContact.DealerContactId.ToString(),
                    dealerContact.MainDealerId.ToString(),
                    dealerContact.Name.ToString(),
                    dealerContact.Phone.ToString(),
                    dealerContact.CellPhone.ToString(),
                    dealerContact.Email.ToString(),
                    dealerContact.DealerName.ToString(),
                    dealerContact.Department.ToString(),
                    dealerContact.CountryId.ToString(),
                    dealerContact.Country.ToString(),
                    dealerContact.Name.ToString() + dealerContact.DealerName.ToString() + Validation.RemoveDiacritics(dealerContact.DealerName.ToString())+ Validation.RemoveDiacritics(dealerContact.Name.ToString()) + Validation.RemoveDiacritics(dealerContact.Department.ToString()) + dealerContact.Department.ToString() + dealerContact.Phone.ToString() + dealerContact.CellPhone.ToString() + dealerContact.Country.ToString() + dealerContact.Email.ToString());
            }

            dgvDealers.DataSource = dtDealerContacts;

            dgvDealers.Columns[0].Visible = false;
            dgvDealers.Columns[1].Visible = false;
            dgvDealers.Columns[8].Visible = false;
            dgvDealers.Columns[10].Visible = false;

            dgvDealers.Columns[2].Width = 150;
            dgvDealers.Columns[3].Width = 130;
            dgvDealers.Columns[4].Width = 130;
            dgvDealers.Columns[5].Width = 180;
            dgvDealers.Columns[6].Width = 180;
            dgvDealers.Columns[7].Width = 130;
            dgvDealers.Columns[9].Width = 50;

            dgvDealers.Sort(dgvDealers.Columns["DealerName"], ListSortDirection.Ascending);

            dgvDealers.ClearSelection();
        }
        #endregion

        #region "DATAGRIDVIEW - LOADING DEALERS DATA"
        private void loadDealers()
        {
            dgvDealers.DataSource = null;
            dgvDealers.Rows.Clear();
            dtDealers.Clear();

            foreach (Dealer dealer in dealerList)
            {
                dtDealers.Rows.Add(
                    dealer.DealerId.ToString(),
                    dealer.DealerName.ToString(),
                    dealer.Branch.ToString(),
                    dealer.PhoneNumber.ToString(),
                    dealer.CTDI.ToString(),
                    dealer.BaldoPartner.ToString(),
                    dealer.CountryId.ToString(),
                    dealer.CountryName.ToString(),
                    dealer.CNPJ.ToString(),
                    dealer.IsActive.ToString(),
                    dealer.MainDealerId.ToString(),
                    dealer.CTDI.ToString() + dealer.PhoneNumber.ToString() + dealer.BaldoPartner.ToString() + dealer.CountryName.ToString() + dealer.DealerName.ToString() + Validation.RemoveDiacritics(dealer.DealerName.ToString()) + dealer.Branch.ToString() + Validation.RemoveDiacritics(dealer.Branch.ToString()),
                    dealer.DealerName.ToString() + dealer.Branch.ToString());
            }

            dgvDealers.DataSource = dtDealers;

            dgvDealers.Columns[0].Visible = false;
            dgvDealers.Columns[6].Visible = false;
            dgvDealers.Columns[8].Visible = false;
            dgvDealers.Columns[9].Visible = false;
            dgvDealers.Columns[10].Visible = false;
            dgvDealers.Columns[11].Visible = false;
            dgvDealers.Columns[12].Visible = false;

            dgvDealers.Columns[1].Width = 150;
            dgvDealers.Columns[2].Width = 150;
            dgvDealers.Columns[3].Width = 110;
            dgvDealers.Columns[4].Width = 50;
            dgvDealers.Columns[7].Width = 70;

            dgvDealers.Sort(dgvDealers.Columns["Sort"], ListSortDirection.Ascending);
        }
        #endregion

        #region "MENUS"

        private void tspExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you want to Exit the application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                notifyIcon.Visible = false;
                Application.Exit();
                //System.Environment.Exit(1);
            }
        }

        private void appLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAppLinks _frmAppLinks = new frmAppLinks();
            _frmAppLinks.ShowDialog();
            this.Show();
            _frmAppLinks.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you want to Exit the application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                notifyIcon.Visible = false;
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbout aboutWindow = new frmAbout();
            aboutWindow.ShowDialog();
            this.Show();
        }

        private void refreshDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dealerList = DALHelpers.GetDealers();
            dealerContactList = DALHelpers.GetDealerContacts();
            loadDealers();

            //contactList = DALHelpers.GetContacts();
            //loadContacts();

            //ApplicationsList = DALHelpers.GetApplications();
            //AppLinksFromDatabase = DALHelpers.GetAppLinks();
            //loadTreeview(false, null);

            MessageBox.Show("Data Refreshed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGeneralSettings _frmConfig = new frmGeneralSettings(left, top, width, height);
            _frmConfig.ShowDialog();

            setTopMostWindowSetting();

            this.Show();
        }

        private void updatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var password in PasswordList)
            {
                TreeNode tn = treeView1.SelectedNode;

                if (tn != null)
                {
                    if (treeView1.SelectedNode.Text.ToString() == password.Value.ToString())
                    {

                        frmUpdatePassword _frmUpdatePassword = new frmUpdatePassword(password.Key, left, top, width, height);

                        this.TopMost = false;

                        _frmUpdatePassword.ShowDialog();
                        //loadAppLinks();

                        setTopMostWindowSetting();

                        _frmUpdatePassword.Dispose();

                        PasswordList.Clear();
                        ApplicationsList = DALHelpers.GetApplications();
                        AppLinksFromDatabase = DALHelpers.GetAppLinks();

                        if (txtAppSearch.Text.Length > 1)
                        {
                            loadAppsFromSearchBox();
                        }
                        else
                        {
                            loadTreeview(false, null);
                        }

                        break;
                    }
                }
            }
        }

        private void contextMenuStripApps_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            updatePasswordToolStripMenuItem.Visible = false;
            toolStripPwdSeparator.Visible = false;
        }

        #endregion

        #region "TAB - CONTACTS"

        #region "SEARCH BOX"

        private void txtContacts_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;

            oldText = txtContacts.Text;

            if ((txtContacts.Text.All(chr => char.IsLetterOrDigit(chr))) || (txtContacts.Text.Contains(" ")) || (txtContacts.Text.Contains("-")) || (txtContacts.Text.Contains(".")))
            {
                txtContacts.Text = oldText;
            }
            else
            {
                txtContacts.Text = oldText.Remove(oldText.Length - 1);
            }

            txtContacts.SelectionStart = txtContacts.Text.Length;

            dtContacts.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterContactField, txtContacts.Text);

            if (string.IsNullOrEmpty(txtContacts.Text))
            {
                lblClearContactsSearch.Visible = false;
            }
            else
            {
                lblClearContactsSearch.Visible = true;
            }

        }
        private void lblClearContactsSearch_Click(object sender, EventArgs e)
        {
            txtContacts.Clear();
        }

        //CONTACTS SEARCH BOX X COLOR EFFECT
        private void lblClearContactsSearch_MouseHover(object sender, EventArgs e)
        {
            lblClearContactsSearch.ForeColor = Color.SteelBlue;
        }
        private void lblClearContactsSearch_MouseLeave(object sender, EventArgs e)
        {
            lblClearContactsSearch.ForeColor = Color.Gray;
        }

        #endregion

        private void dgvContacts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //handle the row selection on right click
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dgvContacts.CurrentCell = dgvContacts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvContacts.Rows[e.RowIndex].Selected = true;
                    dgvContacts.Focus();
                }
                catch (Exception)
                {

                }
            }
        }

        private void dgvContacts_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStripContacts.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }
        private void contextMenuStripContacts_Opening(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvContacts.CurrentCell.Value.ToString()) || (!string.IsNullOrWhiteSpace(dgvContacts.CurrentCell.Value.ToString())))
            {
                Clipboard.SetText(dgvContacts.CurrentCell.Value.ToString());
            }
        }

        #endregion

        #region "TAB - DEALERS"

        #region "DEALERS - POP UP MENU"
        //DEALERS
        private void dgvDealers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStripDealers.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void dgvDealers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //handle the row selection on right click
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dgvDealers.CurrentCell = dgvDealers.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvDealers.Rows[e.RowIndex].Selected = true;
                    dgvDealers.Focus();
                }
                catch (Exception)
                {

                }
            }
        }

        //DEALERS
        private void contextMenuStripDealers_Opening(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvDealers.CurrentCell.Value.ToString()) || (!string.IsNullOrWhiteSpace(dgvDealers.CurrentCell.Value.ToString())))
            {
                Clipboard.SetText(dgvDealers.CurrentCell.Value.ToString());
            }
        }

        #endregion

        private void txtDealers_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;

            oldText = txtDealers.Text;

            if ((txtDealers.Text.All(chr => char.IsLetterOrDigit(chr))) || (txtDealers.Text.Contains(" ")) || (txtDealers.Text.Contains("-")) || (txtDealers.Text.Contains(".")))
            {
                txtDealers.Text = oldText;
            }
            else
            {
                txtDealers.Text = oldText.Remove(oldText.Length - 1);
            }

            txtDealers.SelectionStart = txtDealers.Text.Length;

            if (chkDealerContacts.Checked == true)
            {
                dtDealerContacts.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterDealerContactField, txtDealers.Text);

                if (string.IsNullOrEmpty(txtDealers.Text))
                {
                    lblClearDealersSearch.Visible = false;
                }
                else
                {
                    lblClearDealersSearch.Visible = true;
                }
            }
            else
            {
                dtDealers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterDealerContactField, txtDealers.Text);

                if (string.IsNullOrEmpty(txtDealers.Text))
                {
                    lblClearDealersSearch.Visible = false;
                }
                else
                {
                    lblClearDealersSearch.Visible = true;
                }
            }
        }

        //DEALERS SEARCH BOX X, CLEAR TEXTBOX DATA
        private void lblClearDealersSearch_Click(object sender, EventArgs e)
        {
            txtDealers.Clear();
        }

        //DEALERS SEARCH BOX X COLOR EFFECT
        private void lblClearDealersSearch_MouseHover(object sender, EventArgs e)
        {
            lblClearDealersSearch.ForeColor = Color.SteelBlue;
        }

        private void lblClearDealersSearch_MouseLeave(object sender, EventArgs e)
        {
            lblClearDealersSearch.ForeColor = Color.Gray;
        }
        private void chkDealerContacts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDealerContacts.Checked == true)
            {
                loadDealerContacts();
            }
            else
            {
                loadDealers();
            }
        }

        #endregion

        #region "TAB - APPLICATIONS"

        #region "TREVIEW"

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            foreach (string item in links)
            {
                TreeNode tn = treeView1.SelectedNode;

                if (tn != null)
                {
                    if (treeView1.SelectedNode.Text.Contains(item.ToString()) && item.ToString().Contains("http"))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(item.ToString());
                            break;
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                }
            }
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (var password in PasswordList.Values)
                {
                    TreeNode tnPwd = treeView1.SelectedNode;

                    if (tnPwd != null)
                    {
                        if (treeView1.SelectedNode.Text.ToString() == password.ToString())
                        {
                            //MessageBox.Show(item.ToString());

                            updatePasswordToolStripMenuItem.Visible = true;
                            toolStripPwdSeparator.Visible = true;

                            break;
                        }
                    }
                }

                foreach (string item in links)
                {
                    TreeNode tn = treeView1.SelectedNode;

                    if (tn != null)
                    {
                        if (treeView1.SelectedNode.Text.Contains(item.ToString()))
                        {
                            contextMenuStripApps.Show(Cursor.Position.X, Cursor.Position.Y);
                        }
                    }
                }
            }
        }
        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                e.SuppressKeyPress = true;

                foreach (string item in links)
                {
                    TreeNode tn = treeView1.SelectedNode;

                    if (tn != null)
                    {
                        if (treeView1.SelectedNode.Text.Contains(item.ToString()))
                        {
                            //MessageBox.Show(item.ToString());

                            Clipboard.SetText(item.ToString());
                            break;
                        }
                    }
                }
            }
        }
        private void loadTreeview(bool loadingFromSearchBox, List<AppLinks> AppLinksFromSearchBox)
        {

            int parentNodeCounter = 0;
            bool found = false;

            treeView1.Nodes.Clear();

            //LOOPING THROUGH ALL THE APPLICATION RECORDS
            foreach (App application in ApplicationsList)
            {
                var _appLinks = new List<AppLinks>();

                //REMOVING THE APPLINKS THAT ARE NOT RELATED TO THE APPLICATION THAT IS BEING ADDED TO THIS NODE

                //TREEVIEW
                // false = LOADING TREEVIEW WITH ALL THE DATA FROM THE DATABASE
                // true = LOADING THE TREEVIEW WITH THE DATA FOUND FROM THE WORD TYPED IN THE SEARCH BOX.

                //LOADING TREEVIEW
                if (loadingFromSearchBox == false)
                {
                    foreach (AppLinks item in AppLinksFromDatabase)
                    {
                        if (application.ApplicationId == item.ApplicationId)
                        {
                            _appLinks.Add(item);
                        }
                    }
                }
                else //LOADING TREEVIEW FROM SEARCH BOX
                {
                    foreach (AppLinks item in AppLinksFromSearchBox)
                    {
                        if (application.ApplicationId == item.ApplicationId)
                        {
                            _appLinks.Add(item);
                        }
                    }
                }

                if (_appLinks.Count > 0)
                {
                    int countryNode = 0;
                    var descriptionNode = new Dictionary<int, int>();

                    var countries = new Dictionary<int, string>();

                    //ADDING THE APPLICATION NAME
                    treeView1.Nodes.Add(application.ApplicationName.ToString());
                    treeView1.Nodes[parentNodeCounter].ForeColor = Color.DarkBlue;
                    treeView1.Nodes[parentNodeCounter].ImageIndex = 15;
                    treeView1.Nodes[parentNodeCounter].SelectedImageIndex = 15;

                    found = false;

                    foreach (AppLinks apps in _appLinks)
                    {

                        found = false;
                        foreach (var country in countries.Values)
                        {
                            if (apps.CountryName.ToString() == country.ToString())
                            {
                                found = true;
                            }
                        }
                        if (found == false)
                        {
                            if (countries.Count == 0)
                            {
                                countryNode = 0;
                            }
                            else
                            {
                                countryNode += 1;
                            }

                            //ADDING COUNTRY NAME
                            treeView1.Nodes[parentNodeCounter].Nodes.Add(apps.CountryName);
                            countries.Add(countryNode, apps.CountryName);

                            //GETTING THE COUNTRY FLAG ID
                            int countryFlagId = Validation.GetCountryFlagId(apps.CountryName);

                            //ADDING THE FLAG BY THE ID
                            treeView1.Nodes[parentNodeCounter].Nodes[countryNode].ImageIndex = countryFlagId;
                            treeView1.Nodes[parentNodeCounter].Nodes[countryNode].SelectedImageIndex = countryFlagId;
                        }

                        foreach (var country in countries)
                        {
                            if (apps.CountryName.ToString() == country.Value.ToString())
                            {
                                //SETTING THE VALUES OF THE DESCRIPTION COUNTER
                                if (!descriptionNode.ContainsKey(country.Key))
                                {
                                    descriptionNode.Add(country.Key, 0);
                                }

                                //ADDING THE APPLINK DESCRIPTION
                                treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes.Add(apps.Description);
                                treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].ForeColor = Color.DarkBlue;

                                //ADDING THE CATEGORY ICON BY THE ID
                                int category = 0;
                                switch (apps.AppCategoryId)
                                {
                                    case 1: //APPLICATION
                                        category = 6;
                                        break;
                                    case 2: //DATABASE
                                        category = 5;
                                        break;
                                }

                                treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].ImageIndex = category;
                                treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].SelectedImageIndex = category;

                                //APPLICATION LINK
                                if (apps.Link.ToString() != "")
                                {
                                    treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes.Add(apps.Link.ToString());
                                    addToLinks(apps.Link.ToString());

                                    treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes[0].ImageIndex = 7;
                                    treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes[0].SelectedImageIndex = 7;

                                    if (apps.Link.ToString().Contains("http"))
                                    {
                                        treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes[0].ForeColor = Color.Blue;
                                        treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes[0].NodeFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
                                    }
                                }

                                if (apps.CredentialId > 0)
                                {
                                    //USERNAME WITH THE CREDENTIAL DESCRIPTION, For Example: Admin, Manager
                                    treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes.Add(apps.Username.ToString() + " (" + apps.CredentialDescription + ")");
                                    addToLinks(apps.Username.ToString());

                                    treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes[1].ImageIndex = 8;
                                    treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes[1].SelectedImageIndex = 8;

                                    //PASSWORD
                                    string DescriptedPassword = Encryption.Decrypt(apps.Password.ToString());

                                    if (chkHidePasswords.Checked)
                                    {
                                        treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes.Add(DescriptedPassword);
                                    }
                                    else
                                    {
                                        treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes.Add("**********");
                                    }


                                    addToLinks(DescriptedPassword);
                                    addToPasswordList(apps.CredentialId, DescriptedPassword);

                                    treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes[2].ImageIndex = 9;
                                    treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes[2].SelectedImageIndex = 9;
                                }

                                descriptionNode[country.Key] += 1;
                            }
                        }
                    }
                    parentNodeCounter += 1;
                }
            }

        }

        #endregion

        #region "APPSEARCH SEARCH BOX - TEXT CHANGED"
        private void txtAppSearch_TextChanged(object sender, EventArgs e)
        {
            //txtAppSearch.Text = string.Concat(txtAppSearch.Text.Where(char.IsLetterOrDigit));
            //string mySearchString = txtAppSearch.Text;

            string oldText = string.Empty;

            oldText = txtAppSearch.Text;

            if ((txtAppSearch.Text.All(chr => char.IsLetterOrDigit(chr))) || (txtAppSearch.Text.Contains(" ")) || (txtAppSearch.Text.Contains("-")) || (txtAppSearch.Text.Contains(".")))
            {

                txtAppSearch.Text = oldText;
            }
            else
            {
                txtAppSearch.Text = oldText.Remove(oldText.Length -1);
            }

            txtAppSearch.SelectionStart = txtAppSearch.Text.Length;


            if (!string.IsNullOrEmpty(txtAppSearch.Text) && (txtAppSearch.Text.Length > 1))
            {

                loadAppsFromSearchBox();

                //List<AppLinks> _appLinks = new List<AppLinks>();

                //foreach (AppLinks item in AppLinksFromDatabase)
                //{
                //    if (item.SearchString.ToUpper().Contains(txtAppSearch.Text.ToUpper()))
                //    {
                //        _appLinks.Add(item);
                //    }
                //}

                //if (_appLinks.Count > 0)
                //{
                //    loadTreeview(true, _appLinks);
                //    treeView1.ExpandAll();
                //}
                //else //IF NO RESULTS IS RETURNED, THE TREEVIEW IS CLEARED.
                //{
                //    treeView1.Nodes.Clear();
                //}
            }

            if (string.IsNullOrEmpty(txtAppSearch.Text))
            {
                treeView1.Nodes.Clear();
                loadTreeview(false, null);
                lblClearAppSearch.Visible = false;
            }
            else
            {
                lblClearAppSearch.Visible = true;
            }
        }

        #endregion

        #region "SHOW/HIDE PASSWORD"

        private void chkHidePasswords_CheckedChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtAppSearch.Text))
            {
                //Dictionary<string, bool> nodeStates = new Dictionary<string, bool>();
                //nodeStates = SaveTreeState();

                loadTreeview(false, null);
            }
            else
            {
                List<AppLinks> _appLinks = new List<AppLinks>();

                foreach (AppLinks item in AppLinksFromDatabase)
                {
                    if (item.SearchString.ToUpper().Contains(txtAppSearch.Text.ToUpper()))
                    {
                        _appLinks.Add(item);
                    }
                }

                if (_appLinks.Count > 0)
                {
                    treeView1.Nodes.Clear();
                    loadTreeview(true, _appLinks);
                    treeView1.ExpandAll();
                }
                else
                {
                    treeView1.Nodes.Clear();
                }
            }
        }

        #endregion

        #region "APPSEARCH SEARCH BOX X - CLEAR SEARCH BOX"
        private void lblClearAppSearch_Click(object sender, EventArgs e)
        {
            txtAppSearch.Clear();
        }
        #endregion

        #region "APPSEARCH SEARCH BOX X COLOR EFFECT"

        //APPSEARCH SEARCH BOX X COLOR EFFECT
        private void lblClearAppSearch_MouseHover(object sender, EventArgs e)
        {
            lblClearAppSearch.ForeColor = Color.SteelBlue;
        }
        private void lblClearAppSearch_MouseLeave(object sender, EventArgs e)
        {
            lblClearAppSearch.ForeColor = Color.Gray;
        }

        #endregion

        #region "RIGHT CLICK MENU - COPY TO CLIPBOARD"
        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (string item in links)
            {
                TreeNode tn = treeView1.SelectedNode;

                if (tn != null)
                {
                    if (treeView1.SelectedNode.Text.Contains(item.ToString()))
                    {
                        //MessageBox.Show(item.ToString());

                        Clipboard.SetText(item.ToString());
                        break;
                    }
                }
            }
        }

        #endregion

        #endregion

        #region "FUNCTIONS"

        private void addToLinks(string stringToCompare)
        {
            var found = false;

            foreach (string item in links)
            {
                if (item.ToString() == stringToCompare)
                {
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                links.Add(stringToCompare);
            }
        }
        private void addToPasswordList(int Key, string stringToCompare)
        {
            var found = false;

            foreach (var password in PasswordList.Values)
            {
                if (password.ToString() == stringToCompare)
                {
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                PasswordList.Add(Key, stringToCompare);
            }
        }
        private void setTopMostWindowSetting()
        {
            if (Settings.Default["TopMost"].ToString() == "true")
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        private void loadAppsFromSearchBox()
        {
            List<AppLinks> _appLinks = new List<AppLinks>();

            foreach (AppLinks item in AppLinksFromDatabase)
            {
                if (item.SearchString.ToUpper().Contains(txtAppSearch.Text.ToUpper()))
                {
                    _appLinks.Add(item);
                }
            }

            if (_appLinks.Count > 0)
            {
                loadTreeview(true, _appLinks);
                treeView1.ExpandAll();
            }
            else //IF NO RESULTS IS RETURNED, THE TREEVIEW IS CLEARED.
            {
                treeView1.Nodes.Clear();
            }
        }

        #endregion

        private void dgvContacts_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Tab && dgvContacts.CurrentCell.ColumnIndex == 1)
            //{
            //    e.Handled = true;
            //    DataGridViewCell cell = dgvContacts.Rows[0].Cells[0];
            //    dgvContacts.CurrentCell = cell;
            //    dgvContacts.BeginEdit(true);
            //}
        }
    }
}
