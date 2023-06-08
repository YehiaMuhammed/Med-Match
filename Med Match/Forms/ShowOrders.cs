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
    public partial class ShowOrders : UserControl
    {
        public ShowOrders()
        {
            InitializeComponent();
        }

        private void Uphone_txt_Enter(object sender, EventArgs e)
        {
            if (Uphone_txt.Text == "User Phone number...")
            {
                Uphone_txt.Text = string.Empty;
                Uphone_txt.ForeColor = Color.Black;
            }
        }

        private void Uphone_txt_Leave(object sender, EventArgs e)
        {
            if (Uphone_txt.Text == string.Empty)
            {
                Uphone_txt.ForeColor = Color.Gray;
                Uphone_txt.Text = "User Phone number...";
            }
        }
    }
}
