using FoodJournal.Entities;
using FoodJournal.BLL.Interfaces;
using FoodJournal.DAL.Interfaces;
using System.Collections.Generic;

namespace FoodJournal.BLL
{
    public class DishBLL: IDishBLL
    {
        private readonly IDishDAL dishDAL;

        public DishBLL(IDishDAL dishDAL)
        {
            this.dishDAL = dishDAL;
        }

        public int AddToDish(Product product)
        {
            return dishDAL.AddToDish(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return dishDAL.GetAll();
        }

        public double GetCalorificSum()
        {
            return dishDAL.GetCalorificSum();
        }

        public double GetCalorificSumElements(double calorific, int netMass)
        {
            return dishDAL.GetCalorificSumElements(calorific, netMass);
        }

        public void DeleteById(int id)
        {
            dishDAL.DeleteById(id);
        }

        public void DeleteAll()
        {
            dishDAL.DeleteAll();
        }
    }
}