﻿using System;
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
    public partial class AddUser : Form
    {
        private readonly CarRentalEntities _db;
        private ManageUsers _manageUsers;
        public AddUser(ManageUsers manageUsers)
        {
            _db = new CarRentalEntities();
            InitializeComponent();
            _manageUsers = manageUsers; //So that we can call the PopulateGrid once submitted new user
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            // Initialise variable with roles list
            var roles = _db.Roles.ToList();
            //combo box settings
            cbRoles.DisplayMember = "name";
            cbRoles.ValueMember = "id";
            cbRoles.DataSource = roles;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var username = tbUsername.Text;
                var roleId = (int)cbRoles.SelectedValue;
                var password = Utils.DefaultHashedPassword();

                // the variables are "converted" into values for the database rows
                var user = new User
                {
                    username = username,
                    password = password,
                    isActive = true
                };
                _db.Users.Add(user);
                _db.SaveChanges();

                var userId = user.id;

                var userRole = new UserRole
                {
                    roleid = roleId,
                    userid = userId
                };

                _db.UserRoles.Add(userRole);
                _db.SaveChanges();
                MessageBox.Show("New user added successfully");
                _manageUsers.PopulateGrid();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occurred");
            }
        }
    }
}
