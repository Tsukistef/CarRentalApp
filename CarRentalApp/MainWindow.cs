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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addRentalRecord = new AddRentalRecord(); // This is calling the form
            addRentalRecord.MdiParent = this; // mdi expects a form to be assigned, 'this' is the form MainWindow
            addRentalRecord.Show();
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vehicleListing = new ManageVehicleListing(); // This is calling the form
            vehicleListing.MdiParent = this; // mdi = multiple document interface
            vehicleListing.Show(); // Displays the form within main window
        }
    }
}
