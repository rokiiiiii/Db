using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM goods", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            DataTable table1 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM shoeСategories", db.getConnection());
            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "categoryName";
            comboBox1.SelectedIndex = -1;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            db.closeConnection();
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

        private void Form22_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                             "Вы уверены что вы хотите удалить",
                             "Вопрос",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                DB db = new DB();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand($"Delete from `goods` WHERE `goodsName` = @uL", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1.Text;
                db.openConnection();
               
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Вы успешно удалили запись", "Выполнено");
                    this.Hide();
                    Form22 frm2 = new Form22();
                    frm2.Show();
                }
                else
                    MessageBox.Show("Пожалуйтса попробуйте еще раз", "Ошибка");
            }
        }
        int index;
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            index = comboBox1.FindString(comboBox1.Text);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (isUserExist())
            //    return;
        
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `goods` ( `goodsName`,`categoryName`,`producer`,`material`,`color`,`price`,`quantityInStock`,`dostyp`) VALUES (@goodsName,@categoryName,@producer,@material,@color,@price,@quantityInStock,@dostyp)", db.getConnection());

            command.Parameters.Add("@goodsName", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@categoryName", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@producer", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@material", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@color", MySqlDbType.VarChar).Value = textBox6.Text;
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = textBox5.Text;
            command.Parameters.Add("@quantityInStock", MySqlDbType.Int32).Value = textBox7.Text;
            command.Parameters.Add("@dostyp", MySqlDbType.VarChar).Value = comboBox3.Text;

            db.openConnection();
            if (textBox1.Text != " " && comboBox1.Text != " " && comboBox1.SelectedIndex != -1 && textBox3.Text != " " && textBox4.Text != " " && textBox5.Text != " " && textBox6.Text != " " && textBox7.Text != " " && comboBox3.Text != " ")
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Обувь успешна добавлена", "Добавление");
                    this.Hide();
                    Form22 frm2 = new Form22();
                    frm2.Show();
                }
                else
                {
                    MessageBox.Show("Обувь не добавлена", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Обувь не добавлена", "Ошибка");
            }

            db.closeConnection();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Form11 frm1 = new Form11();
            this.Hide();
            frm1.Show();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {

                DialogResult result = MessageBox.Show(
                                 "Такой категории нет. Хотите добавить?",
                                 "Вопрос",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    Form1 frm1 = new Form1();
                    frm1.Show();
                    this.Hide();
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());

            textBox1.Text = dataGridView1[0, row].Value.ToString();
            comboBox1.Text = dataGridView1[1, row].Value.ToString();
            textBox4.Text = dataGridView1[2, row].Value.ToString();
            textBox6.Text= dataGridView1[3, row].Value.ToString();
            textBox5.Text = dataGridView1[4, row].Value.ToString();
            textBox3.Text = dataGridView1[5, row].Value.ToString();
            textBox7.Text = dataGridView1[6, row].Value.ToString();
            comboBox3.Text = dataGridView1[7, row].Value.ToString();

        }
    }
}
