using System.Collections.Generic;
using System.IO;
using EpamAspProject.DataAccessor;
using EpamAspProject.Types;

namespace EpamAspProject.Model
{
    public class Records
    {
        public static List<Record> GetAllLibr()
        {
            return RecordAccess.GetAllRecords();
        }

        public static void AddNewRecord(RichRecord record)
        {
            RecordAccess.AddNewRecord(record);
        }

        public static int GetIdRecord(RichRecord record)
        {
            return RecordAccess.GetIdRecord(record);
        }

        public static void AddNewMusic(Music music)
        {
            RecordAccess.AddNewMusic(music);
        }

        public static void SetFileWay(RichRecord record)
        {
            RecordAccess.SetFileWay(record);
        }

        public static void SetImageWay(RichRecord record)
        {
            RecordAccess.SetImageWay(record);
        }

        public static void AddNewMovie(Movie movie)
        {
            RecordAccess.AddNewMovie(movie);

        }

        public static void AddNewBook(Book book)
        {
            RecordAccess.AddNewBook(book);
        }

        public static RichRecord GetRecordByID(int id)
        {
          return RecordAccess.GetRecordByID(id);
        }

        public static void DeleteRecord(int id)
        {
            var record = RecordAccess.GetRecordByID(id);
            if (record!=null)
            {
                if(record.Image!="")
                {
                    DeleteFile(record.Image);
                }
                DeleteFile(record.FileWay);
                switch (record.Type)
                {
                    case "Music":
                        RecordAccess.DeleteMusic(id);
                        break;
                    case "Book":
                        RecordAccess.DeleteBook(id);
                        break;
                    case "Movie":
                        RecordAccess.DeleteMovie(id);
                        break;
                }
                RecordAccess.DeleteRecord(id);
                return;
            }
        }

        private static void DeleteFile(string fileName)
        {
            var file = new FileInfo(fileName);
            if(file.Exists)
            {
                file.Delete();
            }
        }

        public static List<Record> GetFindedLibr(int findBy, string contains)
        {
            var lowerContains = contains.ToLower();
            var result = new List<Record>();
            var all = GetAllLibr();
            switch (findBy)
            {
                case 0:
                    foreach (var record in all)
                    {
                        var lowerString = record.Name.ToLower();
                        if (lowerString.Contains(lowerContains))
                            result.Add(record);
                    }
                    break;
                case 1:
                    foreach (var record in all)
                    {
                        var lowerString = record.Author.ToLower();
                        if (lowerString.Contains(lowerContains))
                            result.Add(record);
                    }
                    break;
                case 2:
                    foreach (var record in all)
                    {
                        var lowerString = record.Year.ToString().ToLower();
                        if (lowerString.Contains(lowerContains))
                            result.Add(record);
                    }
                    break;
                case 3:
                    foreach (var record in all)
                    {
                        var lowerString = record.Type.ToLower();
                        if (lowerString.Contains(lowerContains))
                            result.Add(record);
                    }
                    break;
                case 4:
                    foreach (var record in all)
                    {
                        var lowerString = record.Format.ToLower();
                        if (lowerString.Contains(lowerContains))
                            result.Add(record);
                    }
                    break;

            }
            
            return result;
        }

        public static Music GetMusicById(int id)
        {
            return RecordAccess.GetMusicById(id);
        }

        public static Book GetBookById(int id)
        {
            return RecordAccess.GetBookById(id);
        }

        public static Movie GetMovieById(int id)
        {
            return RecordAccess.GetMovieById(id);
        }
    }
}