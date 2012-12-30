using EpamAspProject.Model;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Presenters
{
    public class ForgotPasswordPresenter:BasePresenter<IForgotPassword>
    {
        public void Load()
        {
            if(!View.IsPostBack)
            {
                View.ShowStartView();
            }
        }

        public void CreateNewPassword()
        {
            if(Users.IsExistEmail(View.EMail))
            {
                var login = Users.GetLoginByEmail(View.EMail);
                login.Password = Users.GenerateNewPass();
                if (Users.ChangePassTo(new User { Login = login.Login, Password = login.Password }))
                {
                    MailSender.SendNewPass(login);
                    View.ShowSuccessView();
                }
                else
                {
                    View.ShowMessage("Can't change eMail");
                }
            }
            else
            {
                View.ShowMessage("E-mail not exist");
            }
        }

        public void Cancel()
        {
            View.RedirectToMain();
        }

        public void ReturnToMain()
        {
            View.RedirectToMain();
        }
    }
}