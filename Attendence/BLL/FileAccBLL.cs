using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendence.DTO;
using Attendence.DAO;

namespace Attendence.BLL
{
    internal class FileAccBLL
    {
        private FileAccDAO fileDAO = new FileAccDAO();

        public void CreateFile(string fileName, int accountId)
        {
            FileAccDTO file = new FileAccDTO
            {
                FileName = fileName,
                AccountId = accountId
            };
            fileDAO.AddFile(file);
        }

        public void UpdateFile(FileAccDTO file)
        {
            fileDAO.UpdateFile(file);
        }

        public void DeleteFile(int id)
        {
            fileDAO.DeleteFile(id);
        }

        public List<FileAccDTO> GetFiles()
        {
            return fileDAO.GetAllFiles();
        }

        public List<string> LoadFilesByUser(int userId)
        {
            return fileDAO.LoadFilesByUser(userId);
        }

        public void InsertFile(FileAccDTO file)
        {
            fileDAO.InsertFile(file);
        }

        public int GetFileIdByName(string fileName)
        {
            return fileDAO.GetFileIdByName(fileName);
        }

        public void DeleteFileByName(string fileName)
        {
            fileDAO.DeleteFileByName(fileName);
        }
    }
}
