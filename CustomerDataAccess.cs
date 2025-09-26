using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCustomerApp
{
    public class CustomerDataAccess
    {
        private readonly string _connectionString;

        public CustomerDataAccess(string server, string database, string? username = null, string? password = null, bool trustServerCertificate = false)
        {
            var csb = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = database,
                ApplicationName = "NorthwindCustomerApp",
                Encrypt = true,
                TrustServerCertificate = trustServerCertificate,
                PersistSecurityInfo = false,
                MultipleActiveResultSets = false,
                ConnectTimeout = 15
            };

            if (string.IsNullOrWhiteSpace(username))
            {
                csb.IntegratedSecurity = true;
            }
            else
            {
                csb.IntegratedSecurity = false;
                csb.UserID = username;
                csb.Password = password ?? string.Empty;
            }

            _connectionString = csb.ConnectionString;
        }

        private static SqlCommand CreateTextCommand(SqlConnection conn, string sql)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.CommandTimeout = 15;
            return cmd;
        }

        public async Task<int> GetCustomerCountAsync(CancellationToken ct = default)
        {
            await using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(ct);
            await using var cmd = CreateTextCommand(conn, "SELECT COUNT(*) FROM dbo.Customers;");
            var result = await cmd.ExecuteScalarAsync(ct);
            return Convert.ToInt32(result, CultureInfo.InvariantCulture);
        }

        public async Task<List<string>> GetCustomerLastNamesAsync(CancellationToken ct = default)
        {
            var lastNames = new List<string>();
            await using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(ct);
            await using var cmd = CreateTextCommand(conn, "SELECT ContactName FROM dbo.Customers;");
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess, ct);

            while (await reader.ReadAsync(ct))
            {
                var contact = reader["ContactName"] as string;
                if (!string.IsNullOrWhiteSpace(contact))
                {
                    var parts = contact.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    lastNames.Add(parts.Length > 0 ? parts[^1] : contact);
                }
            }
            return lastNames;
        }

        public async Task<int> GetEmployeeCountAsync(CancellationToken ct = default)
        {
            await using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(ct);
            await using var cmd = CreateTextCommand(conn, "SELECT COUNT(*) FROM dbo.Employees;");
            var result = await cmd.ExecuteScalarAsync(ct);
            return Convert.ToInt32(result, CultureInfo.InvariantCulture);
        }

        public async Task<List<string>> GetEmployeeNamesAsync(CancellationToken ct = default)
        {
            var names = new List<string>();
            await using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(ct);
            await using var cmd = CreateTextCommand(conn, "SELECT LastName FROM dbo.Employees;");
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess, ct);

            while (await reader.ReadAsync(ct))
            {
                var last = reader["LastName"] as string;
                if (!string.IsNullOrWhiteSpace(last))
                {
                    names.Add(last);
                }
            }
            return names;
        }

        public async Task<int> GetOrderCountAsync(CancellationToken ct = default)
        {
            await using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(ct);
            await using var cmd = CreateTextCommand(conn, "SELECT COUNT(*) FROM dbo.Orders;");
            var result = await cmd.ExecuteScalarAsync(ct);
            return Convert.ToInt32(result, CultureInfo.InvariantCulture);
        }

        public async Task<List<string>> GetOrderSummariesAsync(CancellationToken ct = default)
        {
            var summaries = new List<string>();
            await using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(ct);
            await using var cmd = CreateTextCommand(conn, "SELECT OrderID, OrderDate FROM dbo.Orders;");
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess, ct);

            while (await reader.ReadAsync(ct))
            {
                var orderId = reader["OrderID"];
                var orderDate = reader["OrderDate"] is DateTime dt ? dt.ToString("d", CultureInfo.CurrentCulture) : reader["OrderDate"]?.ToString();
                summaries.Add($"Order #{orderId} on {orderDate}");
            }
            return summaries;
        }

        // parameters
        public async Task<List<string>> GetOrdersByYearAsync(int year, CancellationToken ct = default)
        {
            var results = new List<string>();
            await using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(ct);
            await using var cmd = CreateTextCommand(conn,
                "SELECT OrderID, OrderDate FROM dbo.Orders WHERE YEAR(OrderDate) = @Year;");

            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;

            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess, ct);
            while (await reader.ReadAsync(ct))
            {
                var id = reader["OrderID"];
                var dt = reader["OrderDate"] is DateTime d ? d.ToString("d", CultureInfo.CurrentCulture) : reader["OrderDate"]?.ToString();
                results.Add($"Order #{id} on {dt}");
            }
            return results;
        }
    }
}
