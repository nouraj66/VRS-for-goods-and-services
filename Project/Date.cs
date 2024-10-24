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
    public partial class Date : Form
    {
        public DateTime SelectedDate { get; set; }

        public Date()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SelectedDate = dateTimePicker1.Value;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
