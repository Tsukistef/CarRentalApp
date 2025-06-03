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
        private readonly CarRentalEntities _db; // declare database entity
        public ManageVehicleListing()
        {
            InitializeComponent();
            _db = new CarRentalEntities(); // Initialize database
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e) // Loads form
        {
            // var cars = carRentalEntities.TypeOfCars.ToList(); // Get all cars
            var cars = _db.TypesOfCars // Modified columns name to display in columns
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
            if (!Utils.FormIsOpen("AddEditVehicle"))
            {
                var addEditVehicle = new AddEditVehicle(this); // it's calling the form window
                addEditVehicle.ShowDialog();
                addEditVehicle.MdiParent = this.MdiParent; // The same parent used for this form must be used for AddEditVehicle
            }
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                // Get ID of the selected row
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value; // If wrong row is selected and not the first column arrow then an error will be thrown

                // Query database for record
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);

                //Launch AddEditVehicle window with data (form)
                var OpenForms = Application.OpenForms.Cast<Form>(); // This is a list of all the open forms>
                var isOpen = OpenForms.Any(q => q.Name == "AddEditVehicle"); // This is a boolean variable that checks if the form is open or not

                if (!Utils.FormIsOpen("AddEditVehicle"))
                {
                    var addEditVehicle = new AddEditVehicle(car, this);
                    addEditVehicle.MdiParent = this.MdiParent;
                    addEditVehicle.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease select a row from the left hand side column.");
            }           
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                // Get ID of the selected row
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

                // Query Database for the record
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);

                DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    // Delete vehicle from table
                    _db.TypesOfCars.Remove(car);
                    _db.SaveChanges();
                }

                PopulateGrid();

                //if (car != null)
                //{
                //    // Delete vehicle from table
                //    _db.TypesOfCars.Remove(car);
                //    _db.SaveChanges();
                //    PopulateGrid();
                //}
                //else
                //{
                //    MessageBox.Show("Car not found in database.");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease select a row from the left hand side column.");
            }            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        public void PopulateGrid()
        {
            var cars = _db.TypesOfCars // Modified columns name to display in columns
            .Select(q => new
            {
                q.Id,
                Make = q.Make,
                Model = q.Model,
                VIN = q.VIN,
                Year = q.Year,
                LicensePlateNumber = q.LicensePlateNumber
            })
            .ToList();

            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            //Hide the column for ID. Changed from the hard coded column value to the name, 
            // to make it more dynamic.
            gvVehicleList.Columns["id"].Visible = false;
            gvVehicleList.Refresh();
        }
    }
}
