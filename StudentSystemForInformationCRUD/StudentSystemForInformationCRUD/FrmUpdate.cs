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
    public partial class FrmUpdate : Form
    {
        DB_Access dbaa = new DB_Access();

        public FrmUpdate()
        {
            InitializeComponent();
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string RegNo = txtRegNo.Text;
            txtFName.Text = dbaa.ReturnStudentData("RegNo", "Students", RegNo, "Fname");
            txtLName.Text = dbaa.ReturnStudentData("RegNo", "Students", RegNo, "Lname");
            txtPhone.Text = dbaa.ReturnStudentData("RegNo", "Students", RegNo, "Phone");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dbaa.update_students(txtRegNo.Text, txtFName.Text, txtLName.Text, txtPhone.Text);
            MessageBox.Show("Successfully updated");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
