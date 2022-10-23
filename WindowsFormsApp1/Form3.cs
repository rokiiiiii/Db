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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM sales", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form33 frm33 = new Form33();
            this.Hide();
            frm33.Show();
        }
        //public Boolean isUserExist()
        //{
        //    DB db = new DB();

        //    DataTable table = new DataTable();
        //    MySqlDataAdapter adapter = new MySqlDataAdapter();


        //    MySqlCommand command = new MySqlCommand("SELECT * FROM `sales` WHERE `goodsId` = @goodsId ", db.getConnection());
        //    command.Parameters.Add("@goodsId", MySqlDbType.VarChar).Value = textBox1.Text;

        //    adapter.SelectCommand = command;
        //    adapter.Fill(table);


        //    if (table.Rows.Count > 0)
        //    {
        //        MessageBox.Show("Такое лекарство уже есть", "Ошибка");
        //        return true;
        //    }
        //    else
        //        return false;

        //}

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
               
               
            
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
