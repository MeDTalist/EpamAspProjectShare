using EpamAspProject.Types;

namespace EpamAspProject.Presenters.Interfaces.UC
{
    public interface IUCLogin
    {
        string Login { get; set; }
        string Password { get; set; }
        bool IsPostBack { get; }
        bool IsActiveExitView { get; }
        bool IsOnUserPages { get; }
        bool IsActiveDisableView { get; }
        bool IsActiveNoLoginView { get; }
        string Message { get; set; }

        void ShowNoLoginView();
        void RedirectToRegistration();
        void RedirectToFogotPass();
        void ShowSuccessLoginView();
        void SetUserName(string login);
        void ShowIncorrectUserMessage();
        void ShowExitView();
        void ShowDisableView();
        User GetLogin();
        bool SetLogin(User login);
        void RemoveLogin();
        void Refresh();
    }
}