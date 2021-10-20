using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyContacts.Repository;

namespace MyContacts
{
    public partial class EditPerson : Form
    {
        private IContacts _contacts;
        public int contactId=0;
        public EditPerson()
        {
            InitializeComponent();
            _contacts = new Contacts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                _contacts.Edit(contactId, txtName.Text, txtFamily.Text, txtAge.Text,txtMobile.Text, txtAddress.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void EditPerson_Load(object sender, EventArgs e)
        {
           DataTable dataTable = _contacts.Select(contactId);

           txtName.Text = dataTable.Rows[0][1].ToString();
           txtFamily.Text = dataTable.Rows[0][2].ToString();
           txtAge.Text = dataTable.Rows[0][3].ToString();
           txtMobile.Text = dataTable.Rows[0][4].ToString();
           txtAddress.Text = dataTable.Rows[0][5].ToString();
        }

        bool ValidateInput()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا موبایل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("لطفا آدرس را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
