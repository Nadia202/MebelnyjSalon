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
    public partial class Form1 : Form
    {
        public string userId;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Введите логин и пароль.");
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Логин не введён!");
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Пароль не введён!");
                    }
                    else
                    {
                        Connection connect = new Connection();
                        SqlConnection connection = connect.Connect();
                        connection.Open();
                        SqlCommand login = new SqlCommand($"SELECT COUNT(login) From Avtorizaciya WHERE login = {textBox1.Text}", connection);
                        int log = (int)login.ExecuteScalar();
                        SqlCommand parol = new SqlCommand($"SELECT COUNT(parol) FROM Avtorizaciya WHERE login = {textBox1.Text} AND parol = '{textBox2.Text}'", connection);
                        int par = (int)parol.ExecuteScalar();
                        if (log == 1)
                        {
                            if (par == 1)
                            {
                                SqlCommand id = new SqlCommand($"SELECT polzovatel From Avtorizaciya WHERE login = {textBox1.Text}", connection);
                                int idLog = (int)id.ExecuteScalar();
                                userId = idLog.ToString();
                                connection.Close();
                                if (idLog > 1000)
                                {
                                    Form2 form2 = new Form2();
                                    form2.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    Form3 form3 = new Form3();
                                    form3.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пароль неверный!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользоваеля с данным логином не существует!");
                        }
                    }
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
