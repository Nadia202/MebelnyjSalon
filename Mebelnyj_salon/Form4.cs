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
    public partial class Form4 : Form
    {
        byte[] image;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();
            connection.Open();
            SqlDataAdapter tip = new SqlDataAdapter("Select id,nazvanie From TipMebeli", connection);
            DataTable dtTip = new DataTable();
            tip.Fill(dtTip);
            comboBox1.DataSource = dtTip;
            comboBox1.DisplayMember = "nazvanie";
            comboBox1.ValueMember = "id";
            SqlDataAdapter cvet = new SqlDataAdapter("Select id,nazvanie From Cvet", connection);
            DataTable dtCvet = new DataTable();
            cvet.Fill(dtCvet);
            comboBox2.DataSource = dtCvet;
            comboBox2.DisplayMember = "nazvanie";
            comboBox2.ValueMember = "id";
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png|*.jpg, *.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string nameFile = openFile.FileName;
                image = File.ReadAllBytes(nameFile);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string naz = textBox1.Text;
            int t = comboBox1.SelectedIndex;
            int c = comboBox2.SelectedIndex;
            int r = Convert.ToInt32(textBox2.Text);
            int cen = Convert.ToInt32(textBox3.Text);
            string date = dateTimePicker1.Value.ToString();
            int k = (int)numericUpDown1.Value;
            int check = 0;
            if (checkBox1.Checked)
            {
                check = 1;
            }
            Connection connect = new Connection();
            SqlConnection connection = connect.Connect();//{image},
            connection.Open();
            SqlCommand insert = new SqlCommand($"Insert into Mebel (nazvanie,tip,cvet,razmer,cena,nalichie,dataIzgotovleniya,kolichestvo,fotografiya) Values ('{naz}',{t},{c},{r},{cen},{check},'{date}',{k}, @image)",connection);
            SqlParameter sqlParameter = new SqlParameter("@image", SqlDbType.VarBinary);
            sqlParameter.Value = image;
            insert.Parameters.Add(sqlParameter);
            int a = insert.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3 form3 = (Form3)Application.OpenForms[1];
            form3.мебельToolStripMenuItem_Click(this, e);
        }
    }
}
