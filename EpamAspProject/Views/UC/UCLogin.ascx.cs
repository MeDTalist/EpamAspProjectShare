using System;
using System.Web;
using EpamAspProject.Presenters;
using EpamAspProject.Presenters.Interfaces.UC;
using EpamAspProject.Types;

namespace EpamAspProject.Views.UC
{
    public partial class UCLogin : BaseUC<UCLoginPresenter, IUCLogin>, IUCLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Load();
        }

        protected void LBRegistration_Click(object sender, EventArgs e)
        {
            Presenter.Registration();
        }

        protected void LBFgotPassword_Click(object sender, EventArgs e)
        {
            Presenter.FogotPass();
        }

        protected void BTNLogin_Click(object sender, EventArgs e)
        {
            Presenter.Login();
        }

        protected void LBExit_Click(object sender, EventArgs e)
        {
            Presenter.Exit();
        }

        protected void BTNYes_Click(object sender, EventArgs e)
        {
            Presenter.Yes();
        }

        protected void BTNNo_Click(object sender, EventArgs e)
        {
            Presenter.No();
        }

        public string Login
        {
            get { return TXTLogin.Text; }
            set { TXTLogin.Text = value; }
        }

        public string Password
        {
            get { return TXTPassword.Text; }
            set { TXTPassword.Text = value; }
        }

        bool IUCLogin.IsPostBack
        {
            get { return IsPostBack; }
        }

        public bool IsActiveExitView
        {
            get { return MVLogin.GetActiveView() == VExit; }
        }

        public bool IsActiveDisableView
        {
            get { return MVLogin.GetActiveView() == VDisable; }
        }

        public bool IsActiveNoLoginView
        {
            get { return MVLogin.GetActiveView() == VNoLogin; }
        }

        public string Message
        {
            get { return LblMessage.Text; }
            set { LblMessage.Text = value; }
        }

        public void ShowNoLoginView()
        {
            MVLogin.SetActiveView(VNoLogin);
        }

        public void RedirectToRegistration()
        {
            Response.Redirect("~/Views/Pages/Registration.aspx");
        }

        public void RedirectToFogotPass()
        {
            Response.Redirect("~/Views/Pages/ForgotPassword.aspx");
        }

        public void ShowSuccessLoginView()
        {
            MVLogin.SetActiveView(VLoginIsSuccess);
        }

        public void SetUserName(string login)
        {
            LBLUserName.Text = login;
        }

        public void ShowIncorrectUserMessage()
        {
            //TO DO
            throw new NotImplementedException();
        }

        public void ShowExitView()
        {
            MVLogin.SetActiveView(VExit);
        }

        public bool IsOnUserPages
        {
            get
            {
                return HttpContext.Current.Request.Url.AbsolutePath == "/Views/Pages/Registration.aspx" ||
                       HttpContext.Current.Request.Url.AbsolutePath == "/Views/Pages/ForgotPassword.aspx"||
                       HttpContext.Current.Request.Url.AbsolutePath == "/Views/Pages/ChangePassword.aspx";
            }
        }

        public void ShowDisableView()
        {
            MVLogin.SetActiveView(VDisable);
        }

        public User GetLogin()
        {
            HttpCookie userInfoCookies = Request.Cookies["UserInfo"];
            if (userInfoCookies == null)
            {
                return null;
            }
            var result = new User { Login = userInfoCookies["UserName"], Password = userInfoCookies["UserPassword"] };
            return result;
        }

        public bool SetLogin(User login)
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

        public void RemoveLogin()
        {
            var userInfoCookies = new HttpCookie("UserInfo") { Expires = DateTime.Now.AddDays(-1) };
            Response.Cookies.Add(userInfoCookies);
        }

        public void Refresh()
        {
            Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
        }
    }
}