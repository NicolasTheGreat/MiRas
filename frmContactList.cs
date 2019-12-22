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
    public partial class frmContactList : Form
    {
        public frmContactList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmAddEditContact().ShowDialog();
            ReloadData();
        }

        void ReloadData()
        {
            if(txtSearch.Text.Trim().Length>0)
            {
                //serch data
                PopulateData(Contacts.Records()
                    .Where(Contacts.COLUMNS.Email,"LIKE","%"+txtSearch.Text+"%")
                    .Get());
            }
            else
            {
                //fetch all data
                PopulateData( Contacts.Records().Get());
            }
        }

        void PopulateData(IEnumerable<Contact> contacts)
        {
            table.Rows.Clear();
            foreach (var c in contacts)
            {
                table.Rows.Add(new object[]{
                    c.Id,
                    c.FirstName,
                    c.LastName,
                    c.Email,
                    c.Mobile,
                    "Edit",
                    "Delete"
                });
                table.Rows[table.RowCount - 1].Tag = c;
            }
        }

        private void frmContactList_Shown(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ReloadData();
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5) //edit
            {
                new frmAddEditContact((Contact)table.CurrentRow.Tag).ShowDialog();
                ReloadData();
            }
            if (e.ColumnIndex == 6) //delete
            {
                Contact contact = (Contact)table.CurrentRow.Tag;
                if (MessageBox.Show("Delete "+contact.FirstName+"?","CONFIRM",MessageBoxButtons.YesNoCancel)==DialogResult.Yes)
                {
                    contact.Delete();
                    ReloadData();
                }
            }
        }
    }
}
