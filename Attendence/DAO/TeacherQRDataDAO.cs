using Attendence.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.DAO
{
    internal class TeacherQRDataDAO
    {
        private string connectionString = "Data Source=IIV\\SQLEXPRESS;Initial Catalog=DiemDanh;Integrated Security=True";
        public void SaveQRCodeData(string qrCode, string gpsCoordinates)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TeacherQRData (QRCode, GPSCoordinates) VALUES (@qr, @gps)", conn);
                cmd.Parameters.AddWithValue("@qr", qrCode);
                cmd.Parameters.AddWithValue("@gps", gpsCoordinates);
                cmd.ExecuteNonQuery();
            }
        }

        public List<TeacherQRDataDTO> GetAllQRData()
        {
            List<TeacherQRDataDTO> qrDataList = new List<TeacherQRDataDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TeacherQRData", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    qrDataList.Add(new TeacherQRDataDTO
                    {
                        Id = (int)reader["Id"],
                        QRCode = reader["QRCode"].ToString(),
                        GPSCoordinates = reader["GPSCoordinates"].ToString(),
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    });
                }
            }
            return qrDataList;
        }

        public void DeleteAllQRData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM TeacherQRData", conn);
                cmd.ExecuteNonQuery();
            }
        }

        public TeacherQRDataDTO GetTeacherQRDataByQRCode(string qrCode)
        {
            TeacherQRDataDTO teacherQRData = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, QRCode, GPSCoordinates, CreatedAt FROM TeacherQRData WHERE QRCode = @QRCode", conn);
                cmd.Parameters.AddWithValue("@QRCode", qrCode);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        teacherQRData = new TeacherQRDataDTO
                        {
                            Id = (int)reader["Id"],
                            QRCode = reader["QRCode"].ToString(),
                            GPSCoordinates = reader["GPSCoordinates"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"]
                        };
                    }
                }
            }

            return teacherQRData;
        }
    }
}
