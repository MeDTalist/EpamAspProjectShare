using EpamAspProject.Types;

namespace EpamAspProject.Presenters.Interfaces.View
{
    public interface IChangePass
    {
        void ReturnToMain();
        string GetLoginFromCookie();
        string OldPassword { get; set; }
        string NewPass { get; set; }
        bool IsPostBack { get; }
        void ShowMessage(string message);
        bool SetLoginInCookie(User oldUser);
        void ShowSuccessView();
        void ShowStartView();
    }
}