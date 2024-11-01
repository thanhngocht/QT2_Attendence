using Attendence.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.DAO
{
    internal class InfoFileDAO
    {
        private string connectionSTR = "Data Source=IIV\\SQLEXPRESS;Initial Catalog=DiemDanh;Integrated Security=True";

        public void AddInfoFile(InfoFileDTO infoFile)
        {
            using (var connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO InfoFile (FileId) VALUES (@FileId);", connection);
                command.Parameters.AddWithValue("@FileId", infoFile.FileId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteInfoFile(int fileId)
        {
            using (var connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM InfoFile WHERE FileId = @FileId;", connection);
                command.Parameters.AddWithValue("@FileId", fileId);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateInfoFile(InfoFileDTO infoFile)
        {
            using (var connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE InfoFile SET NumberOfLessons = @NumberOfLessons, AbsencePercentage = @AbsencePercentage WHERE FileId = @FileId;", connection);
                command.Parameters.AddWithValue("@FileId", infoFile.FileId);
                command.Parameters.AddWithValue("@NumberOfLessons", infoFile.NumberOfLessons);
                command.Parameters.AddWithValue("@AbsencePercentage", infoFile.AbsencePercentage);
                command.ExecuteNonQuery();
            }
        }

        public InfoFileDTO GetInfoFileByFileId(int fileId)
        {
            using (var connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM InfoFile WHERE FileId = @FileId;", connection);
                command.Parameters.AddWithValue("@FileId", fileId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new InfoFileDTO
                        {
                            Id = (int)reader["Id"],
                            FileId = (int)reader["FileId"],
                            NumberOfLessons = (int)reader["NumberOfLessons"],
                            AbsencePercentage = (int)reader["AbsencePercentage"]
                        };
                    }
                }
            }
            return null; // Trả về null nếu không tìm thấy
        }
    }
}
