using Npgsql;
using System;

namespace УП_PR7
{
    internal class AuthService
    {
        private readonly string connectionString = "Host=localhost;Database=tech_shop;Username=postgres;Password=123;Port=5433";

        public int AuthUser(string login, string password)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"SELECT user_id FROM users WHERE login = @login AND password = @password", conn))
                {
                    cmd.Parameters.AddWithValue("login", login);
                    cmd.Parameters.AddWithValue("password", password);

                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }
    }
}
