using EpamAspProject.Types;

namespace EpamAspProject.Presenters.Interfaces.View
{
    public interface IViewRecord
    {
        User GetLoginFromCookie();
        void RedirectTo(string page);
        string GetFromUrl(string geted);
        void DisplayImage(int id);
        void SetInLabelValue(string label, string value);
        void ShowMovieView();
        void ShowBookView();
        void ShowMusicView();
    }
}