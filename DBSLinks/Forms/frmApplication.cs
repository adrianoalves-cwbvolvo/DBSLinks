using Links.Controller;
using Links.Logger;
using Links.Model.ModelView;
using LinksForm.Controller;
using LinksForm.DAL;
using LinksForm.Forms;
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
    public partial class frmApplication : Form
    {
        private List<App> applicationList = new List<App>();
        private DataTable dtApplications = new DataTable();
        private string FilterContactField = "StringToSearch";

        //private DatabaseViewModel databaseViewModel = new DatabaseViewModel();

        private int left, top, width, height;

        private void dgvApplications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditApplication.Enabled = true;
            btnDeleteApplication.Enabled = true;
        }

        public frmApplication(int _left, int _top, int _width, int _height)
        {
            left = _left;
            top = _top;
            width = _width;
            height = _height;

            InitializeComponent();

            left = (left - 20) + (width / 4);
            top = top + (height / 4);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            dtApplications.Columns.Add("ApplicationId", typeof(int));
            dtApplications.Columns.Add("Application Name", typeof(string));
            dtApplications.Columns.Add("StringToSearch", typeof(string));

            applicationList = loadApplications();
        }

        private void txtSearchApplication_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;

            oldText = txtSearchApplication.Text;

            if ((txtSearchApplication.Text.All(chr => char.IsLetterOrDigit(chr))) || (txtSearchApplication.Text.Contains(" ")) || (txtSearchApplication.Text.Contains("-")) || (txtSearchApplication.Text.Contains(".")))
            {
                txtSearchApplication.Text = oldText;
            }
            else
            {
                txtSearchApplication.Text = oldText.Remove(oldText.Length - 1);
            }

            txtSearchApplication.SelectionStart = txtSearchApplication.Text.Length;

            dtApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterContactField, txtSearchApplication.Text);

            if (string.IsNullOrEmpty(txtSearchApplication.Text))
            {
                lblClearSearchApplication.Visible = false;
            }
            else
            {
                lblClearSearchApplication.Visible = true;
            }
        }

        private void lblClearSearchApplication_Click(object sender, EventArgs e)
        {
            txtSearchApplication.Clear();
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            bool HasTheSaveButtonPressed = false;

            App app = new App();

            frmAddOrUpdateApplication _frmAddOrUpdateApplication = new frmAddOrUpdateApplication(left, top, width, height, app);
            _frmAddOrUpdateApplication.TopMost = true;
            _frmAddOrUpdateApplication.ShowDialog();

            HasTheSaveButtonPressed = _frmAddOrUpdateApplication.HasTheSaveButtonPressed;

            if (HasTheSaveButtonPressed == true)
            {
                Validation.localDatabaseConfig(true);
                //databaseViewModel = Services.GetDataFromDatabase();
                applicationList = loadApplications();
            }

            dgvApplications.ClearSelection();
            txtSearchApplication.Clear();
            btnEditApplication.Enabled = false;
            btnDeleteApplication.Enabled = false;

            _frmAddOrUpdateApplication.Dispose();
        }

        private void btnEditApplication_Click(object sender, EventArgs e)
        {
            if ((dgvApplications.Rows.Count > 0))
            {
                App app = new App();
                bool HasTheSaveButtonPressed = false;

                app.ApplicationId = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value.ToString());
                app.ApplicationName = dgvApplications.CurrentRow.Cells[1].Value.ToString();

                frmAddOrUpdateApplication _frmAddOrUpdateApplication = new frmAddOrUpdateApplication(left, top, width, height, app);
                this.TopMost = false;
                _frmAddOrUpdateApplication.StartPosition = FormStartPosition.CenterParent;
                _frmAddOrUpdateApplication.ShowDialog();

                HasTheSaveButtonPressed = _frmAddOrUpdateApplication.HasTheSaveButtonPressed;

                if (HasTheSaveButtonPressed == true)
                {
                    Validation.localDatabaseConfig(true);
                    //databaseViewModel = Services.GetDataFromDatabase();
                    applicationList = loadApplications();
                }

                dgvApplications.ClearSelection();
                txtSearchApplication.Clear();
                btnEditApplication.Enabled = false;
                btnDeleteApplication.Enabled = false;

                _frmAddOrUpdateApplication.Dispose();

            }
        }

        private void btnDeleteApplication_Click(object sender, EventArgs e)
        {
            if (dgvApplications.Rows.Count > 0)
            {
                int CountryId = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value.ToString());
                string CountryName = dgvApplications.CurrentRow.Cells[1].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete the Application " + CountryName + "?", "Delete Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    App app = new App();

                    app.ApplicationId = Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value.ToString());
                    app.ApplicationName = dgvApplications.CurrentRow.Cells[1].Value.ToString();

                    DALHelpers.DeleteApplication(CountryId);

                    ActivityLog.ApplicationLogger(app, "DELETE", "", Environment.UserName);

                    Validation.localDatabaseConfig(true);
                    //databaseViewModel = Services.GetDataFromDatabase();
                    loadApplications();
                }

                dgvApplications.ClearSelection();
                txtSearchApplication.Clear();
                btnEditApplication.Enabled = false;
                btnDeleteApplication.Enabled = false;
            }
        }

        private List<App> loadApplications()
        {
            var countryList = new List<App>();

            applicationList = DALHelpers.GetApplications();

            dgvApplications.DataSource = null;
            dgvApplications.Rows.Clear();
            dtApplications.Clear();

            foreach (App app in applicationList)
            {
                dtApplications.Rows.Add(

                    app.ApplicationId.ToString(),
                    app.ApplicationName.ToString(),
                    app.ApplicationId.ToString() + app.ApplicationName.ToString());
            }

            dgvApplications.DataSource = dtApplications;
            dgvApplications.Columns[0].Width = 100;
            dgvApplications.Columns[1].Width = 280;
            dgvApplications.Columns[0].Visible = false;
            dgvApplications.Columns[2].Visible = false;

            dgvApplications.Sort(dgvApplications.Columns["Application Name"], ListSortDirection.Ascending);

            return applicationList;
        }
        private void StyleCountryButtons()
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
        }
    }
}
