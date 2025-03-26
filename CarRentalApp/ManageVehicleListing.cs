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
            var cars = carRentalEntities.TypeOfCars
                .Select(q => new { 
                    Id = q.Id,
                    Make = q.Make, 
                    Model = q.Model, 
                    VIN = q.VIN,
                    LicensePlateNumber = q.LicensePlateNumber,
                    Year = q.Year})
                .ToList();
            gvVehicleList.DataSource = cars; // Set data source from list created from table
            gvVehicleList.Columns[0].HeaderText = "ID";
            gvVehicleList.Columns[1].HeaderText = "NAME";
        }
    }
}
