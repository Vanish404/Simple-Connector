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
        
        public Form1()
        {
            InitializeComponent();
            _connectToMySQL = new ConnectToMySQL();
              
        }
        
       

        private void button1_Click(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = _connectToMySQL.GetComments(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            
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
    }
}
