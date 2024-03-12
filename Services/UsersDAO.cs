using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using System.Security.Cryptography;
using ZJAllemanWeb.Models;

namespace ZJAllemanWeb.Services
{
    public class UsersDAO
    {
        const string connectionString = @"Server=tcp:zjaserver.database.windows.net,1433;Initial Catalog=DemoDB;Persist Security Info=False;User ID=zja;Password=Sasu296397;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool success = false;
            string query = "SELECT * FROM dbo.Users WHERE username = @username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    success = reader.HasRows;

                    if (success)
                    {
                        //TODO: pw varification here
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return success;
            }
        }

        public UserModel CreateAccount(UserModel user)
        {
            var pwHasher = new PasswordHasher<UserModel>();
            user.Password = pwHasher.HashPassword(user, user.Password);
            string insertUserQuery = "INSERT INTO dbo.Users (USERNAME, PASSWORD) VALUES (@username, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(insertUserQuery, connection);
                cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return user;
        }
    }
}
