﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class Login : Form
    {
        private readonly CarRentalEntities _db;
        public Login()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SHA256 sha = SHA256.Create(); // Declare Encryption algorithm

                // Trim cuts any whitespace
                var username = tbUsername.Text.Trim(); 
                var password = tbPassword.Text.Trim();

                var hashed_password = Utils.HashPassword(password);

                // Lambda expression Will compare the password typed to the encrypted one
                var user = _db.Users.FirstOrDefault(q => q.username == username && q.password == hashed_password); 
                if (user == null)
                {
                    MessageBox.Show("Please provide valid credentials");
                }
                else
                {
                    var role = user.UserRoles.FirstOrDefault(); // No lambda because it's a one to one relationship
                    var roleShortName = role.Role.shortname;
                    var mainWindow = new MainWindow(this, user);
                    mainWindow.Show(); // The main window will appear
                    Hide(); // It will only close when MainWindow closes.

                }
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
