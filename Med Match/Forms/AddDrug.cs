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
    public partial class AddDrug : UserControl
    {
        public AddDrug()
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

        private void drugPrive_txt_Enter(object sender, EventArgs e)
        {
            if (drugPrive_txt.Text == "Enter price...")
            {
                drugPrive_txt.Text = string.Empty;
                drugPrive_txt.ForeColor = Color.Black;
            }
        }

        private void drugPrive_txt_Leave(object sender, EventArgs e)
        {
            if (drugPrive_txt.Text == string.Empty)
            {
                drugPrive_txt.ForeColor = Color.Gray;
                drugPrive_txt.Text = "Enter price...";
            }
        }

        private void drugCat_txt_Enter(object sender, EventArgs e)
        {
            if (drugCat_txt.Text == "Enter Category...")
            {
                drugCat_txt.Text = string.Empty;
                drugCat_txt.ForeColor = Color.Black;
            }
        }

        private void drugCat_txt_Leave(object sender, EventArgs e)
        {
            if (drugCat_txt.Text == string.Empty)
            {
                drugCat_txt.ForeColor = Color.Gray;
                drugCat_txt.Text = "Enter Category...";
            }
        }

        private void activelngredient_txt_Enter(object sender, EventArgs e)
        {
            if (activelngredient_txt.Text == "Enter activeIngredient ...")
            {
                activelngredient_txt.Text = string.Empty;
                activelngredient_txt.ForeColor = Color.Black;
            }
        }

        private void activelngredient_txt_Leave(object sender, EventArgs e)
        {
            if (activelngredient_txt.Text == string.Empty)
            {
                activelngredient_txt.ForeColor = Color.Gray;
                activelngredient_txt.Text = "Enter activeIngredient ...";
            }
        }
    }
}
