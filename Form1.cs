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
        public event BoolDelegate _boolDelegate; //инцилизация
        public event MySqlDelegate _mySqlDelegate;
        
        private bool isConnect;
        private ConnectToMySQL _connectToMySQL;
        private MySqlConnection _mySqlConnection;
		
        public Form1()
        {
            InitializeComponent();
            _connectToMySQL = new ConnectToMySQL();
            dataGridView1.ReadOnly = true;
            toolStripMenuItem2.Enabled = false;

        }
        
       

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (_boolDelegate != null && _mySqlDelegate != null) //вызов делегата
            {
                isConnect = _boolDelegate();
                _mySqlConnection = _mySqlDelegate();
            }

            if (isConnect == true)
            {
                toolStripMenuItem2.Enabled = true;
                string queryString = @"SELECT name, surname, age, date_birthday               
                                 FROM   base";
                dataGridView1.DataSource = _connectToMySQL.GetData(_mySqlConnection, queryString);
            }

            else
                MessageBox.Show("Нет подключения." + isConnect);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            _form2.ShowDialog();         
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            isConnect = false;
            toolStripMenuItem2.Enabled = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 _form3 = new Form3();
            _form3.Owner = this;
            _form3.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
