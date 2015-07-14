using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySQL
{
    public partial class Form3 : Form
    {
        private ConnectToMySQL _connectToMySql;
        private MySqlConnection mySql;
        private bool isConnect = false;

        public Form3()
        {
            InitializeComponent();
            _connectToMySql = new ConnectToMySQL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mySql = _connectToMySql.AddMySQLQuer(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                string emptySque = @"SELETC 1"; //можно сказать пустой запрос

                MySqlCommand com = new MySqlCommand(emptySque, mySql);
                mySql.Open();

                MessageBox.Show("Соединение утсановлено.");
                isConnect = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySql.Close();
                Form1 form1 = this.Owner as Form1;

                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
