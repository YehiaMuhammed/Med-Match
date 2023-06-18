using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Med_Match.Forms
{
    public partial class login : Form
    {
        private char hiddenChar = '*'; 
        private char visibleChar = '\0'; 
        private bool passwordVisible = false;
        public login()
        {
            InitializeComponent();
            if (Password_txt.Text=="Password...")
            {
                Password_txt.PasswordChar = visibleChar;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Drugname_txt_Enter(object sender, EventArgs e)
        {
            if (username_txt.Text == "username or email...")
            {
                username_txt.Text = string.Empty;
                username_txt.ForeColor = Color.Black;
            }
        }

        private void username_txt_Leave(object sender, EventArgs e)
        {
            if (username_txt.Text == string.Empty)
            {
                username_txt.ForeColor = Color.Gray;
                username_txt.Text = "username or email...";
            }
        }

        private void Password_txt_Enter(object sender, EventArgs e)
        {
            if (Password_txt.Text == "Password...")
            {
                Password_txt.Text = string.Empty;
                Password_txt.ForeColor = Color.Black;
                Password_txt.PasswordChar = hiddenChar;
            }
        }

        private void Password_txt_Leave(object sender, EventArgs e)
        {
            if (Password_txt.Text == string.Empty)
            {
                Password_txt.ForeColor = Color.Gray;
                Password_txt.Text = "Password...";
                Password_txt.PasswordChar = visibleChar;
            }
        }

        private void showHiddenPicturebox_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            if (passwordVisible)
            {
                Password_txt.PasswordChar = visibleChar;
                showHiddenPicturebox.Image = Properties.Resources.hide;               
            }
            else
            {               
                Password_txt.PasswordChar = hiddenChar;
                showHiddenPicturebox.Image = Properties.Resources.view;                        
            }
        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            if (Password_txt.Text == "admin")
            {
                LoadingForm loadingForm = new LoadingForm();
                loadingForm.Show();

                await loadDashboardAsync();
                var OpenForms = Application.OpenForms.Cast<Form>();
                var isOpen = OpenForms.Any(q => q.Name == "DashBoard");
                if (!isOpen)
                {
                    DashBoard frm = new DashBoard(this, username_txt.Text);
                    frm.Show();
                    loadingForm.Close();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

        }
        private async Task loadDashboardAsync()
        {
            await Task.Delay(4500);
        }

    }
}
