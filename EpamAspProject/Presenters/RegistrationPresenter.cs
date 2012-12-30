using System;
using EpamAspProject.Model;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Presenters
{
    public class RegistrationPresenter:BasePresenter<IRegistration>
    {
        public void ReturnToMain()
        {
            View.CleanUser(View.GetLogin());
            View.RedirectToStartPage();
        }
        public void Cancel()
        {
            View.RedirectToStartPage();
        }

        public void Registration()
        {
            var newLogin = new RichUser
                               {
                                   EMail = View.EMail,
                                   Login = View.Login,
                                   Password = View.Password
                               };
            try
            {
                if (Users.IsExistEmail(newLogin.EMail))
                {
                    View.ShowMessage("E-mail is already registred");
                    return;
                }
            }
            catch(InvalidCastException)
            {
                View.ShowMessage("Incorrect E-mail");
            }
            try 
            {
            if (Users.IsExistLogin(newLogin.Login))
                {
                    View.ShowMessage("Login is already registred");
                    return;
                }
            }
            catch(InvalidCastException)
            {
                View.ShowMessage("Incorrect Login");
            }
            var secretKey = Users.GenerateSecretKey();
            View.SetSecretKey(newLogin,secretKey);
            MailSender.SendSecretKey(newLogin.EMail, secretKey);
            View.SetValidationEmailView();
        }

        public void Load()
        {
            View.ShowMessage("");
            if (!View.IsPostBack)
            {
                View.SetDefaultView();
            }
        }

        public void ValidateKey()
        {
            var login = View.GetLogin();
            if(login == null)
            {
                View.ShowErrorMessage("Error: Login not found.\nPlease return to start page and try regisraton later.");
                return;
            }
            var richLogin = View.GetRichLogin(login);
            if (richLogin == null)
            {
                View.ShowErrorMessage("Error: Login not found.\nPlease return to start page and try regisraton later.");
                return;
            }
            var loginKey = View.GetLoginKey(login);
            if (loginKey == 0)
            {
                View.ShowErrorMessage("Error: Srcret key not found.\nPlease return to start page and try regisraton later.");
                return;
            }
            var secretKey = int.Parse(View.SecretKey);
            if(secretKey == loginKey)
            {
                View.CleanUser(login);
                if (Users.IsExistEmail(richLogin.EMail))
                {
                    View.ShowErrorMessage("Error: This e-mail is already registred.\nPlease return to start page and try regisraton later.");
                    return;
                }
                if (Users.IsExistLogin(richLogin.Login))
                {
                    View.ShowErrorMessage("Error: This login is already registred.\nPlease return to start page and try regisraton later.");
                    return;
                }
                if (!Users.AddNewUser(richLogin))
                {
                    View.ShowErrorMessage("Error: Creation user faild. Please return to start page and try registration later.");
                }
                View.SetLogin(richLogin);
                View.ShowSuccessView();
            }
            else
            {
                View.ShowErrorMessage("Invalid key");
            }

        }
    }
}