using System.Collections.Generic;
using FoodJournal.Entities;

namespace FoodJournal.BLL.Interfaces
{
    public interface IDishBLL
    {
        int AddToDish(Product product);
        IEnumerable<Product> GetAll();
        double GetCalorificSum();
        double GetCalorificSumElements(double calorific, int netMass);
        void DeleteById(int id);
        void DeleteAll();
    }
}