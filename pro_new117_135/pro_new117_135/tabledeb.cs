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
    public partial class tabledeb : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public tabledeb()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/project.accdb;Persist Security Info=False;";
        }

        private void tabledeb_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from department_in ";

                command.CommandText = query;



                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            connection.Dispose();
            this.Hide();
            menus f1 = new menus();
            f1.ShowDialog();
        }
    }
}
