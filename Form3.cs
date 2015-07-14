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
        Form1 _fr = new Form1();

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

                isConnect = true;
                MessageBox.Show("Соединение утсановлено.");
                mySql.Close();
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool returnIsConnect()// эта функция для делегата
        {
            return isConnect;
        }

        private MySqlConnection returnConnection()
        {
            return mySql;
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

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = this.Owner as Form1;
            form1._boolDelegate += returnIsConnect;
            form1._mySqlDelegate += returnConnection;
        }
    }
}
