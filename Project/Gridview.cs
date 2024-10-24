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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Project
{
    public partial class Gridview : Form
    {
        SqlDataAdapter da;
        DataSet ds;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument cr = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        static string Crypath = "";

        private DataTable transportData;

        public Gridview(DataTable data)
        {
            InitializeComponent();
            transportData = data;

            dataGridView1.DataSource = transportData;
        }
        private void Gridview_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\Project\Project\logindb.mdf;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("select * from transtbl", con);
            ds = new DataSet();
            da.Fill(ds);
            string xml = @"C:/Users/Lenovo/source/repos/Project/Project/data.xml";
            ds.WriteXmlSchema(xml);

            Crypath = @"C:/Users/Lenovo/source/repos/Project/Project/aviliablevehiclereport.rpt";
            cr.Load(Crypath);
            cr.SetDataSource(ds);
            cr.Database.Tables[0].SetDataSource(ds);
            cr.Refresh();
            crystalReportViewer1.ReportSource = cr;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
