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
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private readonly CarRentalEntities _db;
        public AddEditVehicle()
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            this.Text = lblTitle.Text;
            isEditMode = false;
            _db = new CarRentalEntities(); // Initialize database
        }

        public AddEditVehicle(TypesOfCar carToEdit) // Function overload, TypeOfCar is data from Database
        {
            InitializeComponent();
            lblTitle.Text = "Edit Vehicle";
            this.Text = lblTitle.Text;
            isEditMode = true; // determines the behaviour
            _db = new CarRentalEntities(); // Initialize database
            PopulateFields(carToEdit);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEditMode)
                {
                    var id = int.Parse(lblId.Text);
                    var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id); // Query Database for the record
                    car.Model = tbModel.Text;
                    car.Make = tbMake.Text;
                    car.VIN = tbVIN.Text;
                    car.Year = int.Parse(tbYear.Text);
                    car.LicensePlateNumber = tbLicenseNum.Text;

                    _db.SaveChanges();
                }
                else
                {
                    var newCar = new TypesOfCar // Call table
                    {
                        Make = tbMake.Text,
                        Model = tbModel.Text,
                        VIN = tbVIN.Text,
                        Year = int.Parse(tbYear.Text),
                        LicensePlateNumber = tbLicenseNum.Text,
                    };

                    _db.TypesOfCars.Add(newCar); // Add record to table
                    _db.SaveChanges();
                }
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter all fields.");
            }
        }
        private void PopulateFields(TypesOfCar car) // TypeOfCar is data from Database
        {
            lblId.Text = car.Id.ToString();
            tbMake.Text = car.Make;
            tbModel.Text = car.Model;
            tbVIN.Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbLicenseNum.Text = car.LicensePlateNumber;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // or just Close()
        }
    }
}
