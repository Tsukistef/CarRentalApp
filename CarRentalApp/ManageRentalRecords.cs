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
    public partial class ManageRentalRecords : Form
    {
        private readonly CarRentalEntities _db;
        public ManageRentalRecords()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>(); // This is a list of all the open forms
            var isOpen = OpenForms.Any(q => q.Name == "AddEditRentalRecord"); // This is a boolean variable that checks if the form is open or not

            if (!isOpen)
            {
                var addRentalRecord = new AddEditRentalRecord();
                addRentalRecord.MdiParent = this.MdiParent;
                addRentalRecord.Show();
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // Get ID of the selected row
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value; // If wrong row is selected and not the first column arrow then an error will be thrown

                // Query database for record
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                
                var OpenForms = Application.OpenForms.Cast<Form>(); // This is a list of all the open forms
                var isOpen = OpenForms.Any(q => q.Name == "AddEditRentalRecord"); // This is a boolean variable that checks if the form is open or not

                if (!isOpen)
                {
                    var addEditRentalRecord = new AddEditRentalRecord(record);
                    addEditRentalRecord.MdiParent = this.MdiParent;
                    addEditRentalRecord.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease select a row from the left hand side column.");
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // Get ID of the selected row
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

                // Query Database for the record
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                // Delete vehicle from table
                _db.CarRentalRecords.Remove(record);
                _db.SaveChanges();

                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease select a row from the left hand side column.");
            }
        }

        private void ManageRentalRecords_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void PopulateGrid()
        {
            var records = _db.CarRentalRecords
            .Select(q => new
            {
                Customer = q.CustomerName,
                DateOut = q.DateRented,
                DateIn = q.DateReturned,
                Id = q.id,
                q.Cost,
                Car = q.TypesOfCar.Make + " " + q.TypesOfCar.Model // Performing a inner joint
            }).ToList();

            gvRecordList.DataSource = records;
            gvRecordList.Columns["DateIn"].HeaderText = "Date In";
            gvRecordList.Columns["DateOut"].HeaderText = "Date Out";
            //Hide the column for ID. Changed from the hard coded column value to the name, 
            // to make it more dynamic.
            gvRecordList.Columns["Id"].Visible = false;
        }
    }
}
