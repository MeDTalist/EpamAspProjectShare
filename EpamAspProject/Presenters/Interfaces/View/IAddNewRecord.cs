using EpamAspProject.Types;

namespace EpamAspProject.Presenters.Interfaces.View
{
    public interface IAddNewRecord
    {
        User GetLoginFromCookie();
        void RedirectToMain();
        void ShowMainView();
        bool IsPostBack { get; }
        int SelectedType { get; }
        bool HasImage { get; }
        string Author { get; set; }
        string Name { get; set; }
        int Year { get; set; }
        string Album { get; set; }
        int Bitrate { get; set; }
        string PlayTime2 { get; set; }
        string Style { get; set; }
        string Genre { get; set; }
        string PlayTime { get; set; }
        string Quality { get; set; }
        int Pages { get; set; }
        string PublishingHouse { get; set; }
        void ShowMovieView();
        void ShowMusicView();
        void ShowBookView();
        void ShowAddView();
        string SaveImageTo(string savePath);
        void AddTypeToViewState(string type);
        bool HasFile();
        void ShowMessage(string message);
        string GetFileName();
        string GetTypeFromViewState();
        int GetFileSize();
        string GetImageName();
        int GetImageSize();
        string SaveFileTo( string savePath);
        void ShowSuccessView();
    }
}