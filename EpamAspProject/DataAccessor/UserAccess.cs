using System;
using System.Data;
using System.Data.SqlClient;
using EpamAspProject.Types;

namespace EpamAspProject.DataAccessor
{
    public class UserAccess : DataBasic
    {
        public static RichUser GetUserByEMail(string eMail)
        {
            const string QUARY = @"Exec dbo.GetUserByEmail @EMail";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@EMail", SqlDbType.NVarChar);
                    command.Parameters["@EMail"].Value = eMail;
                    command.Connection.Open();
                    RichUser result = null;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new RichUser
                                         {
                                             EMail = reader["EMail"].ToString(),
                                             Login = reader["Login"].ToString(),
                                             Password = reader["Password"].ToString(),
                                             IsAdmin = (bool)reader["IsAdmin"]
                                         };
                        }
                        reader.Close();
                    }
                    return result;
                }
            }
        }
        public static RichUser GetUserByLogin(string login)
        {
            const string QUARY = @"Exec dbo.GetUserByLogin @Login";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@Login", SqlDbType.NVarChar);
                    command.Parameters["@Login"].Value = login;
                    command.Connection.Open();
                    RichUser result = null;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new RichUser
                            {
                                EMail = reader["EMail"].ToString(),
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                IsAdmin = (bool)reader["IsAdmin"]
                            };
                        }
                        reader.Close();
                    }
                    return result;
                }
            }
        }

        public static bool AddNewUser(RichUser newLogin)
        {
            const string QUARY = @"Exec dbo.AddNewUser @EMail, @Login, @Password ";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@EMail", SqlDbType.NVarChar);
                    command.Parameters["@EMail"].Value = newLogin.EMail;
                    command.Parameters.Add("@Login", SqlDbType.NVarChar);
                    command.Parameters["@Login"].Value = newLogin.Login;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar);
                    command.Parameters["@Password"].Value = newLogin.Password;
                    command.Connection.Open();
                    int count;
                    try
                    {
                        count = command.ExecuteNonQuery();
                    }
                    catch (InvalidCastException)
                    {
                        return false;
                    }
                    if (count == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public static bool ChangePassTo(User oldUser)
        {
            const string QUARY = @"Exec dbo.ChangePassTo @Login, @Password";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY,connection))
                {
                    command.Parameters.Add("@Login", SqlDbType.NVarChar);
                    command.Parameters["@Login"].Value = oldUser.Login;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar);
                    command.Parameters["@Password"].Value = oldUser.Password;
                    command.Connection.Open();
                    int count;
                    try
                    {
                        count = command.ExecuteNonQuery();
                    }
                    catch (InvalidCastException)
                    {
                        return false;
                    }
                    if (count == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public static int GetIDByLogin(string login)
        {
            const string QUARY = @"Exec dbo.GetUserByLogin @Login";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@Login", SqlDbType.NVarChar);
                    command.Parameters["@Login"].Value = login;
                    command.Connection.Open();
                    int result = 0;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (int) reader["ID_Login"];
                        }
                        reader.Close();
                    }
                    return result;
                }
            }
        }

        public static RichUser GetUserById(int id)
        {
            const string QUARY = @"Exec dbo.GetUserById @Id";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.NVarChar);
                    command.Parameters["@Id"].Value = id;
                    command.Connection.Open();
                    RichUser result = null;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new RichUser
                            {
                                EMail = reader["EMail"].ToString(),
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                IsAdmin = (bool)reader["IsAdmin"]
                            };
                        }
                        reader.Close();
                    }
                    return result;
                }
            }
        }
    }
}