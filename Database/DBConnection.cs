using Npgsql;

namespace PangoTest.Database;

public class DBConnection
{
    private static readonly string ConnectionString = "Host=localhost;Username=root;Password=pass]{;Database=DB";
    
    public static string? GetOtpFromDb(string emailOrPhone)
    {
        // SQL query to retrieve the OTP password from the table. Phone number should be with 995
        // All emails are with lowercase in DB
        string sqlQuery = $@"
                        SELECT ""Password""
                        FROM identity.""OneTimePasswords""
                        WHERE ""Email"" = '{emailOrPhone.ToLower()}'
                        ORDER BY ""CreatedAt"" DESC
                        LIMIT 1;
                        ";
        string sqlQueryForPhone = $@"
                        SELECT ""Password""
                        FROM identity.""OneTimePasswords""
                        WHERE ""Phone"" = '995{emailOrPhone.ToLower()}'
                        ORDER BY ""CreatedAt"" DESC
                        LIMIT 1;
                        ";

        var otp = GetDbValue(ConnectionString, emailOrPhone.Contains("@") ? sqlQuery : sqlQueryForPhone);
        
        return otp;
    }

    private static string? GetDbValue(string connectionString, string sqlQuery)
    {
        string? value = null;

        // Create a new connection to the PostgreSQL database
        using (var conn = new NpgsqlConnection(connectionString))
        {
            try
            {
                // Open the connection
                conn.Open();

                // Create a command to execute the SQL query
                using (var cmd = new NpgsqlCommand(sqlQuery, conn))
                {
                    // Execute the query and get the result
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Check if there is a row returned
                        if (reader.Read())
                        {
                            // Get the value of the column
                            value = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        return value;
    }
    
}