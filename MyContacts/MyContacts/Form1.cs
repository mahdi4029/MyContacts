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
            if (dgvContacts.CurrentRow!=null)
            {
                if (MessageBox.Show("آیا از حذف فرد مورد نظر مطمئن هستید ؟","هشدار",MessageBoxButtons.YesNo)==DialogResult.Yes)
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
                
            }
            else
            {
                MessageBox.Show("لطفا شخصی را جهت ویرایش انتخاب کنید", "هشدار", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
