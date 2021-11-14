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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =D:/resumestd.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Dispose();
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtyut.Text == "" && txttu.Text == "" && txttuuuu.Text == "")
            {
                MessageBox.Show("username and password fields are emple", "Registration faileds", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txttu.Text == txttuuuu.Text)
            {
                con.Open();
                string register = "insert into tb_uspa(username,password)values('" + txtyut.Text + "','" + txttu.Text + "')";
                cmd = new OleDbCommand(register, con);

                con.Close();

                txtyut.Text = "";
                txttu.Text = "";
                txttuuuu.Text = "";
                MessageBox.Show("สร้างบัญชีสมาชิกสำเร็จแล้ว", "ลงทะเบียนสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "โปรดป้อนรหัสอีกครั้ง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttu.Text = "";
                txttuuuu.Text = "";
                txttu.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txttu.PasswordChar = '\0';
                txttuuuu.PasswordChar = '\0';
            }
            else
            {
                txttu.PasswordChar = '•';
                txttuuuu.PasswordChar = '•';
            }
        }
    }
}
