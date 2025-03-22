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
            var cars = carRentalEntities.TypeOfCars.ToList(); // Get all cars
            gvVehicleList.DataSource = cars; // Set data source from list created from table
        }
    }
}
