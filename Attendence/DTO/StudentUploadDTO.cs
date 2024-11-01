using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.DTO
{
    internal class StudentUploadDTO
    {
        public int Id { get; set; } // Khóa chính
        public string StudentId { get; set; } // Mã số sinh viên
        public string LocalIPAddress { get; set; } // Địa chỉ IP cục bộ
        public string GPSCoordinates { get; set; } // Tọa độ GPS
        public DateTime CreatedAt { get; set; } // Thời gian tạo bản ghi
    }
}
