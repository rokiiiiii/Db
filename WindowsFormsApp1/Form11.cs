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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "Choose Image(*.jpg; *.png; *.jpeg; *.bin)|*.jpg; *.png; *.jpeg; *.bin";
            if (opn.ShowDialog() == DialogResult.OK)
            {
                imLoc.Text = opn.SafeFileName;
                imageText.Text = opn.FileName;
                pictureBox2.Image = new Bitmap(opn.FileName);
                pictureBox2.ImageLocation = opn.FileName;

            }
        }

        private void Form11_Load(object sender, EventArgs e)
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
                MessageBox.Show("Произошла ошибка", "Ошибка");
            }
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isUserExist())
                return;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `shoeСategories` (`categoryName`,`guaranteePeriod`,`careRules`,`imgPath`,`imgName`,`dostyp`) VALUES (@categoryName,@guaranteePeriod,@careRules,@imgPath,@imgName,@dostyp)", db.getConnection());

            command.Parameters.Add("@categoryName", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@guaranteePeriod", MySqlDbType.Int32).Value = textBox2.Text;
            command.Parameters.Add("@careRules", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@imgPath", MySqlDbType.VarChar).Value = imLoc.Text;
            command.Parameters.Add("@imgName", MySqlDbType.VarChar).Value = imageText.Text;
            command.Parameters.Add("@dostyp", MySqlDbType.VarChar).Value = comboBox1.Text;

            db.openConnection();
            if (textBox1.Text != " " && textBox2.Text != " " && textBox3.Text != " " && pictureBox2.Image != null)
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Категория успешна добавлена", "Добавление");
                    this.Hide();
                    Form1 frm1 = new Form1();
                    frm1.Show();
                }
            }
            else
            {
                MessageBox.Show("Категория не добавлена", "Добавление");
            }

            db.closeConnection();
        }

        public Boolean isUserExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            MySqlCommand command = new MySqlCommand("SELECT * FROM `shoeСategories` WHERE `categoryName` = @categoryName ", db.getConnection());
            command.Parameters.Add("@categoryName", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такая категория уже есть", "Ошибка");
                return true;
            }
            else
                return false;

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
            pictureBox1.Image = Image.FromFile(dataGridView1[4, row].Value.ToString());

            textBox1.Text = dataGridView1[1, row].Value.ToString();
            textBox2.Text = dataGridView1[2, row].Value.ToString();
            textBox3.Text = dataGridView1[3, row].Value.ToString();


        }
        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void Form11_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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
                MySqlCommand command = new MySqlCommand($"UPDATE `shoeСategories` SET `dostyp`= 'Нету' WHERE `categoryName` = @uL", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1.Text;

                db.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Удалили запись", "Выполнено");
                    this.Hide();
                    Form11 frm1 = new Form11();
                    frm1.Show();
                }
                else
                    MessageBox.Show("Пожалуйтса попробуйте еще раз", "Ошибка");
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form22 frm22 = new Form22();
            this.Hide();
            frm22.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form33 frm33 = new Form33();
            this.Hide();
            frm33.Show();
        }
    }
}
