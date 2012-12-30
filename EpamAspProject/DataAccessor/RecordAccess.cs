using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EpamAspProject.Types;

namespace EpamAspProject.DataAccessor
{
    public class RecordAccess : DataBasic
    {
        public static bool AddNewRecord(RichRecord record)
        {
            const string QUARY = @"Exec dbo.AddNewRecord @Name, @Author, @Year, @UploadBy, @UploadDate, @Type, @Format ";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters["@Name"].Value = record.Name;
                    command.Parameters.Add("@Author", SqlDbType.NVarChar);
                    command.Parameters["@Author"].Value = record.Author;
                    command.Parameters.Add("@Year", SqlDbType.Int);
                    command.Parameters["@Year"].Value = record.Year;
                    command.Parameters.Add("@UploadBy", SqlDbType.Int);
                    command.Parameters["@UploadBy"].Value = record.UploadBy;
                    command.Parameters.Add("@UploadDate", SqlDbType.DateTime);
                    command.Parameters["@UploadDate"].Value = record.UploadDate;
                    command.Parameters.Add("@Type", SqlDbType.NVarChar);
                    command.Parameters["@Type"].Value = record.Type;
                    command.Parameters.Add("@Format", SqlDbType.NVarChar);
                    command.Parameters["@Format"].Value = record.Format;
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

        public static int GetIdRecord(RichRecord record)
        {
            const string QUARY = @"Exec dbo.GetIdRecord @UploadDate";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@UploadDate", SqlDbType.DateTime);
                    command.Parameters["@UploadDate"].Value = record.UploadDate;
                    command.Connection.Open();
                    int result = 0;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (int) reader["ID_Record"];
                        }
                        reader.Close();
                    }
                    return result;
                }
            }
        }

        public static bool AddNewMusic(Music music)
        {
            const string QUARY = @"Exec dbo.AddNewMusic @ID_Record, @PlayTyme, @BitRate, @Album, @Style";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = music.IDRecord;
                    command.Parameters.Add("@PlayTyme", SqlDbType.NVarChar);
                    command.Parameters["@PlayTyme"].Value = music.PlayTime;
                    command.Parameters.Add("@BitRate", SqlDbType.Int);
                    command.Parameters["@BitRate"].Value = music.Bitrate;
                    command.Parameters.Add("@Album", SqlDbType.NVarChar);
                    command.Parameters["@Album"].Value = music.Album;
                    command.Parameters.Add("@Style", SqlDbType.NVarChar);
                    command.Parameters["@Style"].Value = music.Style;
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

        public static bool SetFileWay(RichRecord record)
        {
            const string QUARY = @"Exec dbo.SetFileWay @ID_Record, @FileWay";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = record.IDRecord;
                    command.Parameters.Add("@FileWay", SqlDbType.NVarChar);
                    command.Parameters["@FileWay"].Value = record.FileWay;
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

        public static bool SetImageWay(RichRecord record)
        {
            const string QUARY = @"Exec dbo.SetImage @ID_Record, @Image";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = record.IDRecord;
                    command.Parameters.Add("@Image", SqlDbType.NVarChar);
                    command.Parameters["@Image"].Value = record.Image;
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

        public static bool AddNewMovie(Movie movie)
        {
            const string QUARY = @"Exec dbo.AddNewMovie @ID_Record, @PlayTyme, @Genre, @Quality";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = movie.IDRecord;
                    command.Parameters.Add("@PlayTyme", SqlDbType.NVarChar);
                    command.Parameters["@PlayTyme"].Value = movie.PlayTime;
                    command.Parameters.Add("@Genre", SqlDbType.NVarChar);
                    command.Parameters["@Genre"].Value = movie.Genre;
                    command.Parameters.Add("@Quality", SqlDbType.NVarChar);
                    command.Parameters["@Quality"].Value = movie.Quality;
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

        public static bool AddNewBook(Book book)
        {
            const string QUARY = @"Exec dbo.AddNewBook @ID_Record, @PublishingHouse, @Pages";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = book.IDRecord;
                    command.Parameters.Add("@PublishingHouse", SqlDbType.NVarChar);
                    command.Parameters["@PublishingHouse"].Value = book.PublishingHouse;
                    command.Parameters.Add("@Pages", SqlDbType.Int);
                    command.Parameters["@Pages"].Value = book.Pages;
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

        public static RichRecord GetRecordByID(int id)
        {
            const string QUARY = @"Exec dbo.GetRecordById @ID_Record";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = id;
                    command.Connection.Open();
                    RichRecord result = null;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new RichRecord
                            {
                                Author = reader["Author"].ToString(),
                                Format = reader["Format"].ToString(),
                                IDRecord = (int) reader["ID_Record"],
                                Name = reader["Name"].ToString(),
                                Type = reader["Type"].ToString(),
                                Year = (int) reader["Year"],
                                FileWay = reader["FileWay"].ToString(),
                                Image = reader["Image"]==null? null : reader["Image"].ToString(),
                                UploadBy = (int) reader["UploadBy"],
                                UploadDate = (DateTime) reader["UploadDate"]
                            };
                        }
                        reader.Close();
                    }
                    return result;
                }
            }
        }

        public static List<Record> GetAllRecords()
        {
            const string QUARY = @"Exec dbo.GetAllRecords";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Connection.Open();
                    var result = new List<Record>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Record
                                           {
                                               Author = reader["Author"].ToString(),
                                               Format = reader["Format"].ToString(),
                                               Name = reader["Name"].ToString(),
                                               Type = reader["Type"].ToString(),
                                               Year = (int) reader["Year"],
                                               ID = (int) reader["ID_Record"]
                                           }
                                );
                        }
                        reader.Close();
                    }
                    return result;
                }
            }
        }

        public static bool DeleteMusic(int id)
        {
            const string QUARY = @"Exec dbo.DeleteMusic @ID_Record";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = id;
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

        public static bool DeleteBook(int id)
        {
            const string QUARY = @"Exec dbo.DeleteBook @ID_Record";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = id;
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

        public static bool DeleteMovie(int id)
        {
            const string QUARY = @"Exec dbo.DeleteMovie @ID_Record";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = id;
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

        public static bool DeleteRecord(int id)
        {
            const string QUARY = @"Exec dbo.DeleteRecord @ID_Record";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = id;
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

        public static Music GetMusicById(int id)
        {
            const string QUARY = @"Exec dbo.GetMusicById @ID_Record";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = id;
                    command.Connection.Open();
                    Music result = null;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new Music
                            {
                                Album = reader["Album"].ToString(),
                                Bitrate = (int) reader["Bitrate"],
                                IDRecord = (int) reader["ID_Record"],
                                PlayTime = reader["PlayTime"].ToString(),
                                Style = reader["Style"].ToString()
                            };
                        }
                        reader.Close();
                    }
                    return result;
                }
            }
        }

        public static Book GetBookById(int id)
        {
            const string QUARY = @"Exec dbo.GetBookById @ID_Record";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = id;
                    command.Connection.Open();
                    Book result = null;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new Book
                            {
                                IDRecord = (int) reader["ID_Record"],
                                Pages = (int) reader["Pages"],
                                PublishingHouse = reader["PublishingHouse"].ToString()
                            };
                        }
                        reader.Close();
                    }
                    return result;
                }
            }
        }

        public static Movie GetMovieById(int id)
        {
            const string QUARY = @"Exec dbo.GetMovieById @ID_Record";
            var connectionString = GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(QUARY, connection))
                {
                    command.Parameters.Add("@ID_Record", SqlDbType.Int);
                    command.Parameters["@ID_Record"].Value = id;
                    command.Connection.Open();
                    Movie result = null;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new Movie
                            {
                                IDRecord = (int)reader["ID_Record"],
                                Genre = reader["Genre"].ToString(),
                                PlayTime = reader["PlayTime"].ToString(),
                                Quality = reader["Quality"].ToString()
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