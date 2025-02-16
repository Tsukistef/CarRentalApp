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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
