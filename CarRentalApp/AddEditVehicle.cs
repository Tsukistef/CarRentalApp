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
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        public AddEditVehicle()
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            isEditMode = false;
        }

        public AddEditVehicle(TypeOfCar carToEdit) // Function overload, TypeOfCar is data from Database
        {
            InitializeComponent();
            lblTitle.Text = "Edit Vehicle";
            isEditMode = true; // determines the behaviour
            PopulateFields(carToEdit);
        }

        private void PopulateFields(TypeOfCar car) // TypeOfCar is data from Database
        {
            tbMake.Text = car.Make;
            tbModel.Text = car.Model;
            tbVIN.Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbLicenseNum.Text = car.LicensePlateNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // If(isEditMode ==true)
            if (isEditMode)
            {

            }
            else
            {

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // or just Close()
        }
    }
}
