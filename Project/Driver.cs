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
    public partial class Driver : Form
    {

        private string name, phone, email, address, vehicleType, loadType;
        private DateTime availableDate;

        private void Driver_Load(object sender, EventArgs e)
        {

        }

        public Driver()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Profile pic = new Profile();
            pic.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Vehicle vv = new Vehicle();
            if (vv.ShowDialog() == DialogResult.OK)
            {
                vehicleType = vv.SelectedVehicleType;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Details dd = new Details();
            if (dd.ShowDialog() == DialogResult.OK)
            {
            //    id = dd.ID;
                name = dd.NAME;
                phone = dd.PHONE;
                email = dd.EMAIL;
                address = dd.ADDRESS;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Load ll = new Load();
            if (ll.ShowDialog() == DialogResult.OK)
            {
                loadType = ll.SelectedLoadType;
            }

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Date dt = new Date();
            if (dt.ShowDialog() == DialogResult.OK)
            {
                availableDate = dt.SelectedDate;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
           
            string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\Project\Project\logindb.mdf;Integrated Security=True");

           
            string query = "INSERT INTO transtbl(Name, Phone, Email, Address, VehicleType, LoadType, AvailableDate) " +
                           "VALUES (@Name, @Phone, @Email, @Address, @VehicleType, @LoadType, @AvailableDate)";

                     using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@VehicleType", vehicleType);
                        cmd.Parameters.AddWithValue("@LoadType", loadType);
                        cmd.Parameters.AddWithValue("@AvailableDate", availableDate);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data saved successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}