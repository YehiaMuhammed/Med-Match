using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Med_Match.Forms
{
    public partial class ShowDrugs : UserControl
    {
        public ShowDrugs()
        {
            InitializeComponent();
        }

        private void Drugname_txt_Enter(object sender, EventArgs e)
        {
            if (Drugname_txt.Text == "Enter drug name...")
            {
                Drugname_txt.Text = string.Empty;
                Drugname_txt.ForeColor = Color.Black;
            }
        }

        private void Drugname_txt_Leave(object sender, EventArgs e)
        {
            if (Drugname_txt.Text == string.Empty)
            {
                Drugname_txt.ForeColor = Color.Gray;
                Drugname_txt.Text = "Enter drug name...";
            }
        }

        private void DrugCat_txt_Enter(object sender, EventArgs e)
        {
            if (DrugCat_txt.Text == "Enter drug category...")
            {
                DrugCat_txt.Text = string.Empty;
                DrugCat_txt.ForeColor = Color.Black;
            }
        }

        private void DrugCat_txt_Leave(object sender, EventArgs e)
        {
            if (DrugCat_txt.Text == string.Empty)
            {
                DrugCat_txt.ForeColor = Color.Gray;
                DrugCat_txt.Text = "Enter drug category...";
            }
        }
    }
}
