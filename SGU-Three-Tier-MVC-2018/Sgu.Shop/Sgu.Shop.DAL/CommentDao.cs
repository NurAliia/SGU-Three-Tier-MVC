using Common;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Sgu.StudentTesting.DAL
{
    public class CommentDao: ICommentDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;

        SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public int AddComment(Comment comment)
        {
            string sqlExpression = "sp_InsertComment";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idUser = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = comment.IDUser
                };
                command.Parameters.Add(idUser);

                SqlParameter idShop = new SqlParameter
                {
                    ParameterName = "@IDShop",
                    Value = comment.IDShop
                };
                command.Parameters.Add(idShop);
                SqlParameter text = new SqlParameter
                {
                    ParameterName = "@Text",
                    Value = comment.Text
                };
                command.Parameters.Add(text);

                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = (int)reader["@IdUser"];
                }
                return id;
            }
        }

        public IEnumerable<Comment> GetCommentsByAuthor(int idUser)
        {
            string sqlExpression = "sp_GetCommentsByAuthor";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDUser", idUser);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Comment()
                    {
                        IDComment = (int)reader["IDComment"],
                        NameUser = (string)reader["NameUser"],
                        Text = (string)reader["Text"],
                        Date = (DateTime)reader["Date"],
                        IDShop = (int)reader["IDShop"]
                    };
                }
            }
        }
        public IEnumerable<Comment> GetCommentsByShop(int idShop)
        {
            string sqlExpression = "sp_GetCommentsByShop";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDShop", idShop);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Comment()
                    {
                        IDComment = (int)reader["IDComment"],
                        NameUser = (string)reader["Name"],
                        Text = (string)reader["Text"],
                        Date = (DateTime)reader["Date"]
                    };
                }
            }
        }
        public IEnumerable<Comment> GetCommentsByDate(DateTime date)
        {
            string sqlExpression = "sp_GetCommentsByDate";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Date", date);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Comment()
                    {
                        IDComment = (int)reader["IDComment"],
                        NameUser = (string)reader["NameUser"],
                        Text = (string)reader["Text"],
                        Date = (DateTime)reader["Date"],
                        IDShop = (int)reader["IDShop"]
                    };
                }
            }
        }
        public Comment GetCommentById(int idComment)
        {
            string sqlExpression = "sp_GetCommentById";
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDComment", idComment);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return new Comment()
                        {
                            IDComment = (int)reader["IDComment"],
                            IDUser = (int)reader["IDUser"],
                            NameUser = (string)reader["Name"],
                            Text = (string)reader["Text"],
                            Date = (DateTime)reader["Date"],
                            IDShop = (int)reader["IDShop"]
                        };
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw new Exception($"Question changing was failed | Arguments: userId='{idComment}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
        public bool UpdateComment(Comment comment)
        {
            string sqlExpression = "sp_UpdateComment";
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDComment", comment.IDComment);
                command.Parameters.AddWithValue("@IDUser", comment.NameUser);
                command.Parameters.AddWithValue("@Text", comment.Text);
                command.Parameters.AddWithValue("@Date", comment.Date);
                command.Parameters.AddWithValue("@IDShop", comment.IDShop);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception($"Comment changing was failed | Arguments: userId='{comment.IDComment}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
        public bool DeleteById(int idComment)
        {
            string sqlExpression = "sp_DeleteCommentById";
            using (var connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idShopparam = new SqlParameter
                {
                    ParameterName = "@IDComment",
                    Value = idComment
                };
                command.Parameters.Add(idShopparam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception($"Question deleting was failed | Arguments: questionId='{idComment}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
    }
}
