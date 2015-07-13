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
    public partial class Form2 : Form
    {
        private MySqlConnection _con;
        public Form2(MySqlConnection con)
        {
            InitializeComponent();
            _con = con;
            button1.Enabled = false;
            textBox3.Enabled = false;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Age_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO base (name, surname, age, date_birthday)" +
                             "VALUES (@Name, @LastName, @Age, @Date);";

                _con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, _con);

                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Age", textBox3.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month+ "-" + dateTimePicker1.Value.Day);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Все сохранено.");
                _con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так. " + ex.Message);
            }
        }

        private void CheckInputTextBox()
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                button1.Enabled = false;
            }

            else
            {
                button1.Enabled = true;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }
        }

        private void textBox_KeyPress_Digit(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CheckInputTextBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckInputTextBox();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CheckInputTextBox();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти без сохранения?", "Выйти?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if ((DateTime.Now.Month >= dateTimePicker1.Value.Month) && (DateTime.Now.Day >= dateTimePicker1.Value.Day))
                textBox3.Text = Convert.ToString(DateTime.Now.Year - dateTimePicker1.Value.Year);
            else
                textBox3.Text = Convert.ToString(DateTime.Now.Year - dateTimePicker1.Value.Year - 1);
        }
    }
}
