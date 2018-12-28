using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Configuration;

namespace Sgu.StudentTesting.DAL
{
    public class UserDao : IUserDao
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;

        SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


        public int AddUser(User user, List<byte> password)
        {
            string sqlExpression = "sp_InsertUser";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = user.Name
                };
                command.Parameters.Add(nameParam);

                SqlParameter surNameParam = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = user.LastName
                };
                command.Parameters.Add(surNameParam);

                SqlParameter patronymicParam = new SqlParameter
                {
                    ParameterName = "@Patronymic",
                    Value = user.Patronymic
                };
                command.Parameters.Add(patronymicParam);

                SqlParameter phoneParam = new SqlParameter
                {
                    ParameterName = "@Phone",
                    Value = user.Phone
                };
                command.Parameters.Add(phoneParam);

                SqlParameter mailParam = new SqlParameter
                {
                    ParameterName = "@EMail",
                    Value = user.EMail
                };
                command.Parameters.Add(mailParam);

                SqlParameter passwordParam = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = password.ToArray()
                };
                command.Parameters.Add(passwordParam);
                              
                var reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = (int)reader["@IdUser"];
                }
                return id;
            }
        }
        public IEnumerable<User> GetUsers()
        {
            string sqlExpression = "sp_GetUsers";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User()
                    {
                        IDUser = (int)reader["IDUser"],
                        Name = (string)reader["Name"],
                        LastName = (string)reader["LastName"],
                        Patronymic = (string)reader["Patronymic"],
                        EMail = (string)reader["EMail"]
                    };
                }
            }
        }
        public IEnumerable<City> GetCity()
        {
            string sqlExpression = "sp_City";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new City()
                    {
                        IDCity = (int)reader["IDCity"],
                        NameCity = (string)reader["NameCity"]
                    };
                }
            }
        }
        public IEnumerable<User> GetModerators()
        {
            string sqlExpression = "sp_GetModerators";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User()
                    {
                        IDUser = (int)reader["IDUser"],
                        Name = (string)reader["Name"],
                        LastName = (string)reader["LastName"],
                        Patronymic = (string)reader["Patronymic"],
                        EMail = (string)reader["EMail"]
                    };
                }
            }
        }

        public User GetUserByEMail(string email)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetUserByEMail", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EMail", email);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        User user = new User()
                        {
                            IDUser = (int)reader["IDUser"],
                            Name = reader["Name"] as string,
                            LastName = (string)reader["LastName"],
                            Patronymic = (string)reader["Patronymic"],
                            EMail = (string)reader["EMail"],
                            Phone = (string)reader["Phone"]
                        };
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }
            }
        }
        
        public User GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetUserById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDUser", id);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new User()
                        {
                            IDUser = id,
                            Name = reader["Name"] as string,
                            LastName = (string)reader["LastName"],
                            Patronymic = (string)reader["Patronymic"],
                            EMail = (string)reader["EMail"],
                            Phone = (string)reader["Phone"]
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Required student wasn't found | Arguments: userId='{id}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
        public void RequestRights(int idUser)
        {
            string sqlExpression = "sp_AddReaffirmationRight";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = idUser
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<User> ListRequestRights()
        {
            string sqlExpression = "sp_GetReaffirmationRight";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User()
                    {
                        IDUser = (int)reader["IDUser"],
                        Name = (string)reader["Name"],
                        LastName = (string)reader["LastName"],
                        Patronymic = (string)reader["Patronymic"],
                        EMail = (string)reader["EMail"]
                    };
                }
            }
        }
        public void DeleteRequestRights(int idUser)
        {
            string sqlExpression = "sp_DeleteReaffirmationRight";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = idUser
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }
        public int GetRoleUser(int idUser)
        {
            string sqlExpression = "sp_GetUserRole";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idUserParam = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = idUser
                };
                command.Parameters.Add(idUserParam);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return (int)reader["IDRole"];
                }
                return 0;
            }
        }
        public bool Update(User user)
        {
            string sqlExpression = "sp_UpdateUser";
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDUser", user.IDUser);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Patronymic", user.Patronymic);
                command.Parameters.AddWithValue("@EMail", user.EMail);
                command.Parameters.AddWithValue("@Phone", user.Phone);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }
            }          
        }
        public bool Delete(int id)
        {
            string sqlExpression = "sp_DeleteUser";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idUser = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = id
                };                
                try
                {
                    command.Parameters.Add(idUser);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {                    
                    throw new Exception(e.ToString());                    
                }

            }
        }
        public void DeleteLinkModeratorShop(int idUser, int idShop)
        {
            string sqlExpression = "sp_DeleteUniver";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idUserParam = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = idUser
                };
                command.Parameters.Add(idUserParam);

                SqlParameter idShopParam = new SqlParameter
                {
                    ParameterName = "@IDShop",
                    Value = idShop
                };
                command.Parameters.Add(idShopParam);

                command.ExecuteNonQuery();
            }
        }
        public bool CheckLoginUser(string login, List<byte> password)
        {
            string sqlExpression = "sp_LoginUser";
            using (var connection = GetConnection())
            {
                
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter loginUserParam = new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = login
                };
                command.Parameters.Add(loginUserParam);

                SqlParameter passwordUserParam = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = password.ToArray()
                };
                command.Parameters.Add(passwordUserParam);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }
            }
        }       
    }
}
