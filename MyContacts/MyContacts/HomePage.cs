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
            if (frmAddPerson.DialogResult == DialogResult.OK)
            {
                UpdateContacts();
                MessageBox.Show("شخص جدید با موفقیت افزوده شد", "پیغام", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = dgvContacts.CurrentRow.Cells[1].Value.ToString();
            string family = dgvContacts.CurrentRow.Cells[2].Value.ToString();
            if (dgvContacts.CurrentRow!=null)
            {
                if (MessageBox.Show($"آیا از حذف {name+""+family} مطمئن هستید؟","هشدار",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    _contacts.Delete((int)dgvContacts.CurrentRow.Cells[0].Value);
                    UpdateContacts();
                    MessageBox.Show("حذف با موفقیت انجام شد");
                }
            }
            else
            {
                MessageBox.Show("لطفا شخصی را در جدول انتخاب کنید", "پیغام", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvContacts.CurrentRow!=null)
            {
                EditPerson editPerson = new EditPerson();
                editPerson.contactId = (int)dgvContacts.CurrentRow.Cells[0].Value;
                editPerson.ShowDialog();
                if (editPerson.DialogResult==DialogResult.OK)
                {
                    UpdateContacts();
                    MessageBox.Show("عملیات ویرایش با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("لطفا شخصی را جهت ویرایش انتخاب کنید", "هشدار", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           DataTable dataTable = _contacts.Search(txtSearch.Text);
           dgvContacts.DataSource = dataTable;
        }
    }
}
