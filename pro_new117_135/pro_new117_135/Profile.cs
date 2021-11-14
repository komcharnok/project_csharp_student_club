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
    public partial class Profile : Form
    {
       
        public Profile()
        {
            InitializeComponent();
        }

        /*
         *  Test Comment
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */

        private void Profile_Load(object sender, EventArgs e)
        {
            try
            {
                conn_db.closeConn();
                conn_db.openConn(); 
                

                conn_db.cmd.Connection = conn_db.conn;

                string query = "select * from std_db ";


                conn_db.cmd.CommandText = query;
               
                OleDbDataReader reader = conn_db.cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    cbxserchpf.Items.Add(reader["name_sur_std"].ToString());
                }

                conn_db.closeConn();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void cbxserchpf_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                string selectName = "";
                if (conn_db.conn.State == ConnectionState.Open)
                {
                    conn_db.closeConn();
                }
                else
                {
                    conn_db.openConn();

                }

                conn_db.cmd.Connection = conn_db.conn;
             

                selectName = cbxserchpf.SelectedItem.ToString();
                
                query = "select * from std_db where name_sur_std like '" + selectName + "'";

                conn_db.cmd.CommandText = query;
                OleDbDataReader reader = conn_db.cmd.ExecuteReader();

                while (reader.Read())
                {
                    txtid.Text = reader["id_std"].ToString();
                    txtname.Text = reader["name_sur_std"].ToString();

                    txtold.Text = reader["old_std"].ToString();
                    txtiddep.Text = reader["debbid_std"].ToString();
                    txtidsubject.Text = reader["subject_std"].ToString();


                    txtcall.Text = reader["call_std"].ToString();
                    txtemail.Text = reader["email_std"].ToString();
                    txtcha.Text = reader["chal_std"].ToString();
                    txtidclub.Text = reader["club_std"].ToString();

                }

                //connection.Close();  // old
                conn_db.closeConn();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btnbackk_Click(object sender, EventArgs e)
        {
            //connection.Dispose();
            conn_db.conn.Dispose();
            this.Hide();
            menus f1 = new menus();
            f1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtid.Text, new Font("tahoma", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
            e.Graphics.DrawString(txtname.Text, new Font("tahoma", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 135));
            
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
