using Attendence.DAO;
using Attendence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.BLL
{
    internal class TeacherQRDataBLL
    {
        private TeacherQRDataDAO teacherQRDataDAO = new TeacherQRDataDAO();

        public void SaveQRCode(string qrCode, string gpsCoordinates)
        {
            teacherQRDataDAO.SaveQRCodeData(qrCode, gpsCoordinates);
        }

        public List<TeacherQRDataDTO> GetAllQRData()
        {
            return teacherQRDataDAO.GetAllQRData();
        }

        public void DeleteAllQRData()
        {
            teacherQRDataDAO.DeleteAllQRData();
        }

        public TeacherQRDataDTO GetTeacherQRDataByQRCode(string qrCode)
        {
            return teacherQRDataDAO.GetTeacherQRDataByQRCode(qrCode);
        }
    }
}
