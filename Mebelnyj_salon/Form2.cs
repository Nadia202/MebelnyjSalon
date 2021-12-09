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
using System.IO;

namespace Mebelnyj_salon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();
            connection.Open();
            SqlDataReader dataReader = null;
            SqlCommand gostinnaya = new SqlCommand("Select nazvanie, cena, fotografiya from Mebel where nalichie = 1 and tip = 0", connection);
            dataReader = gostinnaya.ExecuteReader();
            ListViewItem item = null;
            ImageList imageL = new ImageList();
            Image img;
            int i = 0;
            listView1.LargeImageList = imageL;
            imageL.ImageSize = new Size(128, 128);
            while (dataReader.Read())
            {
                item = new ListViewItem();
                byte[] im = (byte[])dataReader.GetSqlBinary(2);
                MemoryStream ms = new MemoryStream(im, 0, im.Length);
                img = (Image)Image.FromStream(ms);
                imageL.Images.Add(img);
                item.Text = Convert.ToString(dataReader["nazvanie"]) + "  " + Convert.ToString(dataReader["cena"]);
                item.ImageIndex = i;
                listView1.Items.Add(item);
                i++;
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();
            connection.Open();
            SqlDataReader dataReader = null;
            SqlCommand spalnya = new SqlCommand("Select nazvanie, cena, fotografiya from Mebel where nalichie = 1 and tip = 1", connection);
            dataReader = spalnya.ExecuteReader();
            ListViewItem item = null;
            ImageList imageL = new ImageList();
            Image img;
            int i = 0;
            listView1.LargeImageList = imageL;
            imageL.ImageSize = new Size(128, 128);
            while (dataReader.Read())
            {
                item = new ListViewItem();
                byte[] im = (byte[])dataReader.GetSqlBinary(2);
                MemoryStream ms = new MemoryStream(im, 0, im.Length);
                img = (Image)Image.FromStream(ms);
                imageL.Images.Add(img);
                item.Text = Convert.ToString(dataReader["nazvanie"]) + "  " + Convert.ToString(dataReader["cena"]);
                item.ImageIndex = i;
                listView1.Items.Add(item);
                i++;
            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();
            connection.Open();
            SqlDataReader dataReader = null;
            SqlCommand kuhnya = new SqlCommand("Select nazvanie, cena, fotografiya from Mebel where nalichie = 1 and tip = 2", connection);
            dataReader = kuhnya.ExecuteReader();
            ListViewItem item = null;
            ImageList imageL = new ImageList();
            imageL.ImageSize = new Size(128, 128);
            Image img;
            int i = 0;
            listView1.LargeImageList = imageL;
            while (dataReader.Read())
            {
                item = new ListViewItem();
                byte[] im = (byte[])dataReader.GetSqlBinary(2);
                MemoryStream ms = new MemoryStream(im, 0, im.Length);
                img = (Image)Image.FromStream(ms);
                imageL.Images.Add(img);
                item.Text = Convert.ToString(dataReader["nazvanie"]) + "  " + Convert.ToString(dataReader["cena"]);
                item.ImageIndex = i;
                listView1.Items.Add(item);
                i++;
            }
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();
            connection.Open();
            SqlDataReader dataReader = null;
            SqlCommand detskaya = new SqlCommand("Select nazvanie, cena, fotografiya from Mebel where nalichie = 1 and tip = 3", connection);
            dataReader = detskaya.ExecuteReader();
            ListViewItem item = null;
            ImageList imageL = new ImageList();
            imageL.ImageSize = new Size(128, 128);
            Image img;
            int i = 0;
            listView1.LargeImageList = imageL;
            while (dataReader.Read())
            {
                item = new ListViewItem();
                byte[] im = (byte[])dataReader.GetSqlBinary(2);
                MemoryStream ms = new MemoryStream(im, 0, im.Length);
                img = (Image)Image.FromStream(ms);
                imageL.Images.Add(img);
                item.Text = Convert.ToString(dataReader["nazvanie"]) + "  " + Convert.ToString(dataReader["cena"]);
                item.ImageIndex = i;
                listView1.Items.Add(item);
                i++;
            }
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();
            connection.Open();
            SqlDataReader dataReader = null;
            SqlCommand prihozhaya = new SqlCommand("Select nazvanie, cena, fotografiya from Mebel where nalichie = 1 and tip = 4", connection);
            dataReader = prihozhaya.ExecuteReader();
            ListViewItem item = null;
            ImageList imageL = new ImageList();
            imageL.ImageSize = new Size(128, 128);
            Image img;
            int i = 0;
            listView1.LargeImageList = imageL;
            while (dataReader.Read())
            {
                item = new ListViewItem();
                byte[] im = (byte[])dataReader.GetSqlBinary(2);
                MemoryStream ms = new MemoryStream(im, 0, im.Length);
                img = (Image)Image.FromStream(ms);
                imageL.Images.Add(img);
                item.Text = Convert.ToString(dataReader["nazvanie"]) + "  " + Convert.ToString(dataReader["cena"]);
                item.ImageIndex = i;
                listView1.Items.Add(item);
                i++;
            }
            connection.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms[0];
            form1.textBox1.Text = "";
            form1.textBox2.Text = "";
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1_Click(this,e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
