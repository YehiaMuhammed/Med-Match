using DnsClient;
using Med_Match.Forms;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Med_Match
{
    public partial class DashBoard : Form
    {
        bool SidebarExpand;
        bool DrugsExpand;
        private Button lastClickedButton ;

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

     

        private void users_btn_Click(object sender, EventArgs e) //Users button
        {
            UsersControl uc = new UsersControl();
            addUsercontrol(uc);
            Button clickedbutton = (Button)sender;
            if (lastClickedButton != null)
            {
                lastClickedButton.BackColor = Color.LightGreen;
            }
            clickedbutton.BackColor = Color.DarkGreen;
            lastClickedButton = clickedbutton;
            label1.Text = "Users";
        }

        

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            SidebarTimer.Start();

        }

        // make sidebar override all things
        private void Sidebar_Paint(object sender, PaintEventArgs e) 
        {
            Sidebar.BringToFront();  

        }

        // Func to handle user control
        private void addUsercontrol (UserControl userControl) 
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);

        }


        //make black panel override
        private void Logout_panel_Paint(object sender, PaintEventArgs e)
        {
            Logout_panel.BringToFront(); 

        }


        
        private void Home_btn_Click_1(object sender, EventArgs e)
        {
            DashboardControl uc = new DashboardControl();
            addUsercontrol(uc);
            label1.Text = "Dashboard";
            Button clickedbutton = (Button)sender;
            if (lastClickedButton != null)
            {
                lastClickedButton.BackColor = Color.LightGreen;
            }
            clickedbutton.BackColor = Color.DarkGreen;
            lastClickedButton = clickedbutton;


        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            DashboardControl uc = new DashboardControl();
            addUsercontrol(uc);
        }

        private void DrugsTimer_Tick(object sender, EventArgs e)
        {
            if (DrugsExpand)
            {
                // if Drugs panel is minimize
                Drugspanel.Height -= 10;

                if (Drugspanel.Height == Drugspanel.MinimumSize.Height)
                {
                    DrugsExpand = false;
                    DrugsTimer.Stop();
                }
            }
            else
            {
                // if drugs panel is maxmize

                Drugspanel.Height += 10;
                if (Drugspanel.Height == Drugspanel.MaximumSize.Height)
                {
                    DrugsExpand = true;
                    DrugsTimer.Stop();
                }
            }
        }

        private void drugs_btn_Click(object sender, EventArgs e)
        {
            DrugsTimer.Start();
            Button clickedbutton = (Button)sender;
            if (lastClickedButton != null)
            {
                lastClickedButton.BackColor = Color.LightGreen;
            }
            clickedbutton.BackColor = Color.DarkGreen;
            lastClickedButton = clickedbutton;
        }
    }
}
