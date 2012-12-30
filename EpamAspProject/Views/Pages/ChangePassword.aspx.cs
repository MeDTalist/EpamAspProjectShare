using System;
using System.Web;
using EpamAspProject.Presenters;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Views.Pages
{
    public partial class ChangePassword : BasePage<ChangePasswordPresenter,IChangePass>, IChangePass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Load();
        }
        protected void BtnChangeClick(object sender, EventArgs e)
        {
            Presenter.Change();
        }

        protected void BtnCancelClick(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }

        public void ReturnToMain()
        {
            Response.Redirect("~/Views/Pages/Default.aspx");
        }

        public string GetLoginFromCookie()
        {
            var userInfo = Request.Cookies["UserInfo"];
            if (userInfo == null)
            {
                return null;
            }
            return userInfo["UserName"];
        }

        public string OldPassword
        {
            get { return TxtOldPass.Text; }
            set { TxtOldPass.Text = value; }
        }

        public string NewPass
        {
            get { return TxtNewPass.Text; }
            set { TxtNewPass.Text = value; }
        }

        bool IChangePass.IsPostBack
        {
            get { return IsPostBack; }
        }

        public void ShowMessage(string message)
        {
            LblMessage.Text = message;
        }

        public bool SetLoginInCookie(User oldUser)
        {
            if (oldUser == null)
            {
                return false;
            }
            var userInfoCookies = new HttpCookie("UserInfo") { Expires = DateTime.Now.AddDays(1) };
            userInfoCookies["UserName"] = oldUser.Login;
            userInfoCookies["UserPassword"] = oldUser.Password;
            Response.Cookies.Add(userInfoCookies);
            return true;
        }

        public void ShowSuccessView()
        {
            MVChangePass.SetActiveView(VSuccess);
        }

        public void ShowStartView()
        {
            MVChangePass.SetActiveView(VChangingPass);
        }

        protected void BtnReturnClick(object sender, EventArgs e)
        {
            Presenter.Return();
        }
    }
}