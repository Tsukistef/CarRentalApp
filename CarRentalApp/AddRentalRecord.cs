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
    public partial class AddRentalRecord : Form
    {
        private readonly CarRentalEntities carRentalEntities; // This is calling the database Entity Namespace (see CarRentaldb.edmx)
        public AddRentalRecord()
        {
            InitializeComponent();
            carRentalEntities = new CarRentalEntities(); // .NET Framework calls the database
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = tbCustomerName.Text;
                var dateIn = dtpRented.Value;
                var dateOut = dtpReturned.Value;
                var typeCar = cbTypeCar.Text;
                double cost = Convert.ToDouble(tbCost.Text);
                var isValid = true;
                var errorMessage = "";

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(typeCar))
                {
                    isValid = false;
                    errorMessage += "Error: Please fill the empty fields\n\r";
                }

                if (dateOut < dateIn)
                {
                    isValid = false;
                    errorMessage +="Error: Date out cannot be before date in\n\r";
                }

                if (isValid == true)
                {
                    var rentalRecord = new CarRentalRecord(); // Call table

                    rentalRecord.CustomerName = customerName;
                    rentalRecord.DateRented = dateIn;
                    rentalRecord.DateReturned = dateOut;
                    rentalRecord.Cost = (decimal)cost; //On the table it is a decimal so it must be converted
                    rentalRecord.TypeOfCarId = (int)cbTypeCar.SelectedValue; // This is calling the id of the selected type of car
                   
                    carRentalEntities.CarRentalRecords.Add(rentalRecord); // Add the record
                    carRentalEntities.SaveChanges(); // Save Changes to Database

                    MessageBox.Show($"Details:\n\r" +
                    $"Customer Name: {customerName}\n\r" +
                    $"Dates: {dateIn} to {dateOut}\n\r" +
                    $"Type of Car: {typeCar}\n\r" +
                    $"Cost: {cost}\n\r" +
                    $"THANK YOU FOR YOUR BUSINESS!");
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }

        private void Form1_Load(object sender, EventArgs e) // This is called when the form is loaded
        {
            var cars = carRentalEntities.TypesOfCars
                .Select(q => new {
                    Id = q.Id,
                    Name = q.Make + " " + q.Model,
                })
                .ToList();// This is calling the data from the database directly

            cbTypeCar.DisplayMember = "Name"; // The visible text e.g. Toyota
            cbTypeCar.ValueMember = "Id"; // The value that needs to be stored related to the type of car
            cbTypeCar.DataSource = cars; // cars is the data source called above as a list
        }
    }
}
