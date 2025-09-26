namespace NorthwindCustomerApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadCustomers;
        private System.Windows.Forms.Button btnLoadEmployees;
        private System.Windows.Forms.Button btnLoadOrders;
        private System.Windows.Forms.ListBox listBoxData;
        private System.Windows.Forms.Label lblOutput;

        private void InitializeComponent()
        {
            this.btnLoadCustomers = new System.Windows.Forms.Button();
            this.btnLoadEmployees = new System.Windows.Forms.Button();
            this.btnLoadOrders = new System.Windows.Forms.Button();
            this.listBoxData = new System.Windows.Forms.ListBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.btnLoadCustomers.Text = "Load Customers";
            this.btnLoadCustomers.Location = new System.Drawing.Point(10, 10);
            this.btnLoadCustomers.Click += new System.EventHandler(this.btnLoadCustomers_Click);

            this.btnLoadEmployees.Text = "Load Employees";
            this.btnLoadEmployees.Location = new System.Drawing.Point(130, 10);
            this.btnLoadEmployees.Click += new System.EventHandler(this.btnLoadEmployees_Click);

            this.btnLoadOrders.Text = "Load Orders";
            this.btnLoadOrders.Location = new System.Drawing.Point(250, 10);
            this.btnLoadOrders.Click += new System.EventHandler(this.btnLoadOrders_Click);

            this.lblOutput.Location = new System.Drawing.Point(10, 50);
            this.lblOutput.Size = new System.Drawing.Size(400, 20);

            this.listBoxData.Location = new System.Drawing.Point(10, 80);
            this.listBoxData.Size = new System.Drawing.Size(360, 200);

            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnLoadCustomers);
            this.Controls.Add(this.btnLoadEmployees);
            this.Controls.Add(this.btnLoadOrders);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.listBoxData);
            this.Name = "MainForm";
            this.Text = "Northwind Viewer";
            this.ResumeLayout(false);
        }
    }
}
