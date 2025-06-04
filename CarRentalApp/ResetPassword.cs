using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class ResetPassword : Form
    {
        private readonly CarRentalEntities _db;
        private User _user;

        public ResetPassword(User user)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _user = user; // we receive an existing user as a parameter to reset the psw, not a new one
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                var password = tbPassword.Text;
                var confirmPassword = tbConfirmPassword.Text;
                var user = _db.Users.FirstOrDefault(q => q.id == _user.id); // we get the user from the database

                if (password != confirmPassword)
                {
                    MessageBox.Show("Password do not match. Please try again");
                }

                user.password = Utils.HashPassword(password);
                _db.SaveChanges();
                MessageBox.Show("Password has been reset successfully.");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occurred. Please try again.");
            }
        }
    }
}
