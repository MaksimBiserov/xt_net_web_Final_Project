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

        public void DeleteById(int id)
        {
            accountDAL.DeleteById(id);
        }

        public Account GetById(int id)
        {
            return accountDAL.GetById(id);
        }

        public IEnumerable<Account> GetAll()
        {
            return accountDAL.GetAll();
        }

        public void Edit(int id, string login, string password, double bodyWeight, Goals goal)
        {
            accountDAL.Edit(id, login, password, bodyWeight, goal);
        }
    }
}