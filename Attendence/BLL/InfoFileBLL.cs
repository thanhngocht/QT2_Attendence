using Attendence.DAO;
using Attendence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.BLL
{
    internal class InfoFileBLL
    {
        private readonly InfoFileDAO infoFileDAO = new InfoFileDAO();

        public void SaveInfoFile(int fileId)
        {
            var infoFile = new InfoFileDTO { FileId = fileId };
            infoFileDAO.AddInfoFile(infoFile);
        }

        public void RemoveInfoFile(int fileId)
        {
            infoFileDAO.DeleteInfoFile(fileId);
        }

        public void ModifyInfoFile(InfoFileDTO infoFile)
        {
            infoFileDAO.UpdateInfoFile(infoFile);
        }

        public InfoFileDTO GetInfoFile(int fileId)
        {
            return infoFileDAO.GetInfoFileByFileId(fileId);
        }
    }
}
