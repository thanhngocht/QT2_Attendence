using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Attendence.DTO;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace Attendence.DAO
{
    internal class FileAccDAO
    {
        private string connectionSTR = "Data Source=IIV\\SQLEXPRESS;Initial Catalog=DiemDanh;Integrated Security=True";

        public void AddFile(FileAccDTO file)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "INSERT INTO FileAcc (file_name, account_id) VALUES (@FileName, @AccountId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FileName", file.FileName);
                command.Parameters.AddWithValue("@AccountId", file.AccountId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateFile(FileAccDTO file)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "UPDATE FileAcc SET file_name = @FileName, account_id = @AccountId WHERE id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", file.Id);
                command.Parameters.AddWithValue("@FileName", file.FileName);
                command.Parameters.AddWithValue("@AccountId", file.AccountId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteFile(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "DELETE FROM FileAcc WHERE id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<FileAccDTO> GetAllFiles()
        {
            List<FileAccDTO> files = new List<FileAccDTO>();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "SELECT * FROM FileAcc";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    FileAccDTO file = new FileAccDTO
                    {
                        Id = (int)reader["id"],
                        FileName = reader["file_name"].ToString(),
                        AccountId = (int)reader["account_id"]
                    };
                    files.Add(file);
                }
            }
            return files;
        }

        public List<string> LoadFilesByUser(int accountId)
        {
            List<string> fileNames = new List<string>();

            string query = "SELECT file_name FROM FileAcc WHERE account_id = @account_id";

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@account_id", accountId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileNames.Add(reader["file_name"].ToString());
                        }
                    }
                }
            }

            return fileNames;
        }

        public void InsertFile(FileAccDTO file)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                string query = "INSERT INTO FileAcc (file_name, account_id) VALUES (@fileName, @account_id)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fileName", file.FileName);
                    command.Parameters.AddWithValue("@account_id", file.AccountId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int GetFileIdByName(string fileName)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "SELECT id FROM FileAcc WHERE file_name = @FileName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FileName", fileName);

                connection.Open();
                object result = command.ExecuteScalar(); // Sử dụng ExecuteScalar để lấy giá trị đầu tiên

                if (result != null)
                {
                    return Convert.ToInt32(result); // Chuyển đổi kết quả sang int và trả về
                }
                else
                {
                    return -1; // Trả về -1 nếu không tìm thấy
                }
            }
        }

        public void DeleteFileByName(string fileName)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                string query = "DELETE FROM FileAcc WHERE file_name = @FileName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FileName", fileName);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
