using System;
using System.Globalization;
using EpamAspProject.Model;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Presenters
{
    public class AddNewRecordPresenter : BasePresenter<IAddNewRecord>
    {
        public void Load()
        {
            var login = View.GetLoginFromCookie();
            if (login == null)
            {
                View.RedirectToMain();
            }
            else if (!Users.IsCorrectLogin(login))
            {
                View.RedirectToMain();
            }
            else if (!Users.IsAdminUser(login))
            {
                View.RedirectToMain();
            }

            if (!View.IsPostBack)
            {
                View.ShowMainView();
            }

            View.ShowMessage("");
        }

        public void Select()
        {
            switch (View.SelectedType)
            {
                case 1:
                    View.ShowMovieView();
                    View.AddTypeToViewState("Movie");
                    break;
                case 2:
                    View.ShowMusicView();
                    View.AddTypeToViewState("Music");
                    break;
                case 3:
                    View.AddTypeToViewState("Book");
                    View.ShowBookView();
                    break;
            }
            View.ShowAddView();
        }

        public void Cancel()
        {
            View.RedirectToMain();
        }

        public bool IsCorrectFile()
        {

            if (!View.HasFile())
            {
                View.ShowMessage("File not input");
                return false;
            }
            var fileName = View.GetFileName();
            var type = View.GetTypeFromViewState();
            var s = System.IO.Path.GetExtension(fileName);
            if (s != null)
            {
                var extension = s.ToLower();
                var fileSize = View.GetFileSize();
                switch (type)
                {
                    case "Movie":
                        if (extension == ".avi" || extension == ".mp4" || extension == ".mkv" || extension == ".3gp")
                        {
                            return true;
                        }
                        View.ShowMessage("Yuo can upload only .avi .mp4 .mkv .3gp extension file");
                        return false;
                    case "Music":
                        if (fileSize < 100*1024*1024)
                        {
                            if (extension == ".mp3" || extension == ".flac" || extension == ".wav" ||
                                extension == ".mid" || extension == ".cd")
                            {
                                return true;
                            }
                            View.ShowMessage("Yuo can upload only .mp3 .flac .wav .mid .cd extension file");
                            return false;
                        }
                        View.ShowMessage("Max size of uploded file 100 MB");
                        return false;
                    case "Book":
                        if (fileSize < 100*1024*1024)
                        {
                            if (extension == ".djvu" || extension == ".pdf" || extension == ".fb2")
                            {
                                return true;
                            }
                            View.ShowMessage("Yuo can upload only .djvu .pdf .fb2 extension file");
                            return false;
                        }
                        View.ShowMessage("Max size of uploded file 100 MB");
                        return false;
                }
            }
            return false;
        }

        public void Add()
        {
            //Проверка корректности
            if (!IsCorrectFile())
            {
                return;
            }
            if (View.HasImage)
            {
                if (!IsCorrectImage())
                {
                    return;
                }
            }

            //Сохранение данных
            SaveRecord();

            View.ShowSuccessView();
        }

        private void SaveRecord()
        {
            var type = View.GetTypeFromViewState();
            var record = new RichRecord
                             {
                                 Author = View.Author,
                                 Format = System.IO.Path.GetExtension(View.GetFileName()),
                                 Name = View.Name,
                                 Type = type,
                                 UploadBy = Users.GetIDUser(View.GetLoginFromCookie()),
                                 UploadDate = DateTime.Now,
                                 Year = View.Year
                             };
            Records.AddNewRecord(record);
            record.IDRecord = Records.GetIdRecord(record);
            switch (type)
            {
                case "Movie":
                    var movie = new Movie
                    {
                        Genre = View.Genre,
                        IDRecord = record.IDRecord,
                        PlayTime = View.PlayTime,
                        Quality = View.Quality
                    };
                    Records.AddNewMovie(movie);
                    break;
                case "Music":
                    var music = new Music
                    {
                        Album = View.Album,
                        Bitrate = View.Bitrate,
                        IDRecord = record.IDRecord,
                        PlayTime = View.PlayTime2,
                        Style = View.Style
                    };
                    Records.AddNewMusic(music);
                    break;
                case "Book":
                    var book = new Book
                                    {
                                        IDRecord = record.IDRecord,
                                        Pages = View.Pages,
                                        PublishingHouse = View.PublishingHouse
                                    };
                    Records.AddNewBook(book);
                    break;
            }
            string savePath = @"c:\temp\" + record.IDRecord.ToString(CultureInfo.InvariantCulture) + @"\";
            record.FileWay = View.SaveFileTo(savePath);
            Records.SetFileWay(record);
            if (View.HasImage)
            {
                record.Image = View.SaveImageTo(savePath);
                Records.SetImageWay(record);
            }
        }

        private bool IsCorrectImage()
        {
            if (!View.HasImage)
            {
                return false;
            }
            var fileName = View.GetImageName();
            var s = System.IO.Path.GetExtension(fileName);
            if (s != null)
            {
                var extension = s.ToLower();
                var fileSize = View.GetImageSize();
                if (fileSize < 2*1024*1024)
                {
                    if (extension == ".png" || extension == ".jpg" || extension == ".gif" ||
                        extension == ".jpeg" || extension == ".bmp")
                    {
                        return true;
                    }
                    View.ShowMessage("Image must have .png .jpg .gif .jpeg .bmp extension.");
                    return false;
                }
                View.ShowMessage("Max size of image 2 MB");
                return false;
            }
            return false;
        }

        public void ReturnToMain()
        {
            View.RedirectToMain();
        }
    }
}