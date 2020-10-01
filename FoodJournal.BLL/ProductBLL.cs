﻿using System.Collections.Generic;
using FoodJournal.Entities;
using FoodJournal.BLL.Interfaces;
using FoodJournal.DAL.Interfaces;

namespace FoodJournal.BLL
{
    public class ProductBLL : IProductBLL
    {
        private readonly IProductDAL productDAL;

        public ProductBLL(IProductDAL productDAL)
        {
            this.productDAL = productDAL;
        }

        public int Add(Product product)
        {
            return productDAL.Add(product);
        }

        public void DeleteById(int id)
        {
            productDAL.DeleteById(id);
        }

        public void Edit(int id, string name, double calorific, int netMass, byte[] image, Products category, string imageName)
        {
            productDAL.Edit(id, name, calorific, netMass, image, category, imageName);
        }

        public IEnumerable<Product> GetAll(Products products)
        {
            return productDAL.GetAll(products);
        }

        public Product GetById(int id)
        {
            return productDAL.GetById(id);
        }
    }
}