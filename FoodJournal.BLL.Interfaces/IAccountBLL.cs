using System.Collections.Generic;
using FoodJournal.Entities;

namespace FoodJournal.BLL.Interfaces
{
    public interface IAccountBLL
    {
        bool CreateAccount(Account account);
        void DeleteById(int id);
        bool IsAccount(string login, string password);
        void AddRole(Account account);
        Account GetById(int id);
        IEnumerable<Account> GetAll();
    }
}