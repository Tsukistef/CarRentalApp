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
            string customerName = tbCustomerName.Text;
            string dateIn = dtpRented.Value.ToString("MM/dd/yyyy");
            string dateOut = dtpReturned.Value.ToString("MM/dd/yyyy");
            var typeCar = cbTypeCar.Text;
            
            MessageBox.Show($"Details:\n\r" +
                $"Customer Name: {customerName}\n\r" +
                $"Dates: {dateIn} to {dateOut}\n\r" +
                $"Type of Car: {typeCar}\n\r" +
                $"THANK YOU FOR YOUR BUSINESS!");
        }
    }
}
