using System.Collections.Generic;
using FoodJournal.Entities;

namespace FoodJournal.DAL.Interfaces
{
    public interface IAccountDAL
    {
        bool CreateAccount(Account account);
        void DeleteById(int id);
        bool IsAccount(string login, string password);
        void AddRole(Account account);
        Account GetById(int id);
        IEnumerable<Account> GetAll();
    }
}