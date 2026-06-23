namespace BillingSystem
{
    partial class frmBillingHistory
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.DataGridView dgvBillingHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblRecordCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblCustomerName = new Label();
            dgvBillingHistory = new DataGridView();
            btnClose = new Button();
            btnRefresh = new Button();
            panelTop = new Panel();
            lblRecordCount = new Label();
            panelBottom = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvBillingHistory).BeginInit();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Copperplate Gothic Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.Location = new Point(12, 12);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(294, 25);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Billing History — Name";
            // 
            // dgvBillingHistory
            // 
            dgvBillingHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBillingHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillingHistory.Location = new Point(12, 60);
            dgvBillingHistory.MultiSelect = false;
            dgvBillingHistory.Name = "dgvBillingHistory";
            dgvBillingHistory.ReadOnly = true;
            dgvBillingHistory.RowHeadersWidth = 51;
            dgvBillingHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillingHistory.Size = new Size(876, 350);
            dgvBillingHistory.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Font = new Font("Segoe Script", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(813, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 30);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Font = new Font("Viner Hand ITC", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(707, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblCustomerName);
            panelTop.Controls.Add(lblRecordCount);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(900, 50);
            panelTop.TabIndex = 0;
            // 
            // lblRecordCount
            // 
            lblRecordCount.AutoSize = true;
            lblRecordCount.Font = new Font("Segoe UI", 10F);
            lblRecordCount.Location = new Point(250, 18);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(0, 23);
            lblRecordCount.TabIndex = 1;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnRefresh);
            panelBottom.Controls.Add(btnClose);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 425);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(900, 50);
            panelBottom.TabIndex = 2;
            panelBottom.Paint += panelBottom_Paint;
            // 
            // frmBillingHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 475);
            Controls.Add(panelBottom);
            Controls.Add(dgvBillingHistory);
            Controls.Add(panelTop);
            Name = "frmBillingHistory";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Billing History";
            ((System.ComponentModel.ISupportInitialize)dgvBillingHistory).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}