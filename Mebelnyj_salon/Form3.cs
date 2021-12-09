using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mebelnyj_salon
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void поставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select postavshchik as Поставщик, mebel as Мебель, kolichestvo as Количество, cena as Цена, dataPostavki as Дата_поставки From Zakupki", connection);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void продажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select klient as Клиент, dataPodachiZayavki as Дата_подачи_заявки, sposobDostavki as Способ_доставки, dataDostavki as Дата_доставки, sposobOplaty as Способ_оплаты, kredit as Кредит, uslovyaKreditovaniya as Условие_кредитования, nomerScheta as Номер_счёта, sotrudnik as Сотрудник From Zakaz", connection);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            поставкиToolStripMenuItem_Click(this, e);
        }

        public void мебельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select nazvanie as Название, tip as Тип, cvet as Цвет, razmer as Размер, cena as Цена, nalichie as Наличие, dataIzgotovleniya as Дата_изготовления, kolichestvo as Количество, fotografiya as Фото From Mebel", connection);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms[0];
            form1.textBox1.Text = "";
            form1.textBox2.Text = "";
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
