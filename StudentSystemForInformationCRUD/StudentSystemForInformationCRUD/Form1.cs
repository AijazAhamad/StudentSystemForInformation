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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmNewStudent newstd = new FrmNewStudent();
            newstd.Show();
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            DataView newview = new DataView();
            newview.Show();
        }
    }
}
