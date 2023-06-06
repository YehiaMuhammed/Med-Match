using DnsClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Med_Match
{
    public partial class DashBoard : Form
    {
        bool SidebarExpand;
        bool UsersExpand;

        public DashBoard()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (SidebarExpand)
            {
                // if side bar is minimize
                Sidebar.Width -= 10;
                Logout_panel.Width -= 10;

                if (Sidebar.Width == Sidebar.MinimumSize.Width & Logout_panel.Width == Logout_panel.MinimumSize.Width)
                {
                    SidebarExpand = false;
                    SidebarTimer.Stop();
                }
            }
            else
            {
                // if side bar is maxmize

                Logout_panel.Width += 10;
                Sidebar.Width += 10;
                if (Sidebar.Width == Sidebar.MaximumSize.Width & Logout_panel.Width == Logout_panel.MaximumSize.Width)
                {
                    SidebarExpand = true;
                    SidebarTimer.Stop();
                }
            }
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            UsersTimer.Start();
        }

        private void UsersTimer_Tick(object sender, EventArgs e)
        {
            if (UsersExpand)
            {
                // if side users button is minimize
                UsersPanel.Height -= 10;

                if (UsersPanel.Height == UsersPanel.MinimumSize.Height)
                {
                    UsersExpand = false;
                    UsersTimer.Stop();
                }
            }
            else
            {
                // if side users button is maxmize

                UsersPanel.Height += 10;
                if (UsersPanel.Height == UsersPanel.MaximumSize.Height)
                {
                    UsersExpand = true;
                    UsersTimer.Stop();
                }
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            SidebarTimer.Start();

        }

        private void Sidebar_Paint(object sender, PaintEventArgs e)
        {
            Sidebar.BringToFront();

        }

       
    }
}
