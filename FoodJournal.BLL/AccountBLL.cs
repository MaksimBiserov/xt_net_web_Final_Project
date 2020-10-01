using FoodJournal.Entities;
using FoodJournal.BLL.Interfaces;
using FoodJournal.DAL.Interfaces;
using System.Collections.Generic;

namespace FoodJournal.BLL
{
    public class AccountBLL : IAccountBLL
    {
        private readonly IAccountDAL accountDAL;

        public AccountBLL(IAccountDAL accountDAL)
        {
            this.accountDAL = accountDAL;
        }
        
        public void AddRole(Account account)
        {
            accountDAL.AddRole(account);
        }

        public bool CreateAccount(Account account)
        {
            return accountDAL.CreateAccount(account);
        }

        public void DeleteById(int id)
        {
            accountDAL.DeleteById(id);
        }

        public Account GetById(int id)
        {
            return accountDAL.GetById(id);
        }

        public bool IsAccount(string login, string password)
        {
            return accountDAL.IsAccount(login, password);
        }

        public IEnumerable<Account> GetAll()
        {
            return accountDAL.GetAll();
        }
    }
}