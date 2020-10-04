using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using FoodJournal.Entities;
using FoodJournal.DAL.Interfaces;

namespace FoodJournal.DAL
{
    public class DishDAL : IDishDAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        SqlCommand command;

        public int AddToDish(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddToDish";

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

                connection.Open();
                command.ExecuteNonQuery();
                return (int)id.Value;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"
                SELECT 
                    [ID], [ProductName], [Calorific], [NetMass]
                FROM [Dish]";

                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    yield return (new Product()
                    {
                        ID = (int)executeReader["ID"],
                        Name = executeReader["ProductName"].ToString(),
                        Calorific = (double)executeReader["Calorific"],
                        NetMass = (int)executeReader["NetMass"]
                    });
                }
            }
        }

        public double GetCalorificSum()
        {
            double totalCalorific = 0;
            int totalNetMass = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"
                SELECT 
                    [Calorific], [NetMass]
                FROM [Dish]";

                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    totalCalorific += (double)executeReader["Calorific"];
                    totalNetMass += (int)executeReader["NetMass"];
                }
            }

            return totalCalorific * (Convert.ToDouble(totalNetMass) / 100);
        }

        public double GetCalorificSumElements(double calorific, int netMass)
        {
            return calorific * (Convert.ToDouble(netMass) / 100);
        }

        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [Dish] WHERE [ID] = @id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAll()
        {
            List<Product> dish = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"
                SELECT 
                    [ID], [ProductName], [Calorific], [NetMass]
                FROM [Dish]";

                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    dish.Add(new Product()
                    {
                        ID = (int)executeReader["ID"],
                        Name = executeReader["ProductName"].ToString(),
                        Calorific = (double)executeReader["Calorific"],
                        NetMass = (int)executeReader["NetMass"]
                    });
                }

                foreach(var product in dish)
                {
                    DeleteById(product.ID);
                }
            }
        }
    }
}