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
    public partial class UsersControl : UserControl
    {
        public UsersControl()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
        }

        private void Username_txt_Enter(object sender, EventArgs e)
        {
            if (Username_txt.Text == "Enter username...")
            {
                Username_txt.Text = string.Empty;
                Username_txt.ForeColor = Color.Black;
            }

            

        }

        private void email_txt_Enter(object sender, EventArgs e)
        {
            if (email_txt.Text == "Enter email...")
            {
                email_txt.Text = string.Empty;
                email_txt.ForeColor = Color.Black;
            }
        }

        private void Username_txt_Leave(object sender, EventArgs e)
        {
            if (Username_txt.Text == string.Empty)
            {
                Username_txt.ForeColor = Color.Gray;
                Username_txt.Text = "Enter username...";
            }
        }

        private void email_txt_Leave(object sender, EventArgs e)
        {
            if (email_txt.Text == string.Empty)
            {
                email_txt.ForeColor = Color.Gray;
                email_txt.Text = "Enter email...";
            }
        }
    }
}
