using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PharmaGo;
using PharmaGo.Models;

namespace PharmaGo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userTextbox.Text))
            {
                MessageBox.Show("Please enter your username", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(pwdTextbox.Text))
            {
                MessageBox.Show("Please enter your password", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new PharmagoContext())
            {
                string username = userTextbox.Text.Trim();
                string password = pwdTextbox.Text;

                var user = db.Users.FirstOrDefault(
                    u => u.Username == username && u.Password == password
                );

                if (user != null)
                {
                    MessageBox.Show("Login Successful", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPasswordForm reset = new ResetPasswordForm(this);
            reset.Show();
            this.Hide();
        }
    }
}
