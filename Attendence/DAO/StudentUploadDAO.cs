using Attendence.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.DAO
{
    internal class StudentUploadDAO
    {
        private string connectionString = "Data Source=IIV\\SQLEXPRESS;Initial Catalog=DiemDanh;Integrated Security=True";// Thay đổi chuỗi kết nối

        public bool IsIPAddressExists(string ipAddress)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM StudentUploads WHERE LocalIPAddress = @ip", conn);
                cmd.Parameters.AddWithValue("@ip", ipAddress);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void SaveStudentUpload(StudentUploadDTO studentUpload)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentUploads (StudentId, LocalIPAddress, GPSCoordinates) VALUES (@studentId, @ip, @gps)", conn);
                cmd.Parameters.AddWithValue("@studentId", studentUpload.StudentId);
                cmd.Parameters.AddWithValue("@ip", studentUpload.LocalIPAddress);
                cmd.Parameters.AddWithValue("@gps", studentUpload.GPSCoordinates);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddStudentUpload(int id, string studentId, string gpsCoordinates)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentUploads (Id, StudentId, GPSCoordinates) VALUES (@id, @studentId, @gps)", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@gps", gpsCoordinates);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAllUploads()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM StudentUploads", conn);
                cmd.ExecuteNonQuery();
            }
        }

        public List<StudentUploadDTO> GetAllUploads()
        {
            List<StudentUploadDTO> uploads = new List<StudentUploadDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM StudentUploads", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    uploads.Add(new StudentUploadDTO
                    {
                        Id = (int)reader["Id"],
                        StudentId = "" + reader["StudentId"].ToString(),
                        LocalIPAddress = "" + reader["LocalIPAddress"].ToString(),
                        GPSCoordinates = "" + reader["GPSCoordinates"].ToString(),
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    });
                }
            }
            return uploads;
        }

        public List<string> GetAllStudentIds()
        {
            List<string> studentIds = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT StudentId FROM StudentUploads", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    studentIds.Add(reader["StudentId"].ToString());
                }
            }
            return studentIds;
        }
    }
}
