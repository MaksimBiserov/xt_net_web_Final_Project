//using System.Configuration;
//using System.Data.SqlClient;
//using FoodJournal.Entities;
//using FoodJournal.DAL.Interfaces;

//namespace FoodJournal.DAL
//{
//    public class ProfileDAL
//    {
//        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
//        SqlCommand command;

//        public int Add(Profile profile)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                command = connection.CreateCommand();
//                command.CommandType = System.Data.CommandType.StoredProcedure;
//                command.CommandText = "dbo.AddProfile";

//                SqlParameter id = new SqlParameter()
//                {
//                    DbType = System.Data.DbType.Int32,
//                    ParameterName = "@ID",
//                    Value = profile.ID,
//                    Direction = System.Data.ParameterDirection.Output
//                };

//                command.Parameters.Add(id);

//                SqlParameter name = new SqlParameter()
//                {
//                    DbType = System.Data.DbType.String,
//                    ParameterName = "@ProfileName",
//                    Value = profile.Name,
//                    Direction = System.Data.ParameterDirection.Input
//                };

//                command.Parameters.Add(name);

//                SqlParameter bodyWeight = new SqlParameter()
//                {
//                    DbType = System.Data.DbType.Double,
//                    ParameterName = "@BodyWeight",
//                    Value = profile.BodyWeight,
//                    Direction = System.Data.ParameterDirection.Input
//                };

//                command.Parameters.Add(bodyWeight);

//                SqlParameter goal = new SqlParameter()
//                {
//                    DbType = System.Data.DbType.Int32,
//                    ParameterName = "@Goal",
//                    Value = profile.Goal,
//                    Direction = System.Data.ParameterDirection.Input
//                };

//                command.Parameters.Add(goal);

//                connection.Open();
//                command.ExecuteNonQuery();
//                return (int)id.Value;
//            }
//        }

//        public void DeleteById(int id)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                command = connection.CreateCommand();
//                command.CommandType = System.Data.CommandType.Text;
//                command.CommandText = "DELETE FROM [Profile] WHERE [ID] = @param1";
//                command.Parameters.AddWithValue("@param1", id);
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }

//        public void Edit(int id, string name, double bodyWeight, Goals goal)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                command = connection.CreateCommand();
//                command.CommandType = System.Data.CommandType.Text;
//                command.CommandText = "UPDATE [Profile] SET" +
//                    "[ProfileName] = @param2," +
//                    "[BodyWeight] = @param3," +
//                    "[Goal] = @param4" +
//                    "WHERE [ID] = @param1";
//                command.Parameters.AddWithValue("@param1", id);
//                command.Parameters.AddWithValue("@param2", name);
//                command.Parameters.AddWithValue("@param3", bodyWeight);
//                command.Parameters.AddWithValue("@param4", goal);
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
//    }
//}