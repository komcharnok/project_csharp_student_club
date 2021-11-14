using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace pro_new117_135
{
    public partial class menus : Form
    {
        public menus()
        {
            InitializeComponent();
        }

        private void menus_Load(object sender, EventArgs e)
        {
        }

        private void btnProflie_Click(object sender, EventArgs e)
        {
        
            this.Hide();
            Profile f1 = new Profile();
            f1.ShowDialog();
        }

        private void btndatastd_Click(object sender, EventArgs e)
        {
      
            this.Hide();
            resumedatastd f3 = new resumedatastd();
            f3.ShowDialog();
        }

        private void btntablestd_Click(object sender, EventArgs e)
        {
            this.Hide();
            tabledata f1 = new tabledata();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void btntableclub_Click(object sender, EventArgs e)
        {
            this.Hide();
            tableclub f1 = new tableclub();
            f1.ShowDialog();
        }

        private void btntabledeb_Click(object sender, EventArgs e)
        {
            this.Hide();
            tabledeb f1 = new tabledeb();
            f1.ShowDialog();
        }
    }
}
