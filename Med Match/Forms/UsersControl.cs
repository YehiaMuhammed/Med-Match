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
            Username_txt.Text = string.Empty;
        }

        private void email_txt_Enter(object sender, EventArgs e)
        {
            email_txt.Text = string.Empty;

        }

      

     
    }
}
