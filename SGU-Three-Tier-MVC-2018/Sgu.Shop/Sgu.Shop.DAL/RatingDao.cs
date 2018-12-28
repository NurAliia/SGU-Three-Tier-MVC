using Common;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Sgu.StudentTesting.DAL
{
    public class RatingDao: IRatingDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;

        SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public void AddRating(Rating rating)
        {
            string sqlExpression = "sp_InsertRating";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idUser = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = rating.IDUser
                };
                command.Parameters.Add(idUser);

                SqlParameter idShop = new SqlParameter
                {
                    ParameterName = "@IDShop",
                    Value = rating.IDShop
                };
                command.Parameters.Add(idShop);

                SqlParameter ratingparam = new SqlParameter
                {
                    ParameterName = "@Grade",
                    Value = rating.Grade
                };
                command.Parameters.Add(ratingparam);

                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<Rating> GetRatingByAuthor(int idUser)
        {
            string sqlExpression = "sp_GetRatingByAuthor";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDUser", idUser);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Rating()
                    {
                        IDShop = (int)reader["IDShop"],
                        IDUser = (int)reader["IDUser"],
                        Grade = (int)reader["Rating"]
                    };
                }
            }
        }
        public double GetRatingShopById(int idShop)
        {
            string sqlExpression = "sp_GetRatingShopById";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDShop", idShop);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return (reader["avrRating"] is double)?(double)reader["avrRating"]:0;
                }
                else
                {
                    return 0;
                }
            }
        }
        public IEnumerable<Rating> GetRatingByShop(int idShop)
        {
            string sqlExpression = "sp_GetRatingByShop";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDShop", idShop);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Rating()
                    {
                        IDShop = (int)reader["IDShop"],
                        IDUser = (int)reader["IDUser"],
                        Grade = (int)reader["Rating"]
                    };
                }
            }
        }
        public void Update(Rating rating)
        {
            string sqlExpression = "sp_UpdateRating";
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDShop", rating.IDShop);
                command.Parameters.AddWithValue("@IDUser", rating.IDUser);
                command.Parameters.AddWithValue("@Rating", rating.Grade);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception($"Rating changing was failed | Arguments: userId='{rating.IDUser}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
        public void DeleteById(int idRating)
        {
            string sqlExpression = "sp_DeleteRating";
            using (var connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idShopparam = new SqlParameter
                {
                    ParameterName = "@IDComment",
                    Value = idRating
                };
                command.Parameters.Add(idShopparam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception($"Question deleting was failed | Arguments: questionId='{idRating}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
    }
}
