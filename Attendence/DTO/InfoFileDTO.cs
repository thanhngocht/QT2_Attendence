using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.DTO
{
    internal class InfoFileDTO
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public int NumberOfLessons { get; set; } // Mặc định là -1
        public int AbsencePercentage { get; set; } // Mặc định là -1
    }
}
