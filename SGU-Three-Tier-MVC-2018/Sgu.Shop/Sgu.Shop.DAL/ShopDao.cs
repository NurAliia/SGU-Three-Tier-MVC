using Common;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Sgu.StudentTesting.DAL
{
    public class ShopDao : IShopDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;

        SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public int AddShop(Shop shop)
        {
            string sqlExpression = "sp_InsertShop";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                                                
                SqlParameter nameShop = new SqlParameter
                {
                    ParameterName = "@NameShop",
                    Value = shop.NameShop
                };
                command.Parameters.Add(nameShop);

                SqlParameter imageShop = new SqlParameter
                {
                    ParameterName = "@Image",
                    Value = shop.Image //.ToArray().Select(x => Convert.ToByte(x)).ToArray()
                };
                command.Parameters.Add(imageShop);

                SqlParameter addressShop = new SqlParameter
                {
                    ParameterName = "@Address",
                    Value = shop.Address
                };
                command.Parameters.Add(addressShop);

                SqlParameter idCityShop = new SqlParameter
                {
                    ParameterName = "@IDCity",
                    Value = shop.City
                };
                command.Parameters.Add(idCityShop);

                SqlParameter websiteShop = new SqlParameter
                {
                    ParameterName = "@Website",
                    Value = shop.Website
                };
                command.Parameters.Add(websiteShop);

                SqlParameter descriptionShop = new SqlParameter
                {
                    ParameterName = "@DescriptionShop",
                    Value = shop.DescriptionShop
                };
                command.Parameters.Add(descriptionShop);

                SqlParameter phoneShop = new SqlParameter
                {
                    ParameterName = "@PhoneShop",
                    Value = shop.PhoneShop
                };
                command.Parameters.Add(phoneShop);

                SqlParameter openingHours = new SqlParameter
                {
                    ParameterName = "@OpeningHours",
                    Value = shop.OpeningHours
                };
                command.Parameters.Add(openingHours);

                SqlParameter shopModerator = new SqlParameter
                {
                    ParameterName = "@Moderator",
                    Value = shop.Moderator
                };
                command.Parameters.Add(shopModerator);

                var reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = (int)reader["@IdUser"];
                }
                return id;
            }
        }
        public IEnumerable<Shop> GetShops()
        {
            string sqlExpression = "sp_GetShops";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Shop()
                    {
                        IDShop = (int)reader["IDShop"],
                        NameShop = (string)reader["NameShop"],
                        Image = (byte[])reader["Image"],
                        Address = (string)reader["Address"],
                        City = (string)reader["NameCity"],
                        Website = (string)reader["Website"],
                        DescriptionShop = (string)reader["DescriptionShop"],
                        PhoneShop = (string)reader["PhoneShop"],
                        OpeningHours = (string)reader["OpeningHours"]
                    };
                }
            }
        }
        public IEnumerable<Shop> GetShopsByModerator(int idModerator)
        {
            string sqlExpression = "sp_GetShopsByModerator";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDModerator", idModerator);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Shop()
                    {
                        IDShop = (int)reader["IDShop"],
                        NameShop = (string)reader["NameShop"],
                        Image = (byte[])reader["Image"], //String.Concat<byte>((byte[])reader["Image"])
                        Address = (string)reader["Address"],
                        City = (string)reader["NameCity"],
                        Website = (string)reader["Website"],
                        DescriptionShop = (string)reader["DescriptionShop"],
                        PhoneShop = (string)reader["PhoneShop"],
                        OpeningHours = (string)reader["OpeningHours"]
                    };
                }
            }
        }
        public IEnumerable<Shop> GetShopsByCity(int idCity)
        {
            using (SqlConnection connection = GetConnection())
            {
                string sqlExpression = "sp_GetShopsByCity";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDCity", idCity);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Shop()
                    {
                        IDShop = (int)reader["IDShop"],
                        NameShop = (string)reader["NameShop"],
                        Image = (byte[])reader["Image"],
                        Address = (string)reader["Address"],
                        City = (string)reader["NameCity"],
                        Website = (string)reader["Website"],
                        DescriptionShop = (string)reader["DescriptionShop"],
                        PhoneShop = (string)reader["PhoneShop"],
                        OpeningHours = (string)reader["OpeningHours"]
                    };
                }
            }
        }

        public IEnumerable<Shop> GetShopsByDescription(string description)
        {
            using (SqlConnection connection = GetConnection())
            {
                string sqlExpression = "sp_GetShopsByDescription";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DescriptionShop", description);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Shop()
                    {
                        IDShop = (int)reader["IDShop"],
                        NameShop = (string)reader["NameShop"],
                        Image = (byte[])reader["Image"],
                        Address = (string)reader["Address"],
                        City = (string)reader["NameCity"],
                        Website = (string)reader["Website"],
                        DescriptionShop = (string)reader["DescriptionShop"],
                        PhoneShop = (string)reader["PhoneShop"],
                        OpeningHours = (string)reader["OpeningHours"]
                    };
                }
            }
        }

        public IEnumerable<Shop> GetShopsByName(string nameShop)
        {
            using (SqlConnection connection = GetConnection())
            {
                string sqlExpression = "sp_GetShopsByName";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NameShop", nameShop);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Shop()
                    {
                        IDShop = (int)reader["IDShop"],
                        NameShop = (string)reader["NameShop"],
                        Image = (byte[])reader["Image"],
                        Address = (string)reader["Address"],
                        City = (string)reader["NameCity"],
                        Website = (string)reader["Website"],
                        DescriptionShop = (string)reader["DescriptionShop"],
                        PhoneShop = (string)reader["PhoneShop"],
                        OpeningHours = (string)reader["OpeningHours"]
                    };
                }
            }
        }

        public Shop GetShopById(int idShop)
        {
            string sqlExpression = "sp_GetShopById";
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDShop", idShop);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return new Shop()
                        {
                            IDShop = (int)reader["IDShop"],
                            NameShop = (string)reader["NameShop"],
                            Image = (byte[])reader["Image"],
                            Address = (string)reader["Address"],
                            City = (string)reader["NameCity"],
                            Website = (string)reader["Website"],
                            DescriptionShop = (string)reader["DescriptionShop"],
                            PhoneShop = (string)reader["PhoneShop"],
                            OpeningHours = (string)reader["OpeningHours"]
                        };
                    }
                    return null;
                }
                    catch (Exception e)
                {
                    throw new Exception($"ShopById changing was failed | Arguments: shopId='{idShop}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }

       
        public void Update(Shop shop)
        {
            string sqlExpression = "sp_UpdateShop";
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDShop", shop.IDShop);
                command.Parameters.AddWithValue("@NameShop", shop.NameShop);
                command.Parameters.AddWithValue("@Image", shop.Image);
                command.Parameters.AddWithValue("@Address", shop.Address);
                command.Parameters.AddWithValue("@City", shop.City);
                command.Parameters.AddWithValue("@Website", shop.Website);
                command.Parameters.AddWithValue("@DescriptionShop", shop.DescriptionShop);
                command.Parameters.AddWithValue("@PhoneShop", shop.PhoneShop);
                command.Parameters.AddWithValue("@OpeningHours", shop.OpeningHours);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();                    
                }
                catch (Exception e)
                {
                    throw new Exception($"Question changing was failed | Arguments:shopId='{shop.IDShop}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }            
        }
        
        public bool DeleteById(int idShop)
        {
            string sqlExpression = "sp_DeleteShop";
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter idShopparam = new SqlParameter
                    {
                        ParameterName = "@IDShop",
                        Value = idShop
                    };
                    command.Parameters.Add(idShopparam);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception($"Shop deleting was failed | Arguments: ShopId='{idShop}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
    }
}
