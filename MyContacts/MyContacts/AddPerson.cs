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
    public partial class AddPerson : Form
    {
        private IContacts _contacts;
        public AddPerson()
        {
            InitializeComponent();
            _contacts = new Contacts();
        }

        private void AddPerson_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                _contacts.AddPerson(txtName.Text, txtFamily.Text, txtAge.Text, txtMobile.Text, txtAddress.Text);
                DialogResult = DialogResult.OK;
            }
        }

        bool ValidateInput()
        {
            if (txtName.Text=="")
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
