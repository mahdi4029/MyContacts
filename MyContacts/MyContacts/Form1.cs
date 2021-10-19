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
    public partial class Form1 : Form
    {
        private IContacts _contacts;

        public Form1()
        {
            InitializeComponent();
            _contacts = new Contacts();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateContacts();
        }

        private void UpdateContacts()
        {
            dgvContacts.AutoGenerateColumns = false;
            dgvContacts.DataSource = _contacts.GetAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateContacts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPerson frmAddPerson = new AddPerson();
            frmAddPerson.ShowDialog();
        }
    }
}
