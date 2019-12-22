using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TooSharp.Models;
namespace contacts_crud_demo
{
    public partial class frmAddEditContact : Form
    {

        Contact _Contact = null;
        public frmAddEditContact()
        {
            InitializeComponent();
            lblTitle.Text = "Add Customer";
        }

        public frmAddEditContact(Contact contact)
        {
            InitializeComponent();
            btn1.Text = "Update";
            btn2.Visible = true;
            _Contact = contact;
            lblTitle.Text = "Update Customer";
            //Validation
            _Contact.onValidationError += Contact_onValidationError;

            txtFirstName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName;
            txtEmail.Text = _Contact.Email;
            txtMobile.Text = _Contact.Mobile;
        }
        void ShowError(string Text)
        {
            lblError.Text = Text;
            pnlError.Visible = true;
            tmrError.Start();
        }


        private void tmrError_Tick(object sender, EventArgs e)
        {
            tmrError.Stop();
            pnlError.Visible = false;

        }

        //create and update using toosharp
        private void btn1_Click(object sender, EventArgs e)
        {
            if (_Contact == null)
            {
                //new contact
                Contact contact = new Contact()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Mobile = txtMobile.Text

                };
                //Validation
                contact.onValidationError += Contact_onValidationError;

                //save
                if (contact.Save() > 0)
                {
                    MessageBox.Show("Contact Saved");
                    this.Close();
                }
            }
            else
            {
                //update contact
                _Contact.FirstName = txtFirstName.Text;
                _Contact.LastName = txtLastName.Text;
                _Contact.Email = txtEmail.Text;
                _Contact.Mobile = txtMobile.Text;
                //save
                if (_Contact.Save() > 0) MessageBox.Show("Contact Updated");
            }
            //MessageBox.Show("Contact Updated");
            this.Close();
        }

        private void Contact_onValidationError(object sender, TooSharp.Core.TsExeptionArgs e)
        {
            ShowError(e.exception.Message);
        }
    }
}
