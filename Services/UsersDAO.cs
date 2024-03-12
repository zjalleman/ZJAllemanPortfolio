using System.Data.SqlClient;
using ZJAllemanWeb.Models;

namespace ZJAllemanWeb.Services
{
    public class UsersDAO
    {
        const string connectionString = @"Data Source=zjalleman.database.windows.net;Initial Catalog=DemoDB;User ID=Zjalleman;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Authentication=ActiveDirectoryDefault;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public bool FindUserByNameAndPassword(Demo1UserModel user)
        {
            bool success = false;
            string query = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    success = reader.HasRows;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return success;
            }
        }
    }
}
