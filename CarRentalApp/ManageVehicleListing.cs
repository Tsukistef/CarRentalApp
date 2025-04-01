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
    public partial class ManageVehicleListing : Form
    {
        private readonly CarRentalEntities carRentalEntities; // declare database entity
        public ManageVehicleListing()
        {
            carRentalEntities = new CarRentalEntities(); // Initialize database
            InitializeComponent();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e) // Loads form
        {
            // var cars = carRentalEntities.TypeOfCars.ToList(); // Get all cars
            var cars = carRentalEntities.TypeOfCars // Modified columns name to display in columns
                .Select(q => new 
                {                 
                    Make = q.Make, 
                    Model = q.Model, 
                    VIN = q.VIN,
                    Year = q.Year,
                    LicensePlateNumber = q.LicensePlateNumber,
                    q.Id
                })
                .ToList();
            gvVehicleList.DataSource = cars; // Set data source from list created from table
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            gvVehicleList.Columns[5].Visible = false;
           // gvVehicleList.Columns[0].HeaderText = "ID";
           // gvVehicleList.Columns[1].HeaderText = "NAME";
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            var addEditVehicle = new AddEditVehicle(); // it's calling the form window
            addEditVehicle.MdiParent = this.MdiParent; // The same parent used for this form must be used for AddEditVehicle
            addEditVehicle.Show();
        }

        private void btdEditCar_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {

        }
    }
}
