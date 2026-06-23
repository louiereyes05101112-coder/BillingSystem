using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace BillingSystem.Database
{
    // This class provides a reusable database connection.
    // Every form that needs to query MySQL will call
    // DatabaseConnection.GetConnection() instead of
    // writing its own connection string.
    public class DatabaseConnection
    {
        // Connection string settings — update Password if needed
        private const string SERVER = "localhost";
        private const string DATABASE = "BillingDB";
        private const string UID = "root";
        private const string PASSWORD = "louie";  // Add your MySQL password here

        private static string ConnectionString =>
            $"server={SERVER};database={DATABASE};uid={UID};pwd={PASSWORD};";

        // Returns an open-ready MySqlConnection object.
        // Always use inside a 'using' block so it closes automatically.
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Returns true if the app can connect to MySQL.
        // Used by LoginForm on startup to warn the user early.
        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // ============================================================
        // NEW METHODS FOR BILLING HISTORY (ADDED)
        // ============================================================

        /// <summary>
        /// Executes a SELECT query and returns the result as a DataTable.
        /// </summary>
        /// <param name="query">SQL query with parameters</param>
        /// <param name="parameters">Optional MySqlParameter array</param>
        /// <returns>DataTable containing the query results</returns>
        public static DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        /// <summary>
        /// Executes a query that returns a single value (e.g., COUNT, SUM, etc.)
        /// </summary>
        /// <param name="query">SQL query with parameters</param>
        /// <param name="parameters">Optional MySqlParameter array</param>
        /// <returns>The first column of the first row as object</returns>
        public static object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Executes INSERT, UPDATE, or DELETE queries.
        /// </summary>
        /// <param name="query">SQL query with parameters</param>
        /// <param name="parameters">Optional MySqlParameter array</param>
        /// <returns>Number of rows affected</returns>
        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}