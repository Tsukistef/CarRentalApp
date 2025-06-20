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
    public partial class AddEditRentalRecord : Form
    {
        private bool isEditMode;
        private readonly CarRentalEntities _db; // This is calling the database Entity Namespace
        public AddEditRentalRecord()
        {
            InitializeComponent();
            lblTitle.Text = "Add New Rental"; // This is the text that will be displayed
            this.Text = "Add New Rental"; // This is the window title
            isEditMode = false;
            _db = new CarRentalEntities(); // .NET Framework calls the database
        }

        public AddEditRentalRecord(CarRentalRecord recordToEdit)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Rental Record";
            this.Text = "Edit Rental Record";
            isEditMode = true; // determines the behaviour
            _db = new CarRentalEntities(); // Initialize database
            PopulateFields(recordToEdit);
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

                if (isValid) //if (isValid == true)
                {
                    if (isEditMode) // then it retrieves what's already in the record
                    {
                        var id = int.Parse(lblRecordId.Text);
                        var rentalRecord = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                        rentalRecord.CustomerName = customerName;
                        rentalRecord.DateRented = dateIn;
                        rentalRecord.DateReturned = dateOut;
                        rentalRecord.Cost = (decimal)cost; //On the table it is a decimal so it must be converted
                        rentalRecord.TypeOfCarId = (int)cbTypeCar.SelectedValue;

                    }
                    else // Create new record
                    {
                        var rentalRecord = new CarRentalRecord(); // Call table

                        rentalRecord.CustomerName = customerName;
                        rentalRecord.DateRented = dateIn;
                        rentalRecord.DateReturned = dateOut;
                        rentalRecord.Cost = (decimal)cost; //On the table it is a decimal so it must be converted
                        rentalRecord.TypeOfCarId = (int)cbTypeCar.SelectedValue; // This is calling the id of the selected type of car

                        _db.CarRentalRecords.Add(rentalRecord); // Add the record                      
                    }

                    _db.SaveChanges();

                    MessageBox.Show($"Details:\n\r" +
                    $"Customer Name: {customerName}\n\r" +
                    $"Dates: {dateIn} to {dateOut}\n\r" +
                    $"Type of Car: {typeCar}\n\r" +
                    $"Cost: {cost}\n\r" +
                    $"THANK YOU FOR YOUR BUSINESS!");

                    Close();
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

        private void PopulateFields(CarRentalRecord recordToEdit)
        {
            tbCustomerName.Text = recordToEdit.CustomerName;
            dtpRented.Value = (DateTime)recordToEdit.DateRented;
            dtpReturned.Value = (DateTime)recordToEdit.DateReturned;
            tbCost.Text = recordToEdit.Cost.ToString();
            lblRecordId.Text = recordToEdit.id.ToString();
        }

        private void AddEditRentalRecord_Load(object sender, EventArgs e)
        {
            // Populate combo boxes
            var cars = _db.TypesOfCars
                .Select(q => new {
                    Id = q.Id,
                    Name = q.Make + " " + q.Model,
                })
                .ToList();// This is calling the data from the database directly

            cbTypeCar.DisplayMember = "Name"; // The visible text e.g. Toyota
            cbTypeCar.ValueMember = "Id"; // The value that needs to be stored related to the type of car
            cbTypeCar.DataSource = cars; // cars is the data source
        }
    }
}
