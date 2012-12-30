namespace EpamAspProject.Presenters.Interfaces.View
{
    public interface IForgotPassword
    {
        bool IsPostBack { get; }
        string EMail { get; set; }
        void ShowStartView();
        void RedirectToMain();
        void ShowMessage(string message);
        void ShowSuccessView();
    }
}