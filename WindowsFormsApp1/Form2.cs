using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM goods", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form22 frm2 = new Form22();
            this.Hide();
            frm2.Show();
            //    if (isUserExist())
            //        return;
            //    DB db = new DB();
            //    MySqlCommand command = new MySqlCommand("INSERT INTO `goods` ( `goodsName`,`categoryId`,`producer`,`material`,`color`,`price`,`quantityInStock`) VALUES (@goodsName,@categoryId,@producer,@material,@color,@price,@quantityInStock)", db.getConnection());

            //    command.Parameters.Add("@goodsName", MySqlDbType.VarChar).Value = textBox1.Text;
            //    command.Parameters.Add("@categoryId", MySqlDbType.Int32).Value = textBox2.Text;
            //    command.Parameters.Add("@producer", MySqlDbType.VarChar).Value = textBox3.Text;
            //    command.Parameters.Add("@material", MySqlDbType.VarChar).Value = textBox4.Text;
            //    command.Parameters.Add("@color", MySqlDbType.VarChar).Value = textBox5.Text;
            //    command.Parameters.Add("@price", MySqlDbType.Float).Value = textBox6.Text;
            //    command.Parameters.Add("@quantityInStock", MySqlDbType.Int32).Value = textBox7.Text;


            //    db.openConnection();
            //    if (textBox1.Text != " " && textBox2.Text != " ")
            //    {
            //        if (command.ExecuteNonQuery() == 1)
            //        {
            //            MessageBox.Show("Обувь успешна добавлена", "Добавление");
            //            this.Hide();
            //            Form2 frm2 = new Form2();
            //            frm2.Show();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Обувь не добавлена", "Добавление");
            //    }

            //    db.closeConnection();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.Show();
        }
        public Boolean isUserExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            MySqlCommand command = new MySqlCommand("SELECT * FROM `goods` WHERE `name` = @name ", db.getConnection());
            //command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такое обувь уже есть", "Ошибка");
                return true;
            }
            else
                return false;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {


            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
