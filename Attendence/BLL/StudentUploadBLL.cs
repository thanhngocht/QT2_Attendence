using Attendence.DAO;
using Attendence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.BLL
{
    internal class StudentUploadBLL
    {
        private StudentUploadDAO studentUploadDAO = new StudentUploadDAO();

        public bool CheckIPAddress(string ipAddress)
        {
            return studentUploadDAO.IsIPAddressExists(ipAddress);
        }

        public void AddStudentUpload(StudentUploadDTO studentUpload)
        {
            studentUploadDAO.SaveStudentUpload(studentUpload);
        }

        public void AddStudentUpload(int id, string studentId, string gpsCoordinates)
        {
            studentUploadDAO.AddStudentUpload(id, studentId, gpsCoordinates);
        }

        public void DeleteAllUploads()
        {
            studentUploadDAO.DeleteAllUploads();
        }

        public List<StudentUploadDTO> GetAllUploads()
        {
            return studentUploadDAO.GetAllUploads();
        }

        public List<string> GetAllStudentIds()
        {
            return studentUploadDAO.GetAllStudentIds();
        }
    }
}
