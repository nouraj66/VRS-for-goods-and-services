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
    public partial class Client : Form
    {
        private readonly string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\Project\Project\logindb.mdf;Integrated Security=True");

        public Client()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Get the selected date from the date picker
            DateTime date = dateTimePicker1.Value.Date;

            // Fetch transport data based on the available date
            DataTable transportData = GetTransportData(date); 

            if (transportData.Rows.Count > 0)
            {
                Gridview gg = new Gridview(transportData);
                gg.Show();
            }
            else
            {
                MessageBox.Show("No vehicle found for the selected date.",
                                "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Fetch data based on available date only
        private DataTable GetTransportData(DateTime date) 
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
    
                    string query =@"SELECT ID, Name, Phone, Email, Address, VehicleType, LoadType, AvailableDate FROM transtbl WHERE AvailableDate = @AvailableDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@AvailableDate", date);

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Profile JJ = new Profile();
            JJ.Show();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}


