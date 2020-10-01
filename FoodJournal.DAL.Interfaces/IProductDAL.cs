using System.Collections.Generic;
using FoodJournal.Entities;

namespace FoodJournal.DAL.Interfaces
{
    public interface IProductDAL
    {
        int Add(Product product);
        void DeleteById(int id);
        IEnumerable<Product> GetAll(Products products);
        Product GetById(int id);
        void Edit(int id, string name, double calorific, int netMass, byte[] image, Products category, string imageName);
    }
}