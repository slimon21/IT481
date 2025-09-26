using System;
using System.Windows.Forms;

namespace NorthwindCustomerApp
{
    public partial class MainForm : Form
    {
        private readonly CustomerBusiness _business;

        public MainForm(string server, string database, string username, string password)
        {
            InitializeComponent();
            _business = new CustomerBusiness(server, database, username, password);
        }

        private void btnLoadCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = $"Customers: {_business.GetCustomerCount()}";
                listBoxData.DataSource = _business.GetCustomerLastNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = $"Employees: {_business.GetEmployeeCount()}";
                listBoxData.DataSource = _business.GetEmployeeNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadOrders_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = $"Orders: {_business.GetOrderCount()}";
                listBoxData.DataSource = _business.GetOrderSummaries();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
