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
            var cars = carRentalEntities.TypesOfCars // Modified columns name to display in columns
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

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            // Get ID of the selected row
            var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

            // Query database for record
            var car = carRentalEntities.TypesOfCars.FirstOrDefault(q => q.Id == id);

            //Launch AddEditVehicle window with data (form)
            var addEditVehicle = new AddEditVehicle(car);
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            // Get ID of the selected row
            var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

            // Query Database for the record
            var car = carRentalEntities.TypesOfCars.FirstOrDefault(q => q.Id == id);

            // Delete vehicle from table
            carRentalEntities.TypesOfCars.Remove(car);
            carRentalEntities.SaveChanges();

            gvVehicleList.Refresh();
        }
    }
}
