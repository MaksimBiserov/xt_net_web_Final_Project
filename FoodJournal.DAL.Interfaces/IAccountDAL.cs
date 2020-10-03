using System.Collections.Generic;
using FoodJournal.Entities;

namespace FoodJournal.DAL.Interfaces
{
    public interface IAccountDAL
    {
        void AddRole(Account account);
        Account GetById(int id);
        void DeleteById(int id);
        IEnumerable<Account> GetAll();
        void Edit(int id, string login, string password, double bodyWeight, Goals goal);
    }
}