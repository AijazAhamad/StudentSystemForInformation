using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentSystemForInformationCRUD
{
    public partial class FrmNewStudent : Form
    {
        DB_Access access = new DB_Access();
        public FrmNewStudent()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            access.addstudent(txtRegNo.Text, txtFName.Text, txtLName.Text, txtPhone.Text);
            MessageBox.Show("Successfully added");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRegNo.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtPhone.Text = "";
        }
    }
}
