using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.DTO
{
    internal class TeacherQRDataDTO
    {
        public int Id { get; set; }
        public string QRCode { get; set; }
        public string GPSCoordinates { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
