using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Load : Form
    {
        public string SelectedLoadType { get; set; }
        public Load()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Check which checkbox is selected
            if (checkBox1.Checked)
                SelectedLoadType = "Hard Goods";
            else if (checkBox2.Checked)
                SelectedLoadType = "Soft Goods";

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
