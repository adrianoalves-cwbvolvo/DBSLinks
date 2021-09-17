using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinksForm.Controller;
using LinksForm.Model;
using LinksForm.DAL;
using Links.Model;
using Links.Logger;

namespace LinksForm.Forms
{
    public partial class frmAddOrUpdateContact : Form
    {
        private List<Team> teamList = new List<Team>();
        public bool hasTheSaveButtonPressed { get; set; }

        public frmAddOrUpdateContact(Contact contact)
        {
            InitializeComponent();

            teamList = DALHelpers.GetTeams();
            hasTheSaveButtonPressed = false;

            int counter = 0;

            if (!string.IsNullOrEmpty(contact.Id))
            {
                foreach (Team team in teamList)
                {
                    cmbTeam.Items.Add(team.TeamName.ToString());

                    if (contact.TeamId == team.TeamId)
                    {
                        cmbTeam.SelectedIndex = counter;
                    }

                    counter++;
                }

                this.Text = "Update Contact";
                txtUserID.Text = contact.Id;
                txtUserID.Enabled = false;
                txtName.Text = contact.Name;
                txtPhone.Text = contact.Phone;
                txtCellPhone.Text = contact.CellPhone;
                txtComputer.Text = contact.Computer;
            }
            else
            {
                foreach (Team team in teamList)
                {
                    cmbTeam.Items.Add(team.TeamName.ToString());
                }

                this.Text = "New Contact";
                txtUserID.Enabled = Enabled;
            }

            cmbTeam.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            hasTheSaveButtonPressed = true;

            Contact contact = new Contact();
            bool ok = false;

            contact.Id = txtUserID.Text;
            contact.Name = txtName.Text;
            contact.CellPhone = txtCellPhone.Text;
            contact.Phone = txtPhone.Text;
            contact.Computer = txtComputer.Text;

            foreach (Team team in teamList)
            {
                if (cmbTeam.Text == team.TeamName)
                {
                    contact.TeamId = team.TeamId;
                    contact.TeamName = team.TeamName;
                }
            }

            if (Validation.ContactDataValidation(contact))
            {
                MessageBox.Show("Please enter the Contact details.");
                return;
            }

            if (txtUserID.Enabled == false)
            {
                //UPDATE
                ok = DALHelpers.UpdateContact(contact);

                if (ok == true)
                {
                    MessageBox.Show("The record was successfully saved!");
                }
                else
                {
                    MessageBox.Show("Error: An error has ocurred when trying to update the Contact!");
                }

                ActivityLog.ContactLogger(contact, "UPDATE", "Contact", Environment.UserName);
                this.Close();
            }
            else //NEW CONTACT
            {
                List<Contact> contactList = new List<Contact>();

                contactList = DALHelpers.GetContactById(contact.Id);
                if (contactList.Count > 0)
                {
                    MessageBox.Show("Error: The ID: " + contact.Id + " already exists in the database!");
                    return;
                }
                else
                {
                    ok = DALHelpers.AddContact(contact);

                    if (ok == true)
                    {
                        ActivityLog.ContactLogger(contact, "CREATE", "Contact", Environment.UserName);
                        MessageBox.Show("The record was successfully saved!");
                    }
                }
                
                this.Close();
            }
        }
    }
}
