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
using pro_new117_135.classes;

namespace pro_new117_135
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

        private void btnLogin_Click(object sender, EventArgs e)
        {

            conn_db.openConn();
            conn_db.cmd.CommandText = "Select * from agent_in where user_agt ='" + txtUsername.Text + "' and pass_agt ='" + txtpassword.Text + "'";


            OleDbDataReader reader = conn_db.cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show("Username และ password ถูกต้อง");
                }
                this.Hide();
                menus f2 = new menus();

                f2.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("ผิดพลาด", "Invalid Username or Password",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtpassword.Text = "";
                txtUsername.Focus();
            }
           
            conn_db.closeConn();
            conn_db.conn.Dispose();
            reader.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            conn_db.conn.Dispose();
            this.Hide();
            Register f2 = new Register();
            f2.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.PasswordChar = '\0';

            }
            else
            {
                txtpassword.PasswordChar = '•';
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtpassword.Text = "";
            txtUsername.Focus();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
