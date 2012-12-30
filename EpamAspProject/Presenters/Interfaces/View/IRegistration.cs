using EpamAspProject.Types;

namespace EpamAspProject.Presenters.Interfaces.View
{
    public interface IRegistration
    {
        void RedirectToStartPage();
        string EMail { get; set; }
        string Password { get; set; }
        string Login { get; set; }
        bool IsPostBack { get; }
        string SecretKey { get; set; }
        void ShowMessage(string message);
        void SetSecretKey(RichUser newLogin, int secretKey);
        void SetValidationEmailView();
        void SetDefaultView();
        string GetLogin();
        void ShowErrorMessage(string message);
        RichUser GetRichLogin(string login);
        int GetLoginKey(string login);
        void CleanUser(string login);
        void ShowSuccessView();
        bool SetLogin(RichUser user);
    }
}