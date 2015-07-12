using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

namespace MySQL
{

    
    public partial class Form1 : Form
    {
        private ConnectToMySQL _connectToMySQL;
        private MySqlConnection _mySqlConnection;
        
        public Form1()
        {
            InitializeComponent();

            _connectToMySQL = new ConnectToMySQL();
              
        }
        
       

        private void button1_Click(object sender, System.EventArgs e)
        {
            _mySqlConnection = _connectToMySQL.AddMySQLQuer(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            string queryString = @"SELECT name, surname, age, date_birthday               
                                 FROM   base";
            dataGridView1.DataSource = _connectToMySQL.GetComments(_mySqlConnection, queryString);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void baseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 _form2 = new Form2(_mySqlConnection);
            _form2.Owner = this;
            _form2.ShowDialog();


        }

    }
}
