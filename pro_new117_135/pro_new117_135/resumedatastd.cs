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
    public partial class resumedatastd : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public resumedatastd()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/project.accdb;Persist Security Info=False;";
        }

        private void resumedatastd_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from std_db ";

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    cbxclub.Items.Add(reader["club_std"].ToString());
                    cbxserchname.Items.Add(reader["name_sur_std"].ToString());
                    cbxiddep.Items.Add(reader["debbid_std"].ToString());
                    cbxidsubject.Items.Add(reader["subject_std"].ToString());

                }







                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into std_db(id_std,name_sur_std,old_std,subject_std,call_std,email_std,chal_std,club_std,debb_std)value('"+txtid.Text+"'," +
                    "'"+txtname.Text+ "','"+txtold.Text+ "','"+cbxidsubject.Text+ "','"+txtcall.Text+ "','"+txtemail.Text+ "','"+txtcha.Text+ "','"+cbxclub.Text+ "','"+cbxiddep.Text+"')";

                command.ExecuteNonQuery();
                MessageBox.Show("เซฟข้อมูล");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "update std_db set name_sur_std ='" + txtname.Text + "',oldstd ='" + txtold.Text + "',debb_std ='" + cbxiddep.Text + "'," +
                    "subject_std ='" + cbxidsubject.Text + "',call_std ='" + txtcall.Text + "',email_std ='" + txtemail.Text + "',chal_std ='" + txtcha.Text + "',club_std ='" + cbxclub.Text + "' where id_std  = '" + txtid.Text + "'";
                MessageBox.Show(query);
                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("แก้ไขข้อมูล");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "delete from std_db where idstd = '" + txtid.Text + "' ";
                MessageBox.Show(query);
                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("ลบข้อมูลเสร็จสิ้น");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            cbxiddep.Text = "";
            txtold.Text = "";
            cbxiddep.Text = "";
            txtdebbb.Text = "";
            cbxclub.Text = "";
            txtcall.Text = "";
            txtclubbb.Text = "";
            txtcha.Text = "";
            cbxidsubject.Text = "";
            txtemail.Text = "";
        }

        private void btnbacklogin_Click(object sender, EventArgs e)
        {
            connection.Dispose();
            this.Hide();
            menus f1 = new menus();
            f1.ShowDialog();
        }

        private void cbxserchname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from std_db ";

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtid.Text = reader["id_std"].ToString();
                    txtname.Text = reader["name_sur_std"].ToString();
                    
                    txtold.Text = reader["old_std"].ToString();
                    cbxiddep.Text = reader["debb_std"].ToString();
                    cbxidsubject.Text = reader["subject_std"].ToString();
                    



                    txtcall.Text = reader["call_std"].ToString();
                    txtemail.Text = reader["email_std"].ToString();
                    txtcha.Text = reader["chal_std"].ToString();
                    cbxclub.Text = reader["club_std"].ToString();



                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void cbxclub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from club_in where name_club  ";

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    txtclubbb.Text = reader["name_club"].ToString();




                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void cbxdep_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from department_in where name_dep  ";

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    txtdebbb.Text = reader["name_dep"].ToString();
                



                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }
    }
}
