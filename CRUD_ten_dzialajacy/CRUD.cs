using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace CRUD_ten_dzialajacy
{
    public class CRUD
    {
        private static string getConnectionString()
        {
            string host = "server=127.0.0.1;";
            string port = "port=3306;";
            string db = "database=lastrada;";
            string user = "user=root;";
            string pass = "password=";


            string conString = string.Format("{0}{1}{2}{3}{4}", host, port, db, user, pass);

            return conString;
        }

        public static MySqlConnection con = new MySqlConnection(getConnectionString());
        public static MySqlCommand cmd = default(MySqlCommand);
        public static string sql = string.Empty;


        
        public static DataTable PerformCRUD(MySqlCommand com)
        {
            MySqlDataAdapter da = default(MySqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {


                da = new MySqlDataAdapter();
                da.SelectCommand = com;
                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "PerformCRUD CRUD Operations Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;
            }

            return dt;
        }


    }
}

