using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using FoodJournal.Entities;
using FoodJournal.DAL.Interfaces;

namespace FoodJournal.DAL
{
    public class ProductDAL : IProductDAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        SqlCommand command;

        public int Add(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddProduct";

                SqlParameter id = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@ID",
                    Value = product.ID,
                    Direction = System.Data.ParameterDirection.Output
                };

                command.Parameters.Add(id);

                SqlParameter name = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@ProductName",
                    Value = product.Name,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(name);

                SqlParameter calorific = new SqlParameter()
                {
                    DbType = System.Data.DbType.Double,
                    ParameterName = "@Calorific",
                    Value = product.Calorific,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(calorific);

                SqlParameter netMass = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@NetMass",
                    Value = product.NetMass,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(netMass);

                SqlParameter image = new SqlParameter()
                {
                    DbType = System.Data.DbType.Binary,
                    ParameterName = "@Image",
                    Value = product.Image,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(image);

                SqlParameter category = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Category",
                    Value = product.Category,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(category);

                connection.Open();
                command.ExecuteNonQuery();
                return (int)id.Value;
            }
        }

        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [Product] WHERE [ID] = @param1";
                command.Parameters.AddWithValue("@param1", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Edit(int id, string productName, double calorific, int netMass, byte[] image, Products category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;

                string imageUpdate = image != null ? "[Image] = @Image," : "";
                command.CommandText = $@"
                UPDATE [Product] SET 
                    [ProductName] = @ProductName, 
                    [Calorific] = @Calorific, 
                    [NetMass] = @NetMass, 
                    {imageUpdate} 
                    [Category] = @Category 
                WHERE [ID] = @ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@Calorific", calorific);
                command.Parameters.AddWithValue("@NetMass", netMass);
                if(image != null)
                    command.Parameters.AddWithValue("@Image", image);
                command.Parameters.AddWithValue("@Category", category);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Product> GetAll(Products products)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"
                SELECT 
                    [ID], [ProductName], [Calorific], [NetMass], [Image], [Category]
                FROM [Product]";
                if(products != Products.All)
                    command.CommandText += $" WHERE Category = {(int)products}";
                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    yield return (new Product()
                    {
                        ID = (int)executeReader["ID"],
                        Name = executeReader["ProductName"].ToString(),
                        Calorific = (double)executeReader["Calorific"],
                        NetMass = (int)executeReader["NetMass"],
                        Image = Convert.IsDBNull(executeReader["Image"]) ? new byte[] { } : (byte[])executeReader["Image"],
                        Category = (Products)executeReader["Category"]
                    });
                }
            }
        }

        public Product GetById(int id)
        {
            Product product;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [ID], [ProductName], [Calorific], [NetMass], [Image], [Category] FROM [Product] WHERE [ID] = @id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                if (!executeReader.Read())
                {
                    throw new ArgumentException("Invalid product id", "id");
                }

                product = new Product()
                {
                    ID = (int)executeReader["ID"],
                    Name = executeReader["ProductName"].ToString(),
                    Calorific = (double)executeReader["Calorific"],
                    NetMass = (int)executeReader["NetMass"],
                    Image = Convert.IsDBNull(executeReader["Image"]) ? new byte[] { } : (byte[])executeReader["Image"],
                    Category = (Products)executeReader["Category"]
                };
            }

            return product;
        }
    }
}