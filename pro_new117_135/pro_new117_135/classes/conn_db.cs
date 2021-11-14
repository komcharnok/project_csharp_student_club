using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace pro_new117_135.classes
{
    class conn_db
    {
              
        public static OleDbConnection conn = new OleDbConnection();
        public static OleDbCommand cmd = new OleDbCommand("", conn);
        public static OleDbDataAdapter da;
        public static DataSet ds = new DataSet();

        public static bool IsFind = false;


        public static void openConn()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                 "Data Source= " + "../../../project.accdb;Persist Security Info=False;";
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro msg"+ ex.Message.ToString(), "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void closeConn()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Erro msg" + ex.Message.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
