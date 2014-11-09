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
    public partial class frmDelete : Form
    {
        DB_Access dba = new DB_Access();

        public frmDelete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmDelete_Load(object sender, EventArgs e)
        {
            FillStudentNameList();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FillStudentNameList()
        {
            DataTable tb1 = dba.FillStudentsList();
            cmbStudentName.ValueMember = "Fname";
            cmbStudentName.DisplayMember = "studentname";
            cmbStudentName.DataSource = tb1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete selected student?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (dba.DeleteUsers(cmbStudentName.Text))
                {
                    MessageBox.Show("Studnet Successfully Deleted!");
                    FillStudentNameList();
                }
                else
                {
                    MessageBox.Show("Error Deleting the Student. Please try again!");
                }
            }
        }
    }
}
