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
                    ParameterName = "@Login",
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
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool CreateAccount(Account account)
        {
            throw new Exception();
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
                command.CommandText = "SELECT [ID], [Login], [Password], [Role], [ProfileID] FROM [Account]";
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
                    Role = new [] { executeReader["Role"].ToString() },
                    ProfileID = (int)executeReader["ProfileID"]
                };
            }

            return account;
        }

        public bool IsAccount(string login, string password)
        {
            throw new Exception();
        }

        public IEnumerable<Account> GetAll()
        {
            var users = new List<Account>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [ID], [Login], [Password], [Role], [ProfileID] FROM [Account]";
                connection.Open();
                SqlDataReader executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    int id = (int)executeReader["ID"];
                    string login = executeReader["Login"].ToString();
                    string password = "hidden";
                    string role = executeReader["Role"].ToString();
                    int profileID = 1;
                    users.Add(new Account { ID = id, Login = login, Password = password, Role = new[] { role }, ProfileID = profileID });
                }
            }
            return users;
        }
    }
}