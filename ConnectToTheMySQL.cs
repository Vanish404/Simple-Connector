using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MySQL
{
    class ConnectToMySQL
    {
        private MySqlConnection _connection;
        public ConnectToMySQL(MySqlConnection connection)
        {
            _connection = connection;
            
        }
        public MySqlConnection AddMySQLQuer(string server, string database, string username, string password)
        {
            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder(); 
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = username;
            mysqlCSB.Password = password;
            
            MySqlConnection con = new MySqlConnection(mysqlCSB.ConnectionString);

            return con;
        }

        public DataTable GetComments(MySqlConnection con, string queryString)
        {
            DataTable dt = new DataTable();
 
            MySqlCommand com = new MySqlCommand(queryString, con);

            try
            {
                con.Open();

                MySqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    dt.Load(dr);
                }

                MessageBox.Show("Успех");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так. " + ex.Message);

            }
                con.Close();
            
            return dt;
        }
    }
}
