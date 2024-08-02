using System;
using Microsoft.Data.SqlClient;

namespace QuerySqlServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "LAP-1743\\SQLEXPRESS01";
                builder.InitialCatalog = "joswindb";
                builder.IntegratedSecurity = true; // This enables Windows Authentication
                builder.TrustServerCertificate = true; // May be needed for local SQL Server instances

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");

                    String sql = "SELECT CountryId, Name FROM Country";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Country Table");
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1));
                            }
                        }
                        connection.Close();
                    }

                    String sql1 = "SELECT * FROM PersonAddress";
                    using (SqlCommand command = new SqlCommand(sql1, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("\nPersonAddress Table");
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1} {2} {3} {4}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetDataTypeName(4));
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
