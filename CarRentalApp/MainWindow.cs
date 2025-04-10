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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>(); // This is a list of all the open forms
            var IsOpen = OpenForms.Any(q => q.Name == "AddEditRentalRecord"); // This is a boolean variable that checks if the form is open or not
            if (!IsOpen)
            {
                var addRentalRecord = new AddEditRentalRecord(); // This is calling the form only if it not open
                addRentalRecord.MdiParent = this; // mdi expects a form to be assigned, 'this' is the form MainWindow
                addRentalRecord.Show();
            }
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>(); // This is a list of all the open forms
            var IsOpen = OpenForms.Any(q => q.Name == "ManageVehicleListing"); // This is a boolean variable that checks if the form is open or not
            if (!IsOpen)
            {
                var vehicleListing = new ManageVehicleListing(); // This is calling the form
                vehicleListing.MdiParent = this; // mdi = multiple document interface
                vehicleListing.Show(); // Displays the form within main window
            }
        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>(); // This is a list of all the open forms
            var IsOpen = OpenForms.Any(q => q.Name == "ManageRentalRecords"); // This is a boolean variable that checks if the form is open or not
            if (!IsOpen)
            {
                var manageRentalRecords = new ManageRentalRecords(); // This is calling the form
                manageRentalRecords.MdiParent = this; // mdi = multiple document interface
                manageRentalRecords.Show(); // Displays the form within main window
            }
        }
    }
}