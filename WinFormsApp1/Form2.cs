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

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input1 = textBox1.Text;
            string input2 = textBox2.Text;
            string input3 = textBox3.Text;

            InsertUser(input1, input2, input3);
            MessageBox.Show(" user added, signup successful");
            this.Hide();
        }
        string connectionString = "Data Source=192.168.0.132\\TEW_SQLEXPRESS;Initial Catalog=test_db;Integrated Security=True";
        private void InsertUser(string username, string password, string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Email", email);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }


    }
}
