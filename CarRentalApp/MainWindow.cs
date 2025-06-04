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
    public partial class MainWindow : Form
    {
        private Login _login;
        public string _roleName;
        public User _user;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Login login, User user) // This allows the form to be opened from the login form
        {
            InitializeComponent();
            _login = login;
            _user = user;
            _roleName = user.UserRoles.FirstOrDefault().Role.shortname; //calling innerjoint table 'Role' and property 'shortname'
        }

        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddEditRentalRecord"))
            {
                var addRentalRecord = new AddEditRentalRecord(); // This is calling the form only if it not open
                addRentalRecord.MdiParent = this; // mdi expects a form to be assigned, 'this' is the form MainWindow
                addRentalRecord.Show();
            }
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("ManageVehicleListing"))
            {
                var vehicleListing = new ManageVehicleListing(); // This is calling the form
                vehicleListing.MdiParent = this; // mdi = multiple document interface
                vehicleListing.Show(); // Displays the form within main window
            }
        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("ManageRentalRecords"))
            {
                var manageRentalRecords = new ManageRentalRecords(); // This is calling the form
                manageRentalRecords.MdiParent = this; // mdi = multiple document interface
                manageRentalRecords.Show(); // Displays the form within main window
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close(); // When MainWindow closes, the login form also closes
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("ManageUsers"))
            {
                var manageUsers = new ManageUsers();
                manageUsers.MdiParent = this;
                manageUsers.Show();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if(_user.password == Utils.DefaultHashedPassword()) // If psw is default, user must change it
            {
                var resetPassword = new ResetPassword(_user); // The instance of ResetPassword form
                resetPassword.ShowDialog(); // Displays the form
            }

            var username = _user.username;
            tsiLoginText.Text = $"Logged in as: {username}";

            if(_roleName != "admin")
            {
                // Only admin can see the option to manage users in the menutoolstrip
                manageUsersToolStripMenuItem.Enabled = false;
            }
        }
    }
}