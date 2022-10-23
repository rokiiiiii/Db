using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM shoeСategories", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            if (table.Rows.Count > 0)
            {
                pictureBox1.Load(table.Rows[0][4].ToString());
            }
            else
            {
                MessageBox.Show("Произошла ошибку", "Ошибка");
            }
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form11 frm11 = new Form11();
            this.Hide();
            frm11.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }



        private void label8_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
            pictureBox1.Image = Image.FromFile(dataGridView1[4, row].Value.ToString());

        }
        //public Boolean isUserExist()
        //{
        //    DB db = new DB();

        //    DataTable table = new DataTable();
        //    MySqlDataAdapter adapter = new MySqlDataAdapter();


        //    MySqlCommand command = new MySqlCommand("SELECT * FROM `shoeСategories` WHERE `categoryName` = @categoryName ", db.getConnection());
        //    command.Parameters.Add("@categoryName", MySqlDbType.VarChar).Value = textBox1.Text;

        //    adapter.SelectCommand = command;
        //    adapter.Fill(table);


        //    if (table.Rows.Count > 0)
        //    {
        //        MessageBox.Show("Такая обувь уже есть", "Ошибка");
        //        return true;
        //    }
        //    else
        //        return false;

        //}



        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number)&& number!=8)
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
