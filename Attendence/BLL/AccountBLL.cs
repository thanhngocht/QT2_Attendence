using Attendence.DAO;
using Attendence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.BLL
{
    internal class AccountBLL
    {
        private AccountDAO accountDAO = new AccountDAO();

        public void CreateAccount(string username, string password, string fullName)
        {
            AccountDTO account = new AccountDTO
            {
                Username = username,
                Password = password,
                FullName = fullName
            };
            accountDAO.AddAccount(account);
        }

        public void UpdateAccount(AccountDTO account)
        {
            accountDAO.UpdateAccount(account);
        }

        public void DeleteAccount(int id)
        {
            accountDAO.DeleteAccount(id);
        }

        public List<AccountDTO> GetAccounts()
        {
            return accountDAO.GetAllAccounts();
        }

        public AccountDTO GetAccountById(int accountId)
        {
            return accountDAO.GetAccountById(accountId);
        }

        public int geGetUserId(string username, string password)
        {
            return accountDAO.GetUserId(username, password);
        }
    }
}
