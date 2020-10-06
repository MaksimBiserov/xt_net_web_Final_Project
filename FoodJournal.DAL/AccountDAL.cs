using System;
using System.Data.SqlClient;
using System.Configuration;
using FoodJournal.Entities;
using FoodJournal.DAL.Interfaces;
using System.Collections.Generic;

namespace FoodJournal.DAL
{
    public class AccountDAL : IAccountDAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        SqlCommand command;

        public void AddRole(Account account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAccount";

                SqlParameter id = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@ID",
                    Value = account.ID,
                    Direction = System.Data.ParameterDirection.Output
                };

                command.Parameters.Add(id);

                SqlParameter login = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@LoginName",
                    Value = account.Login,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(login);

                SqlParameter password = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Password",
                    Value = account.Password,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(password);

                SqlParameter role = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Role",
                    Value = account.Role[0],
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(role);

                SqlParameter bodyWeight = new SqlParameter()
                {
                    DbType = System.Data.DbType.Double,
                    ParameterName = "@BodyWeight",
                    Value = account.BodyWeight,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(bodyWeight);

                SqlParameter goal = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Goal",
                    Value = account.Goal,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(goal);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [Account] WHERE [ID] = @param1";
                command.Parameters.AddWithValue("@param1", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Account GetById(int id)
        {
            Account account;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT " +
                    "[ID], " +
                    "[LoginName], " +
                    "[Password], " +
                    "[Role], " +
                    "[BodyWeight], " +
                    "[Goal] " +
                    "FROM [Account] WHERE [ID] = @id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                if (!executeReader.Read())
                {
                    throw new ArgumentException("Invalid account id", "id");
                }

                account = new Account()
                {
                    ID = (int)executeReader["ID"],
                    Login = executeReader["LoginName"].ToString(),
                    Password = executeReader["Password"].ToString(),
                    Role = new[] { executeReader["Role"].ToString() },
                    BodyWeight = (double)executeReader["BodyWeight"],
                    Goal = (Goals)executeReader["Goal"]
                };
            }

            return account;
        }

        public IEnumerable<Account> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                
                command.CommandText =
                    "SELECT " +
                    "[ID], " +
                    "[LoginName], " +
                    "[Password], " +
                    "[Role], " +
                    "[BodyWeight], " +
                    "[Goal] " +
                    "FROM [Account]";

                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    yield return (new Account()
                    {
                        ID = (int)executeReader["ID"],
                        Login = executeReader["LoginName"].ToString(),
                        Password = "hidden",
                        Role = new[] { executeReader["Role"].ToString() },
                        BodyWeight = (double)executeReader["BodyWeight"],
                        Goal = (Goals)executeReader["Goal"]
                    });
                }
            }
        }

        public void Edit(int id, string login, string password, double bodyWeight, Goals goal)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"
                UPDATE [Account] SET 
                    [LoginName] = @LoginName, 
                    [Password] = @Password, 
                    [BodyWeight] = @BodyWeight, 
                    [Goal] = @Goal 
                WHERE [ID] = @ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@LoginName", login);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@BodyWeight", bodyWeight);
                command.Parameters.AddWithValue("@Goal", goal);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}