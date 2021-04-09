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

namespace LinksForm.Forms
{
    public partial class frmAddOrUpdateContact : Form
    {
        public frmAddOrUpdateContact(string ContactId, string Name, string Phone, string Computer)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(ContactId))
            {
                this.Text = "Update Contact";
                txtUserID.Text = ContactId;
                txtUserID.Enabled = false;
                txtName.Text = Name;
                txtPhone.Text = Phone;
                txtComputer.Text = Computer;
            }
            else
            {
                this.Text = "New Contact";
                txtUserID.Enabled = Enabled;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            bool ok = false;

            if (Validation.ContactDataValidation(txtUserID.Text, txtName.Text, txtPhone.Text))
            {
                MessageBox.Show("Please enter the Contact details.");
                return;
            }
            else
            {
                contact.Id = txtUserID.Text;
                contact.Name = txtName.Text;
                contact.Phone = txtPhone.Text;
                contact.Computer = txtComputer.Text;
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

                this.Close();
            }
            else //NEW CONTACT
            {
                List<Contact> contactList = new List<Contact>();

                contactList = DALHelpers.GetContactById(contact.Id);
                if (contactList.Count > 0)
                {
                    MessageBox.Show("Error: The ID: " + contact.Id + " ,already exists in the database!");
                }
                else
                {
                    ok = DALHelpers.AddContact(contact);

                    if (ok == true)
                    {
                        MessageBox.Show("The record was successfully saved!");
                    }
                }
                
                this.Close();
            }
        }
    }
}
