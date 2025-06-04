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
    public partial class ManageUsers : Form
    {
        private readonly CarRentalEntities _db;
        public ManageUsers()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(!Utils.FormIsOpen("AddUser"))
            {
                var addUser = new AddUser(this); // Form initialisation
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // Get ID of the selected row
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value; // If wrong row is selected and not the first column arrow then an error will be thrown

                // Query database for record
                var user = _db.Users.FirstOrDefault(q => q.id == id);
                
                var hashed_password = Utils.DefaultHashedPassword(); //"Password@123" for new users
                user.password = hashed_password;
                _db.SaveChanges(); //saves value in the database

                MessageBox.Show($"{user.username}'s password has been reset");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeactivateUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Get ID of the selected row
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value; // If wrong row is selected and not the first column arrow then an error will be thrown

                // Query database for record
                var user = _db.Users.FirstOrDefault(q => q.id == id);
                user.isActive = user.isActive == true ? false : true; // if true change to false, else true
                _db.SaveChanges(); //saves value in the database

                MessageBox.Show($"{user.username}'s active status has changed");
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            //This code populates the grid within the ManageUsers form
            var users = _db.Users
                .Select(q => new
                {
                    q.id,
                    q.username,
                    q.UserRoles.FirstOrDefault().Role.name,
                    q.isActive
                })
                .ToList();

            gvUserList.DataSource = users; // Set data source from list created from table
            gvUserList.Columns["username"].HeaderText = "Username";
            gvUserList.Columns["name"].HeaderText = "Role Name";
            gvUserList.Columns["isActive"].HeaderText = "Status";
            gvUserList.Columns["id"].Visible = false;
            gvUserList.Refresh();
        }
    }
}
