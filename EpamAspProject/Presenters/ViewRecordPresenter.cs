using EpamAspProject.Model;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Presenters
{
    public class ViewRecordPresenter:BasePresenter<IViewRecord>
    {
        private const string DEFAULT_PAGE = "~/Views/Pages/Default.aspx";
        private const string IMAGE = "~/Views/Image.ashx";
        private const string DOWNLOAD = "~/Views/Download.ashx";
        public void Load()
        {
            var login = View.GetLoginFromCookie();
            if (!Users.IsCorrectLogin(login))
            {
                View.RedirectTo(DEFAULT_PAGE);
            }
            var sid = View.GetFromUrl("id");
            if(string.IsNullOrEmpty(sid))
            {
                View.RedirectTo(DEFAULT_PAGE);
            }
            int id;
            if(!int.TryParse(sid,out id))
            {
                View.RedirectTo(DEFAULT_PAGE);
            }
            var record = Records.GetRecordByID(id);
            if(record == null)
            {
                View.RedirectTo(IMAGE);
                return;
            }
            DisplayRecord(record);
            switch (record.Type)
            {
                case "Music":
                    var music = Records.GetMusicById(id);
                    DisplayMusic(music);
                    break;
                case "Book":
                    var book = Records.GetBookById(id);
                    DisplayBook(book);
                    break;
                case "Movie":
                    var movie = Records.GetMovieById(id);
                    DisplayMovie(movie);
                    break;
            }
            View.DisplayImage(id);
        }

        private void DisplayMovie(Movie movie)
        {
            View.ShowMovieView();
            View.SetInLabelValue("LblGenre", movie.Genre);
            View.SetInLabelValue("LblPlayTime", movie.PlayTime);
            View.SetInLabelValue("LblQuality", movie.Quality);

        }

        private void DisplayBook(Book book)
        {
            View.ShowBookView();
            View.SetInLabelValue("LblPages", book.Pages==0?"":book.Pages.ToString());
            View.SetInLabelValue("LblPublishingHouse",book.PublishingHouse);
        }

        private void DisplayMusic(Music music)
        {
            View.ShowMusicView();
            View.SetInLabelValue("LblAlbum", music.Album);
            View.SetInLabelValue("LblBitRate", music.Bitrate==0?"":music.Bitrate.ToString());
            View.SetInLabelValue("LblPlayTime2", music.PlayTime);
            View.SetInLabelValue("LblStyle", music.Style);
        }

        private void DisplayRecord(RichRecord record)
        {
            View.SetInLabelValue("LblIdRecord", record.IDRecord.ToString());
            View.SetInLabelValue("LblAuthor", record.Author);
            View.SetInLabelValue("LblFormat", record.Format);
            View.SetInLabelValue("LblName", record.Name);
            View.SetInLabelValue("LblType", record.Type);
            View.SetInLabelValue("LblUploadBy", Users.GetUserById(record.UploadBy).Login);
            View.SetInLabelValue("LblUploadDate", record.UploadDate.ToString());
            View.SetInLabelValue("LblYear", record.Year.ToString());
        }

        public void Return()
        {
            View.RedirectTo(DEFAULT_PAGE);
        }

        public void Download()
        {
            View.RedirectTo(DOWNLOAD + "?id=" + View.GetFromUrl("id"));
        }
    }
}