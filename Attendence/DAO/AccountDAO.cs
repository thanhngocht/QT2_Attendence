using Attendence.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Attendence.DAO
{
    internal class AccountDAO
    {
        private string connectionSTR = "Data Source=IIV\\SQLEXPRESS;Initial Catalog=DiemDanh;Integrated Security=True";

        public void AddAccount(AccountDTO account)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "INSERT INTO Account (username, password, FullName) VALUES (@Username, @Password, @FullName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", account.Username);
                command.Parameters.AddWithValue("@Password", account.Password);
                command.Parameters.AddWithValue("@FullName", account.FullName);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateAccount(AccountDTO account)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "UPDATE Account SET username = @Username, password = @Password, FullName = @FullName WHERE id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", account.Id);
                command.Parameters.AddWithValue("@Username", account.Username);
                command.Parameters.AddWithValue("@Password", account.Password);
                command.Parameters.AddWithValue("@FullName", account.FullName);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAccount(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "DELETE FROM Account WHERE id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<AccountDTO> GetAllAccounts()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "SELECT * FROM Account";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AccountDTO account = new AccountDTO
                    {
                        Id = (int)reader["id"],
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        FullName = reader["FullName"].ToString()
                    };
                    accounts.Add(account);
                }
            }
            return accounts;
        }

        public AccountDTO GetAccountById(int accountId)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                string query = "SELECT id, username, FullName FROM Account WHERE id = @accountId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountId", accountId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AccountDTO
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                FullName = reader.GetString(2).Trim()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int GetUserId(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                string query = "SELECT id FROM Account WHERE username = @username AND password = @password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return -1; // Trả về null nếu không tìm thấy
        }
    }
}
