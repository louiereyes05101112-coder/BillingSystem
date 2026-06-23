using BillingSystem.Database;
using BillingSystem.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtCurrentPassword.PasswordChar = '*';
            txtNewPassword.PasswordChar = '*';
            textRetypePassword.PasswordChar = '*';
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string retypePassword = textRetypePassword.Text.Trim();

            // Required fields
            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(retypePassword))
            {
                MessageBox.Show(
                    "All fields are required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Current Password Check
            if (!VerifyCurrentPassword(currentPassword))
            {
                MessageBox.Show(
                    "Current password is incorrect.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Password Match Check
            if (newPassword != retypePassword)
            {
                MessageBox.Show(
                    "New Password and Retype Password do not match.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Password Complexity Check
            StringBuilder errors = new StringBuilder();

            if (newPassword.Length < 8)
                errors.AppendLine("• Must be at least 8 characters long");

            if (!Regex.IsMatch(newPassword, "[A-Z]"))
                errors.AppendLine("• Must contain at least one uppercase letter");

            if (!Regex.IsMatch(newPassword, "[a-z]"))
                errors.AppendLine("• Must contain at least one lowercase letter");

            if (!Regex.IsMatch(newPassword, "[0-9]"))
                errors.AppendLine("• Must contain at least one numeric digit");

            if (!Regex.IsMatch(newPassword, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]"))
                errors.AppendLine("• Must contain at least one special character");

            if (errors.Length > 0)
            {
                MessageBox.Show(
                    "Password does not meet the following requirements:\n\n" +
                    errors.ToString(),
                    "Password Complexity Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Update Password
            if (UpdatePassword(newPassword))
            {
                MessageBox.Show(
                    "Password changed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
        }

        private bool VerifyCurrentPassword(string currentPassword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT COUNT(*)
                        FROM Users
                        WHERE UserID = @UserID
                        AND Password = @Password";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
                        cmd.Parameters.AddWithValue("@Password", currentPassword);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private bool UpdatePassword(string newPassword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        UPDATE Users
                        SET Password = @Password
                        WHERE UserID = @UserID";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}