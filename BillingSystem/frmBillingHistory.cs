using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;

namespace BillingSystem
{
    public partial class frmBillingHistory : Form
    {
        private int customerId;
        private string customerName;
        private DataTable billingRecords;

        public frmBillingHistory(int customerId, string customerName)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.customerName = customerName;

            // Display customer name at the top
            lblCustomerName.Text = $"Billing History — {customerName}";

            LoadBillingRecords();
        }

        private void LoadBillingRecords()
        {
            try
            {
                // Parameterized query for security
                string query = @"
                    SELECT 
                        BillingMonth,
                        PreviousReading,
                        PresentReading,
                        Consumption,
                        RatePerCubic,
                        TotalAmount,
                        Status
                    FROM billing 
                    WHERE CustomerID = @CustomerID 
                    ORDER BY BillingDate DESC, BillingMonth DESC";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@CustomerID", customerId)
                };

                billingRecords = DatabaseConnection.ExecuteQuery(query, parameters);

                // Popup #2 - Zero Records Found
                if (billingRecords.Rows.Count == 0)
                {
                    MessageBox.Show($"No billing records found for {customerName}.",
                        "Zero Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvBillingHistory.DataSource = billingRecords;
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading billing records: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dgvBillingHistory.Columns.Count == 0)
                return;

            // Set column headers
            dgvBillingHistory.Columns["BillingMonth"].HeaderText = "Billing Month";
            dgvBillingHistory.Columns["PreviousReading"].HeaderText = "Previous Reading";
            dgvBillingHistory.Columns["PresentReading"].HeaderText = "Present Reading";
            dgvBillingHistory.Columns["Consumption"].HeaderText = "Consumption";
            dgvBillingHistory.Columns["RatePerCubic"].HeaderText = "Rate Per Cubic";
            dgvBillingHistory.Columns["TotalAmount"].HeaderText = "Total Amount";
            dgvBillingHistory.Columns["Status"].HeaderText = "Status";

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBillingRecords();
        }

        private void panelBottom_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}