using System.Collections.Generic;
using FoodJournal.Entities;

namespace FoodJournal.DAL.Interfaces
{
    public interface IDishDAL
    {
        int AddToDish(Product product);
        IEnumerable<Product> GetAll();
        double GetCalorificSum();
        double GetCalorificSumElements(double calorific, int netMass);
    }
}