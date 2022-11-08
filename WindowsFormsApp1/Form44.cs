using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WindowsFormsApp1
{
    public partial class Form44 : Form
    {
        public Form44()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select goods.price,(goods.price-sales.discount) from goods inner join sales on goods.categoryName=sales.categoryName", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Form44_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"select goodsName,producer,material,color,price from goods where price<@price", db.getConnection());
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = textBox1.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            textBox1.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"select goods.goodsName,goods.producer,goods.material,goods.color,goods.price, max(quantityInStock) from goods;", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select goods.goodsName,goods.price,sales.saleDate from goods inner join sales on goods.categoryName=sales.categoryName where sales.saleDate=curdate() and goods.price<@price;", db.getConnection());
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = textBox1.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select shoeСategories.*, goods.price from shoeСategories inner join goods on shoeСategories.categoryName=goods.categoryName group by shoeСategories.categoryName having avg(goods.price)>@price", db.getConnection());
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = textBox1.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select sum(goods.price) from goods inner join sales on goods.goodsName=sales.goodsName where month(saleDate)=month(curdate())", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select sum(goods.price),sales.saleDate from goods inner join sales on goods.goodsName=sales.goodsName group by sales.saleDate", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }



        private void button8_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select sales.saleId,count(sales.saleId),goods.categoryName from goods inner join sales on goods.goodsName=sales.goodsName group by sales.goodsName", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select goodsName from goods where goodsName not in (select goodsName from sales)", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select shoeСategories.categoryName,sales.goodsName,avg(sales.discount) from shoeСategories inner join sales on shoeСategories.categoryName=sales.categoryName group by shoeСategories.categoryName", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select * from sales where saleDate=curdate()", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
            int i, j;
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    wsh.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }
            exApp.Visible = true;
            dataGridView1.DataSource = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select count(goodsName) from sales group by saleDate;", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            int y;
            string t;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)//построение сплайна
            {
                int x = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);//отображение сплайна на графике
                chart1.Series[0].Points.AddXY(i, x);
            }
            chart1.ChartAreas[0].AxisX.Title = "Обувь";
            chart1.Name = "Обувь";
            dataGridView1.DataSource = "";
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {


            int row = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
            int sum = Convert.ToInt32(dataGridView1[7, row].Value.ToString());
            string name = Convert.ToString(dataGridView1[1, row].Value.ToString());
            var date = Convert.ToDateTime(dataGridView1[6, row].Value.ToString());

            richTextBox1.Text = $"Вы купили {name}\nНа сумму {sum}\nДата-{date}";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select sales.*, goods.price from sales inner join goods on sales.goodsName=goods.goodsName", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void replace(string stub, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stub, ReplaceWith: text);
 
        }
    private void button13_Click(object sender, EventArgs e)
    {
        int row = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
        int sum = Convert.ToInt32(dataGridView1[7, row].Value.ToString());
        string name = Convert.ToString(dataGridView1[1, row].Value.ToString());
        var date = Convert.ToDateTime(dataGridView1[6, row].Value.ToString());
        var wordApp = new Word.Application();
        wordApp.Visible = false;
        var wordDocument = wordApp.Documents.Open("C:\\Users\\Professional\\Desktop\\DB\\Db\\WindowsFormsApp1\\bin\\Debug\\Шаблон.docx");
        replace("{name}", name, wordDocument);
        replace("{sum}", sum.ToString(), wordDocument);
        replace("{date}", date.ToString(), wordDocument);
        wordDocument.SaveAs(@"Вывод.docx");
        wordApp.Visible = true;
    }
}
}
