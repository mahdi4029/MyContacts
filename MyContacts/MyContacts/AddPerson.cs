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
            _contacts.AddPerson(txtName.Text, txtFamily.Text, txtAge.Text, txtMobile.Text, txtAddress.Text);
        }
    }
}
