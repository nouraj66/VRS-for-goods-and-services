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

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Isvalid())
            {
                button1.ForeColor = Color.White;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\Project\Project\logindb.mdf;Integrated Security=True");

                try
                {
                    con.Open();
                    //String Username = txtUsername.Text;
                    //String Password = txtPassword.Text;
                    //SqlCommand cnn = new SqlCommand("select Username,Password from login_tbl where Username='" + txtUsername.Text + "'and Password=," + txtPassword.Text + "'", con);
                    String query = "Select * from loginTable where Username='" + maskedTextBox2.Text + "'and Password='" + maskedTextBox1.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);//cnn
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Main f1 = new Main();
                            f1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured:" + ex.Message);
                }
            }
        }


        private bool Isvalid()
        {
            if (maskedTextBox2.Text.TrimStart() == String.Empty)
            {
                MessageBox.Show("enter valid user name please!", "Error");
                return false;
            }
            else if (maskedTextBox1.Text.TrimStart() == String.Empty)
            {
                MessageBox.Show("enter valid password please!", "Error");
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            contact ct = new contact();
            ct.Show();
        }
    }
    
}
