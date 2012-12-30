using System;
using System.Web;
using EpamAspProject.Presenters;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Views.Pages
{
    public partial class Registration :BasePage<RegistrationPresenter, IRegistration>, IRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Load();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }

        public void RedirectToStartPage()
        {
            Response.Redirect("~/Views/Pages/Default.aspx");
        }

        public string EMail
        {
            get { return TxtEmail.Text; }
            set { TxtEmail.Text = value; }
        }

        public string Login
        {
            get { return TxtLogin.Text; }
            set { TxtLogin.Text = value; }
        }

        bool IRegistration.IsPostBack
        {
            get { return IsPostBack; }
        }

        public string SecretKey
        {
            get { return TxtSecretKey.Text; }
            set { TxtSecretKey.Text = value; }
        }

        public void ShowMessage(string message)
        {
            LblMessage.Text = message;
        }

        public void SetSecretKey(RichUser newLogin, int secretKey)
        {
            Application.Lock();
            if (Application[newLogin.Login]!=null)
            {
                Application.Remove(newLogin.Login);
            }
            Application.Add(newLogin.Login, newLogin);
            if (Application[newLogin.Login + "_key"] != null)
            {
                Application.Remove(newLogin.Login + "_key");
            }
            Application.Add(newLogin.Login + "_key", secretKey);
            Application.UnLock();
            ViewState.Add("NewLogin", newLogin.Login);
        }

        public void SetValidationEmailView()
        {
            MVRegistration.SetActiveView(VEmailValidation);
        }

        public void SetDefaultView()
        {
            MVRegistration.SetActiveView(VDefault);
        }

        public string GetLogin()
        {
            if (ViewState["NewLogin"]==null)
            {
                return null;
            }
            return ViewState["NewLogin"].ToString();
        }

        public void ShowErrorMessage(string message)
        {
            LblErrMessage.Text = message;
        }

        public RichUser GetRichLogin(string login)
        {
            Application.Lock();
            RichUser result = null;
            if (Application[login] != null)
            {
                result = (RichUser) Application[login];
            }
            Application.UnLock();
            return result;
        }

        public int GetLoginKey(string login)
        {
            int result = 0;
            Application.Lock();
            if (Application[login + "_key"] != null)
            {
                result = (int) Application[login + "_key"];
            }
            Application.UnLock();
            return result;
        }

        public void CleanUser(string login)
        {
            Application.Lock();
            if (Application[login] != null)
            {
                Application.Remove(login);
            }
            if (Application[login + "_key"] != null)
            {
                Application.Remove(login + "_key");
            }
            Application.UnLock();
        }

        public bool SetLogin(RichUser login)
        {
            if (login == null)
            {
                return false;
            }
            var userInfoCookies = new HttpCookie("UserInfo") { Expires = DateTime.Now.AddDays(1) };
            userInfoCookies["UserName"] = login.Login;
            userInfoCookies["UserPassword"] = login.Password;
            Response.Cookies.Add(userInfoCookies);
            return true;
        }

        public void ShowSuccessView()
        {
            MVRegistration.SetActiveView(VSuccess);
        }

        public string Password
        {
            get { return TxtPassword.Text; }
            set { TxtPassword.Text = value; }
        }

        protected void BtnRegisration_Click(object sender, EventArgs e)
        {
            Presenter.Registration();
        }

        protected void BtnSendKey_Click(object sender, EventArgs e)
        {
            Presenter.ValidateKey();
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Presenter.ReturnToMain();
        }
    }
}