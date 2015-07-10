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
        public DataTable GetComments(string server, string database, string username, string password)
        {
            DataTable dt = new DataTable();

            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder(); 
            mysqlCSB.Server = server;
            mysqlCSB.Database = database;
            mysqlCSB.UserID = username;
            mysqlCSB.Password = password;

            string queryString = @"SELECT comment_author, 
                                 comment_date,     
                                 comment_content               
                          FROM   fgel_comments
                          WHERE  comment_date";
            
            MySqlConnection con = new MySqlConnection(mysqlCSB.ConnectionString); 
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand com = new MySqlCommand(queryString, con);

            try
            {
                con.Open();

                using (MySqlDataReader dr = com.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
                con.Close();
            
            return dt;
        }
    }
}
