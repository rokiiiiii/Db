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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form33 : Form
    {
        public Form33()
        {
            InitializeComponent();
        }
        private void Form33_Load(object sender, EventArgs e)
        {
            
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT goodsName,size,count,discount,saleDate,dostyp FROM sales", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "goodsName";
            comboBox1.SelectedIndex = -1;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            DataTable table1 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM goods", db.getConnection());
            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
            comboBox2.DataSource = table1;
            comboBox2.DisplayMember = "dostyp";
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;


            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isUserExist())
                return;
            if (comboBox2.SelectedIndex != -1)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `sales` (`goodsName`,`size`,`count`,`discount`,`saleDate`,`dostyp`) VALUES (@goodsId,@goodsName,@size,@count,@discount,@saleDate,@dostyp)", db.getConnection());


                command.Parameters.Add("@goodsName", MySqlDbType.VarChar).Value = comboBox1.Text;
                command.Parameters.Add("@size", MySqlDbType.Int32).Value = textBox2.Text;
                command.Parameters.Add("@count", MySqlDbType.Int32).Value = textBox3.Text;
                command.Parameters.Add("@discount", MySqlDbType.Float).Value = textBox4.Text;
                command.Parameters.Add("@saleDate", MySqlDbType.Date).Value = dateTimePicker1.Value;
                command.Parameters.Add("dostyp", MySqlDbType.VarChar).Value = comboBox2.Text;
                db.openConnection();
                if (comboBox1.Text != " " && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && textBox2.Text != " " && textBox3.Text != " " && textBox4.Text != " ")
                {

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Продажа успешна добавлена", "Добавление");
                        this.Hide();
                        Form3 frm3 = new Form3();
                        frm3.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Продажа не добавлено", "Добавление");
                }


                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Обуви нету", "Ошибка");
            }
        }

        public Boolean isUserExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            MySqlCommand command = new MySqlCommand("SELECT * FROM `sales` WHERE `goodsName` = @goodsName ", db.getConnection());
            command.Parameters.Add("@goodsName", MySqlDbType.VarChar).Value = comboBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такая продажа уже есть", "Ошибка");
                return true;
            }
            else
                return false;

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
                MySqlCommand command = new MySqlCommand("Delete from `sales` where goodsName=@goodsName", db.getConnection());

               
                command.Parameters.Add("@goodsName", MySqlDbType.VarChar).Value = comboBox1.Text;
                db.openConnection();
                if (comboBox1.Text != " " && comboBox1.SelectedIndex != -1 && textBox2.Text != " " && textBox3.Text != " " && textBox4.Text != " ")
                {

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Продажа успешно удалена", "Удаление");
                        this.Hide();
                        Form3 frm3 = new Form3();
                        frm3.Show();
                    }
                    else
                    {
                        MessageBox.Show("Продажа не удалена", "Удаление");
                    }
                }
                

                db.closeConnection();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number!=8)
            {
                e.Handled = true;
            }
        }

  
        private void label3_Click(object sender, EventArgs e)
        {
            Form11 frm11 = new Form11();
            this.Hide();
            frm11.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form22 frm22 = new Form22();
            this.Hide();
            frm22.Show();
        }

        private void Form33_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }



        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
            int column = Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex.ToString());

            comboBox1.Text = dataGridView1[1, row].Value.ToString();
            //comboBox2.Text = dataGridView1[1, row].Value.ToString();
            textBox2.Text = dataGridView1[2, row].Value.ToString();
            textBox3.Text = dataGridView1[3, row].Value.ToString();
            textBox4.Text = dataGridView1[4, row].Value.ToString();
            dateTimePicker1.Text = dataGridView1[5, row].Value.ToString();
            comboBox2.Text = dataGridView1[6, row].Value.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
