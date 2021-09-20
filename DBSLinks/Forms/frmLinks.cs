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
using Links.Controller;
using Links.Forms;
using Links.FormsAdmin;
using Links.Logger;
using Links.Model;
using Links.Model.ModelView;
using Links.Properties;
using LinksForm.Controller;
using LinksForm.DAL;
using LinksForm.Forms;
using LinksForm.Model;



namespace LinksForm
{
    public partial class frmLinks : Form
    {

        #region "FORM GLOBAL DECLARATIONS"

        //DATATABLES USED BY THE DATAGRIVIEWS

        private DataTable dtContacts = new DataTable();
        private DataTable dtDealers = new DataTable();
        private DataTable dtDealerContacts = new DataTable();

        //DICTIONARY USED BY THE TREEVIEW
        private Dictionary<int, string> passwordList = new Dictionary<int, string>();
        private List<string> links = new List<string>();

        //VARIABLE TO STORE DATA FROM THE DATABASE
        private List<Country> countryList = new List<Country>();

        private DatabaseViewModel databaseViewModel = new DatabaseViewModel();

        //SEARCH BOXES VARIABLES
        private string filterContactField = "StringToSearch";
        private string filterDealerContactField = "StringToSearch";
        private List<string> currentTreeViewNode = new List<string>();

        //DEALER AND DEALER CONTACT VARIABLE SWITCH FOR THE NEW/EDIT/DELETE BUTTONS
        private bool isDealerContactView = false;

        //MAIN WINDOW POSITION
        private int left;
        private int top;
        private int width;
        private int height;

        //TREEVIEW VARIABLE - KEEP TRACK OF WHAT NODE HAS BEEN CLICKED
        private string treeviewNodeExpandText;
        private bool hasTheTreeviewNodeSelected = false;

        private ToolTip toolTip = new ToolTip(); 

        #endregion

        #region "FORM INITIALIZING"

        public frmLinks()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);

            SetTopMostWindowSetting();
            this.ShowInTaskbar = false;

            StyleContactButtons();
            StyleDealerButtons();
            StyleApplicationButtons();

        }

        #endregion

        #region "FORM LOADING"
        private void frmLinks_Load(object sender, EventArgs e)
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

                Validation.LocalDatabaseConfig(false);

                #endregion

                #region "RETRIEVING DATA FROM THE DATABASE"

                databaseViewModel = Services.GetDataFromDatabase();

                #endregion

                #region "Loading Contacts"

                try
                {
                    dtContacts.Columns.Add("ContactId", typeof(string));
                    dtContacts.Columns.Add("Name", typeof(string));
                    dtContacts.Columns.Add("Phone", typeof(string));
                    dtContacts.Columns.Add("CellPhone", typeof(string));
                    dtContacts.Columns.Add("TeamId", typeof(string));
                    dtContacts.Columns.Add("TeamName", typeof(string));
                    dtContacts.Columns.Add("Computer Name", typeof(string));
                    dtContacts.Columns.Add("StringToSearch", typeof(string));

                    LoadContacts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to load Contacts Data: " + ex.Message);
                }

                #endregion

                #region "Loading DealerContacts"

                try
                {
                    dtDealerContacts.Columns.Add("DealerContactId", typeof(string));
                    dtDealerContacts.Columns.Add("DealerId", typeof(string));
                    dtDealerContacts.Columns.Add("DealerName", typeof(string));
                    dtDealerContacts.Columns.Add("Name", typeof(string));
                    dtDealerContacts.Columns.Add("Department", typeof(string));
                    dtDealerContacts.Columns.Add("Phone", typeof(string));
                    dtDealerContacts.Columns.Add("CellPhone", typeof(string));
                    dtDealerContacts.Columns.Add("Email", typeof(string));
                    dtDealerContacts.Columns.Add("CountryId", typeof(string));
                    dtDealerContacts.Columns.Add("CountryName", typeof(string));
                    dtDealerContacts.Columns.Add("StringToSearch", typeof(string));

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to load DealersContacts: " + ex.Message);
                }

                #endregion

                #region "Loading Dealers"

                try
                {
                    dtDealers.Columns.Add("BranchId", typeof(string));
                    dtDealers.Columns.Add("CTDI", typeof(string));
                    dtDealers.Columns.Add("Dealer", typeof(string));
                    dtDealers.Columns.Add("Branch", typeof(string));
                    dtDealers.Columns.Add("Phone Number", typeof(string));
                    dtDealers.Columns.Add("BaldoPartner", typeof(string));
                    dtDealers.Columns.Add("CountryId", typeof(string));
                    dtDealers.Columns.Add("Country", typeof(string));
                    dtDealers.Columns.Add("DealerId", typeof(string));
                    dtDealers.Columns.Add("StringToSearch", typeof(string));
                    dtDealers.Columns.Add("Sort", typeof(string));

                    LoadDealerBranches();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to load Dealers Data: " + ex.Message);
                }


                #endregion

                #region "Loading AppLinks TreeView"

                LoadTreeview(false, null);

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
                MessageBox.Show("Loading error : " + ex.Message);
            }
        }

        #endregion

        #region "FORM EVENTS"
        private void frmLinks_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }
        private void frmLinks_FormClosing(object sender, FormClosingEventArgs e)
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
            SetTopMostWindowSetting();
        }
        private void tabMain_MouseClick(object sender, MouseEventArgs e)
        {
            dgvContacts.ClearSelection();
            dgvDealers.ClearSelection();
        }
        #endregion

        #region "MENUS"

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void updatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ReturnedUsername;
            bool hasTheSaveButtonPressed = false;

            int CredentialId=0;

            TreeNode tn = treeView1.SelectedNode;

            if (tn != null)
            {
                foreach (var password in passwordList)
                {
                    if (treeView1.SelectedNode.Text.ToString() == password.Value.ToString())
                    {
                        CredentialId = password.Key;
                        break;
                    }
                }

                frmUpdatePassword _frmUpdatePassword = new frmUpdatePassword(CredentialId, left, top, width, height);
                _frmUpdatePassword.TopMost = true;
                _frmUpdatePassword.ShowDialog();

                ReturnedUsername = _frmUpdatePassword.UsernameToBeReturned;
                hasTheSaveButtonPressed = _frmUpdatePassword.hasTheSaveButtonPressed;

                if (hasTheSaveButtonPressed == true)
                {
                    passwordList.Clear();
                    Validation.LocalDatabaseConfig(true);

                    databaseViewModel = Services.GetDataFromDatabase();
                    
                    txtAppSearch.Text = ReturnedUsername;
                }

                _frmUpdatePassword.Dispose(); 
            }
        }
        private void contextMenuStripApps_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            updatePasswordToolStripMenuItem.Visible = false;
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmGeneralSettings _frmConfig = new frmGeneralSettings();

            _frmConfig.TopMost = true;
            _frmConfig.StartPosition = FormStartPosition.CenterParent;
            _frmConfig.ShowDialog();

            SetTopMostWindowSetting();

            //this.Show();
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout aboutWindow = new frmAbout(left, top, width, height);
            aboutWindow.TopMost = true;
            aboutWindow.StartPosition = FormStartPosition.CenterParent;
            aboutWindow.ShowDialog();
        }
        private void reloadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DatabaseViewModel _databaseViewModel = new DatabaseViewModel();

            bool hasTheOkButtonPressed = false;

            frmDataReload _frmDataReload = new frmDataReload(left, top, width, height);

            //_frmReloadData.MdiParent = this;
            _frmDataReload.TopMost = true;
            _frmDataReload.ShowDialog();

            hasTheOkButtonPressed = _frmDataReload.hasTheOkButtonPressed;

            if (hasTheOkButtonPressed == true)
            {
                databaseViewModel = _frmDataReload.databaseViewModel;

                LoadContacts();
                LoadDealerContacts();
                LoadDealerBranches();
                LoadTreeview(false, null);
            }
        }
        private void countriesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmCountry _frmCountry = new frmCountry(left, top, width, height);
            _frmCountry.TopMost = true;
            _frmCountry.StartPosition = FormStartPosition.CenterParent;
            _frmCountry.ShowDialog();
        }
        private void credentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCredential _frmCredential = new frmCredential(left, top, width, height);
            _frmCredential.TopMost = true;
            _frmCredential.ShowDialog();
        }
        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplication _frmApplication = new frmApplication(left, top, width, height);
            _frmApplication.TopMost = true;
            _frmApplication.ShowDialog();
        }
        private void dealersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDealer _frmDealer = new frmDealer(left, top, width, height);
            _frmDealer.TopMost = true;
            _frmDealer.ShowDialog();
        }
        private void dealerBranchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDealerBranches _frmDealerBranches = new frmDealerBranches(left, top, width, height);
            _frmDealerBranches.TopMost = true;
            _frmDealerBranches.ShowDialog();
        }

        #endregion

        #region "TAB - CONTACTS"

        #region "DATAGRIDVIEW - LOAD CONTACTS DATA"

        public void LoadContacts()
        {
            dgvContacts.DataSource = null;
            dgvContacts.Rows.Clear();
            dtContacts.Clear();

            foreach (Contact contact in databaseViewModel.ContactList)
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

            dgvContacts.ClearSelection();
        }

        #endregion

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

            dtContacts.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterContactField, txtContacts.Text);

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

        #region "BUTTONS STYLE"

        private void StyleContactButtons()
        {

            btnExportContactsToExcel.TabStop = false;
            btnExportContactsToExcel.FlatStyle = FlatStyle.Flat;
            btnExportContactsToExcel.FlatAppearance.BorderSize = 0;

            btnNewContact.TabStop = false;
            btnNewContact.FlatStyle = FlatStyle.Flat;
            btnNewContact.FlatAppearance.BorderSize = 0;

            btnEditContact.TabStop = false;
            btnEditContact.FlatStyle = FlatStyle.Flat;
            btnEditContact.FlatAppearance.BorderSize = 0;

            btnDeleteContact.TabStop = false;
            btnDeleteContact.FlatStyle = FlatStyle.Flat;
            btnDeleteContact.FlatAppearance.BorderSize = 0;
        }

        #endregion

        #region "DATAGRIDVIEW: DGVCONTACTS"

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
        private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditContact.Enabled = true;
            btnDeleteContact.Enabled = true;
        }

        #endregion

        #region "BUTTONS: NEW/EDIT/DELETE"

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            if ((dgvContacts.Rows.Count > 0))
            {
                Contact contact = new Contact();
                bool hasTheSaveButtonPressed = false;

                frmAddOrUpdateContact _frmAddOrUpdateContact = new frmAddOrUpdateContact(contact);
                this.TopMost = false;
                _frmAddOrUpdateContact.StartPosition = FormStartPosition.CenterParent;
                _frmAddOrUpdateContact.ShowDialog();

                hasTheSaveButtonPressed = _frmAddOrUpdateContact.hasTheSaveButtonPressed;

                if (hasTheSaveButtonPressed == true)
                {
                    Validation.LocalDatabaseConfig(true);
                    databaseViewModel = Services.GetDataFromDatabase();
                    LoadContacts();
                }

                dgvContacts.ClearSelection();
                txtContacts.Clear();
                btnEditContact.Enabled = false;
                btnDeleteContact.Enabled = false;

                _frmAddOrUpdateContact.Dispose();

            }
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            if ((dgvContacts.Rows.Count > 0))
            {
                Contact contact = new Contact();
                bool hasTheSaveButtonPressed = false;

                contact.Id = dgvContacts.CurrentRow.Cells[0].Value.ToString();
                contact.Name = dgvContacts.CurrentRow.Cells[1].Value.ToString();
                contact.Phone = dgvContacts.CurrentRow.Cells[2].Value.ToString();
                contact.CellPhone = dgvContacts.CurrentRow.Cells[3].Value.ToString();
                contact.TeamId = Convert.ToInt32(dgvContacts.CurrentRow.Cells[4].Value.ToString());
                contact.TeamName = dgvContacts.CurrentRow.Cells[5].Value.ToString();
                contact.Computer = dgvContacts.CurrentRow.Cells[6].Value.ToString();

                frmAddOrUpdateContact _frmAddOrUpdateContact = new frmAddOrUpdateContact(contact);
                this.TopMost = false;
                _frmAddOrUpdateContact.StartPosition = FormStartPosition.CenterParent;
                _frmAddOrUpdateContact.ShowDialog();
                
                hasTheSaveButtonPressed = _frmAddOrUpdateContact.hasTheSaveButtonPressed;

                if (hasTheSaveButtonPressed == true)
                {
                    Validation.LocalDatabaseConfig(true);
                    databaseViewModel = Services.GetDataFromDatabase();
                    LoadContacts();
                }

                dgvContacts.ClearSelection();
                txtContacts.Clear();
                btnEditContact.Enabled = false;
                btnDeleteContact.Enabled = false;

                _frmAddOrUpdateContact.Dispose();
                
            }
        }

        private void btnDeleteContact_Click(object sender, EventArgs e)
        {
            if (dgvContacts.Rows.Count > 0)
            {
                string ContactId = dgvContacts.CurrentRow.Cells[0].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete the contact " + ContactId + "?", "Delete Contact", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DALHelpers.DeleteContact(ContactId);

                    Contact contact = new Contact();

                    contact.Id = dgvContacts.CurrentRow.Cells[0].Value.ToString();
                    contact.Name = dgvContacts.CurrentRow.Cells[1].Value.ToString();
                    contact.Phone = dgvContacts.CurrentRow.Cells[2].Value.ToString();
                    contact.CellPhone = dgvContacts.CurrentRow.Cells[3].Value.ToString();
                    contact.TeamId = Convert.ToInt32(dgvContacts.CurrentRow.Cells[4].Value.ToString());
                    contact.TeamName = dgvContacts.CurrentRow.Cells[5].Value.ToString();
                    contact.Computer = dgvContacts.CurrentRow.Cells[6].Value.ToString();

                    ActivityLog.ContactLogger(contact, "DELETE", "Contact", Environment.UserName);

                    Validation.LocalDatabaseConfig(true);
                    databaseViewModel = Services.GetDataFromDatabase();
                    LoadContacts();
                }

                dgvContacts.ClearSelection();
                txtContacts.Clear();
                btnDeleteContact.Enabled = false;
                btnEditContact.Enabled = false;
            }
        }

        #endregion

        #region "EXPORT TO EXCEL"

        private void btnExportContactsToExcel_Click(object sender, EventArgs e)
        {
            if (dgvContacts.Rows.Count > 0)
            {
                List<ExportToExcelViewModel> exportToExcelList = new List<ExportToExcelViewModel>();

                exportToExcelList = GetExportToExcelList(dgvContacts);
                Services.ExportToExcel(exportToExcelList);
            }
        }

        #endregion

        #endregion

        #region "TAB - DEALERS"

        #region "BUTTONS STYLE"

        private void StyleDealerButtons()
        {
            btnExportDealersToExcel.TabStop = false;
            btnExportDealersToExcel.FlatStyle = FlatStyle.Flat;
            btnExportDealersToExcel.FlatAppearance.BorderSize = 0;

            btnNewDealerBranch.TabStop = false;
            btnNewDealerBranch.FlatStyle = FlatStyle.Flat;
            btnNewDealerBranch.FlatAppearance.BorderSize = 0;

            btnEditDealerBranch.TabStop = false;
            btnEditDealerBranch.FlatStyle = FlatStyle.Flat;
            btnEditDealerBranch.FlatAppearance.BorderSize = 0;

            btnDeleteDealerBranch.TabStop = false;
            btnDeleteDealerBranch.FlatStyle = FlatStyle.Flat;
            btnDeleteDealerBranch.FlatAppearance.BorderSize = 0;

            toolTip.SetToolTip(btnNewDealerBranch, "New Dealer Branch");
            toolTip.SetToolTip(btnEditDealerBranch, "Edit Dealer Branch");
            toolTip.SetToolTip(btnDeleteDealerBranch, "Delete Dealer Branch");
            toolTip.SetToolTip(chkDealerContacts, "View the Dealer Contacts");

            chkDealerContacts.TabStop = false;
            chkDealerContacts.FlatAppearance.BorderSize = 0;
        }

        #endregion

        #region "DATAGRIDVIEW - LOAD DEALERS DATA"
        public void LoadDealerBranches()
        {
            dgvDealers.DataSource = null;
            dgvDealers.Rows.Clear();
            dtDealers.Clear();

            foreach (DealerBranch dealer in databaseViewModel.DealerBranchesList)
            {
                dtDealers.Rows.Add(
                    dealer.DealerBranchId.ToString(),
                    dealer.CTDI.ToString(),
                    dealer.DealerName.ToString(),
                    dealer.BranchName.ToString(),
                    dealer.PhoneNumber.ToString(),
                    dealer.BaldoPartner.ToString(),
                    dealer.CountryId.ToString(),
                    dealer.CountryName.ToString(),
                    dealer.DealerId.ToString(),
                    dealer.CTDI.ToString() + dealer.PhoneNumber.ToString() + dealer.BaldoPartner.ToString() + dealer.CountryName.ToString() + dealer.DealerName.ToString() + Validation.RemoveDiacritics(dealer.DealerName.ToString()) + dealer.BranchName.ToString() + Validation.RemoveDiacritics(dealer.BranchName.ToString()),
                    dealer.DealerName.ToString() + dealer.BranchName.ToString());
            }

            dgvDealers.DataSource = dtDealers;

            dgvDealers.Columns[0].Visible = false;
            dgvDealers.Columns[6].Visible = false;
            dgvDealers.Columns[8].Visible = false;
            dgvDealers.Columns[9].Visible = false;
            dgvDealers.Columns[10].Visible = false;

            dgvDealers.Columns[1].Width = 50;
            dgvDealers.Columns[2].Width = 150;
            dgvDealers.Columns[3].Width = 150;
            dgvDealers.Columns[4].Width = 110;
            dgvDealers.Columns[5].Width = 70;
            dgvDealers.Columns[7].Width = 70;

            dgvDealers.Sort(dgvDealers.Columns["Sort"], ListSortDirection.Ascending);

            dgvDealers.ClearSelection();
        }
        #endregion

        #region "DATAGRIDVIEW - LOAD DEALER CONTACTS DATA"
        public void LoadDealerContacts()
        {
            dgvDealers.DataSource = null;
            dgvDealers.Rows.Clear();
            dtDealerContacts.Clear();

            foreach (DealerContact dealerContact in databaseViewModel.DealerContactList)
            {
                dtDealerContacts.Rows.Add(
                    dealerContact.DealerContactId.ToString(),
                    dealerContact.DealerId.ToString(),
                    dealerContact.DealerName.ToString(),
                    dealerContact.DealerContactName.ToString(),
                    dealerContact.Department.ToString(),
                    dealerContact.Phone.ToString(),
                    dealerContact.CellPhone.ToString(),
                    dealerContact.Email.ToString(),
                    dealerContact.CountryId.ToString(),
                    dealerContact.Country.ToString(),
                    dealerContact.DealerContactName.ToString() + dealerContact.DealerName.ToString() + Validation.RemoveDiacritics(dealerContact.DealerName.ToString())+ Validation.RemoveDiacritics(dealerContact.DealerContactName.ToString()) + Validation.RemoveDiacritics(dealerContact.Department.ToString()) + dealerContact.Department.ToString() + dealerContact.Phone.ToString() + dealerContact.CellPhone.ToString() + dealerContact.Country.ToString() + dealerContact.Email.ToString());
            }

            dgvDealers.DataSource = dtDealerContacts;

            dgvDealers.Columns[0].Visible = false;
            dgvDealers.Columns[1].Visible = false;
            dgvDealers.Columns[8].Visible = false;
            dgvDealers.Columns[10].Visible = false;

            dgvDealers.Columns[3].Width = 130;
            dgvDealers.Columns[3].Width = 130;
            dgvDealers.Columns[4].Width = 130;
            dgvDealers.Columns[5].Width = 180;
            dgvDealers.Columns[6].Width = 180;
            dgvDealers.Columns[7].Width = 130;
            dgvDealers.Columns[9].Width = 50;

            dgvDealers.ClearSelection();
            dgvDealers.Sort(dgvDealers.Columns["DealerName"], ListSortDirection.Ascending);

            if (dgvDealers.Rows.Count > 0)
            {
                dgvDealers.FirstDisplayedScrollingRowIndex = 0;
            }           
        }
        #endregion

        #region "DATAGRIDVIEW - CELL CLICK"
        private void dgvDealers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableOrDisableDealerBranchButtons(true);
        }

        #endregion

        #region "DEALERS - POP UP MENU"

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

        private void contextMenuStripDealers_Opening(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvDealers.CurrentCell.Value.ToString()) || (!string.IsNullOrWhiteSpace(dgvDealers.CurrentCell.Value.ToString())))
            {
                Clipboard.SetText(dgvDealers.CurrentCell.Value.ToString());
            }
        }

        #endregion

        #region "SEARCH BOX"

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
                dtDealerContacts.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterDealerContactField, txtDealers.Text);

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
                dtDealers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterDealerContactField, txtDealers.Text);

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

        #endregion

        #region "CHECKBOX DEALER BRANCHES/DEALER CONTACTS"

        private void chkDealerContacts_CheckedChanged(object sender, EventArgs e)
        {
            toolTip.ShowAlways = true;
            string MystringToSearch = txtDealers.Text;
            txtDealers.Clear();
            txtDealers.Text = MystringToSearch;

            if (chkDealerContacts.Checked == true)
            {
                toolTip.SetToolTip(chkDealerContacts, "Your are Viewing the Dealer Contacts");
                //chkDealerContacts.Text = "Viewing Dealer Contacts";

                chkDealerContacts.ImageIndex = 11;
                tabPage2.Text = "Dealer Contacts";
                tabPage2.ImageIndex = 10;

                isDealerContactView = true;
                toolTip.SetToolTip(btnNewDealerBranch, "New Dealer Contact");
                toolTip.SetToolTip(btnEditDealerBranch, "Edit Dealer Contact");
                toolTip.SetToolTip(btnDeleteDealerBranch, "Delete Dealer Contact");

                EnableOrDisableDealerBranchButtons(false);

                LoadDealerContacts();
            }
            else
            {
                toolTip.SetToolTip(chkDealerContacts, "View the Dealer Contacts");
                //chkDealerContacts.Text = "View Dealer Contacts";

                chkDealerContacts.ImageIndex = 10;
                tabPage2.Text = "Dealer Branches";
                tabPage2.ImageIndex = 2;

                isDealerContactView = false;
                toolTip.SetToolTip(btnNewDealerBranch, "New Dealer Branch");
                toolTip.SetToolTip(btnEditDealerBranch, "Edit Dealer Branch");
                toolTip.SetToolTip(btnDeleteDealerBranch, "Delete Dealer Branch");

                EnableOrDisableDealerBranchButtons(false);

                LoadDealerBranches();
            }
        }

        #endregion

        #region "BUTTONS: NEW/EDIT/DELETE"
        private void btnNewDealerBranch_Click(object sender, EventArgs e)
        {
            if ((dgvDealers.Rows.Count > 0))
            {
                if (isDealerContactView == true)
                {
                    DealerContact dealerContact = new DealerContact();
                    bool hasTheSaveButtonPressed = false;

                    frmAddOrUpdateDealerContact _frmAddOrUpdateDealerContact = new frmAddOrUpdateDealerContact(dealerContact);
                    this.TopMost = false;
                    _frmAddOrUpdateDealerContact.StartPosition = FormStartPosition.CenterParent;
                    _frmAddOrUpdateDealerContact.ShowDialog();

                    hasTheSaveButtonPressed = _frmAddOrUpdateDealerContact.hasTheSaveButtonPressed;

                    if (hasTheSaveButtonPressed == true)
                    {
                        Validation.LocalDatabaseConfig(true);
                        databaseViewModel = Services.GetDataFromDatabase();
                        LoadDealerContacts();
                    }

                    dgvDealers.ClearSelection();
                    txtDealers.Clear();

                    EnableOrDisableDealerBranchButtons(false);

                    _frmAddOrUpdateDealerContact.Dispose();

                }
                else
                {
                    DealerBranch dealer = new DealerBranch();
                    bool hasTheSaveButtonPressed = false;

                    frmAddOrUpdateDealerBranch _frmAddOrUpdateDealer = new frmAddOrUpdateDealerBranch(dealer);
                    this.TopMost = false;
                    _frmAddOrUpdateDealer.StartPosition = FormStartPosition.CenterParent;
                    _frmAddOrUpdateDealer.ShowDialog();

                    hasTheSaveButtonPressed = _frmAddOrUpdateDealer.hasTheSaveButtonPressed;

                    if (hasTheSaveButtonPressed == true)
                    {
                        Validation.LocalDatabaseConfig(true);
                        databaseViewModel = Services.GetDataFromDatabase();
                        LoadDealerBranches();
                    }

                    dgvDealers.ClearSelection();
                    txtDealers.Clear();

                    EnableOrDisableDealerBranchButtons(false);

                    _frmAddOrUpdateDealer.Dispose();

                }
            }
        }
        private void btnEditDealerBranch_Click(object sender, EventArgs e)
        {
            if ((dgvDealers.Rows.Count > 0))
            {
                if (isDealerContactView == true) //DealerContact
                {
                    DealerContact dealerContact = new DealerContact();
                    bool hasTheSaveButtonPressed = false;

                    dealerContact.DealerContactId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[0].Value.ToString());
                    dealerContact.DealerId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[1].Value.ToString());
                    dealerContact.DealerName = dgvDealers.CurrentRow.Cells[2].Value.ToString();
                    dealerContact.DealerContactName = dgvDealers.CurrentRow.Cells[3].Value.ToString();
                    dealerContact.Department = dgvDealers.CurrentRow.Cells[4].Value.ToString();
                    dealerContact.Phone = dgvDealers.CurrentRow.Cells[5].Value.ToString();
                    dealerContact.CellPhone = dgvDealers.CurrentRow.Cells[6].Value.ToString();
                    dealerContact.Email = dgvDealers.CurrentRow.Cells[7].Value.ToString();
                    dealerContact.CountryId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[8].Value.ToString());
                    dealerContact.Country = dgvDealers.CurrentRow.Cells[9].Value.ToString();

                    frmAddOrUpdateDealerContact _frmAddOrUpdateDealerContact = new frmAddOrUpdateDealerContact(dealerContact);
                    this.TopMost = false;
                    _frmAddOrUpdateDealerContact.StartPosition = FormStartPosition.CenterParent;
                    _frmAddOrUpdateDealerContact.ShowDialog();

                    hasTheSaveButtonPressed = _frmAddOrUpdateDealerContact.hasTheSaveButtonPressed;

                    if (hasTheSaveButtonPressed == true)
                    {
                        Validation.LocalDatabaseConfig(true);
                        databaseViewModel = Services.GetDataFromDatabase();
                        LoadDealerContacts();
                    }

                    dgvDealers.ClearSelection();
                    txtDealers.Clear();

                    EnableOrDisableDealerBranchButtons(false);

                    _frmAddOrUpdateDealerContact.Dispose();
                }
                else //DealerBranch
                {
                    DealerBranch dealerBranch = new DealerBranch();
                    bool hasTheSaveButtonPressed = false;

                    dealerBranch.DealerBranchId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[0].Value.ToString());
                    dealerBranch.CTDI = Convert.ToInt32(dgvDealers.CurrentRow.Cells[1].Value.ToString());
                    dealerBranch.DealerName = dgvDealers.CurrentRow.Cells[2].Value.ToString();
                    dealerBranch.BranchName = dgvDealers.CurrentRow.Cells[3].Value.ToString();
                    dealerBranch.PhoneNumber = dgvDealers.CurrentRow.Cells[4].Value.ToString();
                    dealerBranch.BaldoPartner = dgvDealers.CurrentRow.Cells[5].Value.ToString();
                    dealerBranch.CountryId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[6].Value.ToString());
                    dealerBranch.CountryName = dgvDealers.CurrentRow.Cells[7].Value.ToString();
                    dealerBranch.DealerId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[8].Value.ToString());

                    frmAddOrUpdateDealerBranch _frmAddOrUpdateDealer = new frmAddOrUpdateDealerBranch(dealerBranch);
                    this.TopMost = false;
                    _frmAddOrUpdateDealer.StartPosition = FormStartPosition.CenterParent;
                    _frmAddOrUpdateDealer.ShowDialog();

                    hasTheSaveButtonPressed = _frmAddOrUpdateDealer.hasTheSaveButtonPressed;

                    if (hasTheSaveButtonPressed == true)
                    {
                        Validation.LocalDatabaseConfig(true);
                        databaseViewModel = Services.GetDataFromDatabase();
                        LoadDealerBranches();
                    }

                    dgvDealers.ClearSelection();
                    txtDealers.Clear();

                    EnableOrDisableDealerBranchButtons(false);

                    _frmAddOrUpdateDealer.Dispose();
                }
            }
        }
        private void btnDeleteDealerBranch_Click(object sender, EventArgs e)
        {
            if ((dgvDealers.Rows.Count > 0))
            {
                if (isDealerContactView == true)
                {
                    int DealerBranchId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[0].Value.ToString());
                    string DealerContactName = dgvDealers.CurrentRow.Cells[3].Value.ToString();

                    if (MessageBox.Show("Are you sure you want to delete the Dealer Contact: " + DealerContactName + "?", "Delete Dealer Contact", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DALHelpers.DeleteDealerContact(DealerBranchId);

                        Validation.LocalDatabaseConfig(true);
                        databaseViewModel = Services.GetDataFromDatabase();
                        LoadDealerContacts();
                    }

                    dgvDealers.ClearSelection();
                    txtDealers.Clear();

                    EnableOrDisableDealerBranchButtons(false);
                }
                else
                {
                    DealerBranch dealerBranch = new DealerBranch();

                    dealerBranch.DealerBranchId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[0].Value.ToString());
                    dealerBranch.CTDI = Convert.ToInt32(dgvDealers.CurrentRow.Cells[1].Value.ToString());
                    dealerBranch.DealerName = dgvDealers.CurrentRow.Cells[2].Value.ToString();
                    dealerBranch.BranchName = dgvDealers.CurrentRow.Cells[3].Value.ToString();
                    dealerBranch.PhoneNumber = dgvDealers.CurrentRow.Cells[4].Value.ToString();
                    dealerBranch.BaldoPartner = dgvDealers.CurrentRow.Cells[5].Value.ToString();
                    dealerBranch.CountryId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[6].Value.ToString());
                    dealerBranch.CountryName = dgvDealers.CurrentRow.Cells[7].Value.ToString();
                    dealerBranch.DealerId = Convert.ToInt32(dgvDealers.CurrentRow.Cells[8].Value.ToString());

                    if (MessageBox.Show("Are you sure you want to delete the Dealer Branch: " + dealerBranch.BranchName + "?", "Delete Dealer Branch", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DALHelpers.DeleteDealerBranch(dealerBranch.DealerBranchId);

                        ActivityLog.DealerBranchLogger(dealerBranch, "DELETE", "Dealer Branch", Environment.UserName);

                        Validation.LocalDatabaseConfig(true);
                        databaseViewModel = Services.GetDataFromDatabase();
                        LoadDealerBranches();
                    }

                    dgvDealers.ClearSelection();
                    txtDealers.Clear();

                    EnableOrDisableDealerBranchButtons(false);
                }
            }
        }

        #endregion

        #region "EXPORT TO EXCEL"

        private void btnExportDealersToExcel_Click(object sender, EventArgs e)
        {
            if (dgvDealers.Rows.Count > 0)
            {
                List<ExportToExcelViewModel> exportToExcelList = new List<ExportToExcelViewModel>();

                exportToExcelList = GetExportToExcelList(dgvDealers);
                Services.ExportToExcel(exportToExcelList);
            }
        }

        #endregion

        #region "FUNCTIONS"

        private void EnableOrDisableDealerBranchButtons(bool ShouldTheButtonBeEnabled)
        {
            if (ShouldTheButtonBeEnabled == true)
            {
                btnEditDealerBranch.Enabled = true;
                btnDeleteDealerBranch.Enabled = true;
            }
            else
            {
                btnEditDealerBranch.Enabled = false;
                btnDeleteDealerBranch.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region "TAB - APPLICATIONS"

        #region "BUTTONS STYLE"

        private void StyleApplicationButtons()
        {
            btnNewApplication.TabStop = false;
            btnNewApplication.FlatStyle = FlatStyle.Flat;
            btnNewApplication.FlatAppearance.BorderSize = 0;

            btnEditApplication.TabStop = false;
            btnEditApplication.FlatStyle = FlatStyle.Flat;
            btnEditApplication.FlatAppearance.BorderSize = 0;

            btnDeleteApplication.TabStop = false;
            btnDeleteApplication.FlatStyle = FlatStyle.Flat;
            btnDeleteApplication.FlatAppearance.BorderSize = 0;

            //chkHidePasswords.TabStop = false;
            //chkHidePasswords.FlatStyle = FlatStyle.Flat;
            //chkHidePasswords.FlatAppearance.BorderSize = 0;
        }

        #endregion

        #region "TREVIEW"

        #region "LOAD TREEVIEW"

        public void LoadTreeview(bool loadingFromSearchBox, List<AppLinks> AppLinksFromSearchBox)

        {
            bool found = false;

            int parentNodeCounter = 0;

            treeView1.Nodes.Clear();

            //LOOPING THROUGH ALL THE APPLICATION RECORDS
            foreach (App application in databaseViewModel.ApplicationsList)
            {
                var _appLinks = new List<AppLinks>();

                // REMOVING THE APPLINKS THAT ARE NOT RELATED TO THE APPLICATION THAT IS BEING ADDED TO THIS NODE

                // TREEVIEW
                // false = LOADING TREEVIEW WITH ALL THE DATA FROM THE DATABASE
                // true = LOADING THE TREEVIEW WITH THE DATA FOUND FROM THE WORD TYPED IN THE SEARCH BOX.

                // LOADING TREEVIEW
                if (loadingFromSearchBox == false)
                {
                    foreach (AppLinks item in databaseViewModel.AppLinksList)
                    {
                        if (application.ApplicationId == item.ApplicationId)
                        {
                            _appLinks.Add(item);
                        }
                    }
                }
                else // LOADING TREEVIEW FROM SEARCH BOX
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

                    var countriesDictionary = new Dictionary<int, string>();

                    // ADDING THE APPLICATION NAME
                    treeView1.Nodes.Add(application.ApplicationName.ToString());
                    treeView1.Nodes[parentNodeCounter].ForeColor = Color.DarkBlue;
                    treeView1.Nodes[parentNodeCounter].ImageIndex = 15;
                    treeView1.Nodes[parentNodeCounter].SelectedImageIndex = 15;

                    found = false;

                    foreach (AppLinks apps in _appLinks)
                    {

                        found = false;
                        foreach (var country in countriesDictionary.Values)
                        {
                            if (apps.CountryName.ToString() == country.ToString())
                            {
                                found = true;
                            }
                        }
                        if (found == false)
                        {
                            if (countriesDictionary.Count == 0)
                            {
                                countryNode = 0;
                            }
                            else
                            {
                                countryNode += 1;
                            }

                            // ADDING COUNTRY NAME
                            treeView1.Nodes[parentNodeCounter].Nodes.Add(apps.CountryName);
                            countriesDictionary.Add(countryNode, apps.CountryName);

                            // GETTING THE COUNTRY FLAG ID
                            int countryFlagId = Validation.GetCountryFlagId(apps.CountryName);

                            // ADDING THE FLAG BY THE ID
                            treeView1.Nodes[parentNodeCounter].Nodes[countryNode].ImageIndex = countryFlagId;
                            treeView1.Nodes[parentNodeCounter].Nodes[countryNode].SelectedImageIndex = countryFlagId;
                        }
              
                        foreach (var country in countriesDictionary)
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
                                    AddToLinks(apps.Link.ToString());

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
                                    //treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes.Add(apps.Username.ToString() + " (" + apps.CredentialDescription + ")");
                                    treeView1.Nodes[parentNodeCounter].Nodes[country.Key].Nodes[descriptionNode[country.Key]].Nodes.Add(apps.Username.ToString());
                                    AddToLinks(apps.Username.ToString());

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

                                    AddToLinks(DescriptedPassword);
                                    AddToPasswordList(apps.CredentialId, DescriptedPassword);

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

        #region "MOUSE RIGHT CLICK"

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (var password in passwordList.Values)
                {
                    TreeNode tnPwd = treeView1.SelectedNode;

                    if (tnPwd != null)
                    {
                        if (treeView1.SelectedNode.Text.ToString() == password.ToString())
                        {
                            //MessageBox.Show(item.ToString());

                            updatePasswordToolStripMenuItem.Visible = true;
                            contextMenuStripApps.Show(Cursor.Position.X, Cursor.Position.Y);

                            break;
                        }
                    }
                }
            }
        }

        #endregion 

        #region "HTTP HYPERLINK"

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

        #endregion

        #region "SHOW/HIDE PASSWORD"

        private void chkHidePasswords_CheckedChanged(object sender, EventArgs e)
        {
            if (hasTheTreeviewNodeSelected == false)
            {
                txtAppSearch.Text = treeviewNodeExpandText;
            }

            if (chkHidePasswords.Checked)
            {
                chkHidePasswords.ImageIndex = 12;
            }else
            {
                chkHidePasswords.ImageIndex = 13;
            }

            if (string.IsNullOrEmpty(txtAppSearch.Text))
            {
                LoadTreeview(false, null);
            }
            else
            {
                List<AppLinks> _appLinks = new List<AppLinks>();

                foreach (AppLinks item in databaseViewModel.AppLinksList)
                {
                    if (item.SearchString.ToUpper().Contains(txtAppSearch.Text.ToUpper()))
                    {
                        _appLinks.Add(item);
                    }
                }

                if (_appLinks.Count > 0)
                {
                    treeView1.Nodes.Clear();
                    LoadTreeview(true, _appLinks);
                    treeView1.ExpandAll();
                }
                else
                {
                    treeView1.Nodes.Clear();
                }
            }
        }

        #endregion

        #region "CTRL+C - COPY TO CLIPBOARD | ENABLE NEW/EDIT/DELETE BUTTONS"

            private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
            {
                btnEditApplication.Enabled = false;
                btnDeleteApplication.Enabled = false;

                List<AppLinks> appLinksFromDatabase = new List<AppLinks>();

                appLinksFromDatabase = DALHelpers.GetAppLinkByDescription(e.Node.Text);

                if (appLinksFromDatabase.Count > 0)
                {
                    btnEditApplication.Enabled = true;
                    btnDeleteApplication.Enabled = true;
                }

                try
                {
                    Clipboard.SetText(e.Node.Text);
                    hasTheTreeviewNodeSelected = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Oops. The text could not be copied to the clipboard. Please try again! Error Message: " + err.Message, "Error to copy text to the Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        #endregion

        #region "TREEVIEW EXPAND - WHAT NODE WAS CLICKED"
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            treeviewNodeExpandText = e.Node.Text;
            hasTheTreeviewNodeSelected = false;
        }

        #endregion

        #endregion

        #region "SEARCH BOX"

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
                    LoadAppsFromSearchBox();
                }

                if (string.IsNullOrEmpty(txtAppSearch.Text))
                {
                    treeView1.Nodes.Clear();
                    LoadTreeview(false, null);
                    lblClearAppSearch.Visible = false;
                }
                else
                {
                    lblClearAppSearch.Visible = true;
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

        #endregion

        #region "BUTTONS: NEW/EDIT/DELETE"

        //NEW
        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            AppLinks appLinks = new AppLinks();

            bool hasTheSaveButtonPressed = false;

            frmAddOrUpdateAppLinks _frmAddOrUpdateAppLinks = new frmAddOrUpdateAppLinks(appLinks);
            this.TopMost = false;
            _frmAddOrUpdateAppLinks.StartPosition = FormStartPosition.CenterParent;
            _frmAddOrUpdateAppLinks.ShowDialog();

            hasTheSaveButtonPressed = _frmAddOrUpdateAppLinks.hasTheSaveButtonPressed;

            if (hasTheSaveButtonPressed == true)
            {
                Validation.LocalDatabaseConfig(true);
                databaseViewModel = Services.GetDataFromDatabase();
                LoadTreeview(false, null);
            }

            txtAppSearch.Clear();

            _frmAddOrUpdateAppLinks.Dispose();
        }

        //EDIT
        private void btnEditApplication_Click(object sender, EventArgs e)
        {
            if (databaseViewModel.AppLinksList.Count > 0)
            {
                TreeNode tn = treeView1.SelectedNode;

                if (tn != null)
                {
                    List<AppLinks> AppLinksFromDatabase = new List<AppLinks>(); 
                    AppLinksFromDatabase = DALHelpers.GetAppLinkByDescription(treeView1.SelectedNode.Text);

                    if (AppLinksFromDatabase.Count > 0)
                    {
                        //MessageBox.Show(treeView1.SelectedNode.Text);

                        AppLinks appLinks = new AppLinks();
                        bool hasTheSaveButtonPressed = false;

                        appLinks.AppLinkId = AppLinksFromDatabase[0].AppLinkId;
                        appLinks.AppCategoryId = AppLinksFromDatabase[0].AppCategoryId;
                        appLinks.AppCategoryName = AppLinksFromDatabase[0].AppCategoryName;
                        appLinks.AppEnvironmentId = AppLinksFromDatabase[0].AppEnvironmentId;
                        appLinks.ApplicationId = AppLinksFromDatabase[0].ApplicationId;
                        appLinks.ApplicationName = AppLinksFromDatabase[0].ApplicationName;
                        appLinks.Description = AppLinksFromDatabase[0].Description;
                        appLinks.Link = AppLinksFromDatabase[0].Link;
                        appLinks.CredentialId = AppLinksFromDatabase[0].CredentialId;
                        appLinks.CredentialDescription = AppLinksFromDatabase[0].CredentialDescription;
                        appLinks.CountryId = AppLinksFromDatabase[0].CountryId;
                        appLinks.CountryName = AppLinksFromDatabase[0].CountryName;

                        frmAddOrUpdateAppLinks _frmAddOrUpdateAppLinks = new frmAddOrUpdateAppLinks(appLinks);
                        this.TopMost = false;
                        _frmAddOrUpdateAppLinks.StartPosition = FormStartPosition.CenterParent;
                        _frmAddOrUpdateAppLinks.ShowDialog();

                        hasTheSaveButtonPressed = _frmAddOrUpdateAppLinks.hasTheSaveButtonPressed;

                        if (hasTheSaveButtonPressed == true)
                        {
                            Validation.LocalDatabaseConfig(true);
                            databaseViewModel = Services.GetDataFromDatabase();
                            LoadTreeview(false, null);
                        }

                        txtAppSearch.Clear();

                        _frmAddOrUpdateAppLinks.Dispose();

                    }

                    btnEditApplication.Enabled = false;
                    btnDeleteApplication.Enabled = false;
            }

            }
        }

        //DELETE
        private void btnDeleteApplication_Click(object sender, EventArgs e)
        {
            if (databaseViewModel.AppLinksList.Count > 0)
            {
                TreeNode tn = treeView1.SelectedNode;

                if (tn != null)
                {
                    List<AppLinks> AppLinksFromDatabase = new List<AppLinks>();
                    AppLinksFromDatabase = DALHelpers.GetAppLinkByDescription(treeView1.SelectedNode.Text);

                    if (AppLinksFromDatabase.Count > 0)
                    {
                        AppLinks appLinks = new AppLinks();

                        appLinks.AppLinkId = AppLinksFromDatabase[0].AppLinkId;
                        appLinks.AppCategoryId = AppLinksFromDatabase[0].AppCategoryId;
                        appLinks.AppCategoryName = AppLinksFromDatabase[0].AppCategoryName;
                        appLinks.AppEnvironmentId = AppLinksFromDatabase[0].AppEnvironmentId;
                        appLinks.ApplicationId = AppLinksFromDatabase[0].ApplicationId;
                        appLinks.ApplicationName = AppLinksFromDatabase[0].ApplicationName;
                        appLinks.Description = AppLinksFromDatabase[0].Description;
                        appLinks.Link = AppLinksFromDatabase[0].Link;
                        appLinks.CredentialId = AppLinksFromDatabase[0].CredentialId;
                        appLinks.CredentialDescription = AppLinksFromDatabase[0].CredentialDescription;
                        appLinks.CountryId = AppLinksFromDatabase[0].CountryId;
                        appLinks.CountryName = AppLinksFromDatabase[0].CountryName;

                        DialogResult dialog = new DialogResult();

                        dialog = MessageBox.Show("Do you want to delete the AppLink: " + appLinks.Description + "?", "Delete AppLink", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (dialog == DialogResult.OK)
                        {
                            bool deleteOk = DALHelpers.DeleteAppLink(appLinks.AppLinkId);

                            if (deleteOk == true)
                            {
                                ActivityLog.AppLinksLogger(appLinks, "DELETE", "AppLinks", Environment.UserName);

                                Validation.LocalDatabaseConfig(true);
                                databaseViewModel = Services.GetDataFromDatabase();
                                txtAppSearch.Clear();

                                LoadTreeview(false, null);
                            }
                        }
                    }
                }
            }
        }

        #endregion



        #endregion

        #region "FUNCTIONS"

        private void AddToLinks(string stringToCompare)
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
        private void AddToPasswordList(int Key, string stringToCompare)
        {
            var found = false;

            foreach (var password in passwordList.Values)
            {
                if (password.ToString() == stringToCompare)
                {
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                passwordList.Add(Key, stringToCompare);
            }
        }
        private void SetTopMostWindowSetting()
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
        private void LoadAppsFromSearchBox()
        {
            List<AppLinks> _appLinks = new List<AppLinks>();
           
            foreach (AppLinks item in databaseViewModel.AppLinksList)
            {
                if (item.SearchString.ToUpper().Contains(txtAppSearch.Text.ToUpper()))
                {
                    _appLinks.Add(item);
                }
            }

            if (_appLinks.Count > 0)
            {
                LoadTreeview(true, _appLinks);
                treeView1.ExpandAll();
            }
            else //IF NO RESULTS IS RETURNED, THE TREEVIEW IS CLEARED.
            {
                treeView1.Nodes.Clear();
            }
        }
        private List<ExportToExcelViewModel> GetExportToExcelList(DataGridView dataGrid)
        {
            int colCounter = 1;

            List<ExportToExcelViewModel> exportToExcelList = new List<ExportToExcelViewModel>();

            //HEADER
            for (int i = 1; i < dataGrid.Columns.Count; i++)
            {
                if (dataGrid.Columns[i -1].Visible)
                {
                    ExportToExcelViewModel exportToExcelViewModel = new ExportToExcelViewModel();
                    exportToExcelViewModel.Row = 1;
                    exportToExcelViewModel.Col = colCounter;
                    exportToExcelViewModel.Text = dataGrid.Columns[i - 1].HeaderText;

                    Console.WriteLine(dataGrid.Columns[i - 1].HeaderText);

                    exportToExcelList.Add(exportToExcelViewModel);

                    colCounter++;
                }
            }

            //DATA
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                colCounter = 0;

                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    if (dataGrid.Columns[j].Visible)
                    {
                        ExportToExcelViewModel exportToExcelViewModel = new ExportToExcelViewModel();
                        exportToExcelViewModel.Row = i + 2;
                        exportToExcelViewModel.Col = colCounter + 1;
                        exportToExcelViewModel.Text = dataGrid.Rows[i].Cells[j].Value.ToString();

                        exportToExcelList.Add(exportToExcelViewModel);

                        colCounter++;
                    }
                }
            }

            return exportToExcelList;
        }
        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout aboutWindow = new frmAbout(left, top, width, height);
            aboutWindow.TopMost = true;
            aboutWindow.ShowDialog();
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
    }
}
