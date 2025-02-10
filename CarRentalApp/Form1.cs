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
            MessageBox.Show($"Thank you for renting with us!\n" +
                $"\nDetails:\n" +
                $"\nCustomer Name: {tbCustomerName.Text}" +
                $"\nDates: {dtpRented.Value.ToString("MM/dd/yyyy")} to {dtpReturned.Value.ToString("MM/dd/yyyy")}" +
                $"\nType of Car: {cbTypeCar.Text}");
        }
    }
}
