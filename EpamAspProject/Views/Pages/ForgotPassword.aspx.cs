using System;
using EpamAspProject.Presenters;
using EpamAspProject.Presenters.Interfaces.View;

namespace EpamAspProject.Views.Pages
{
    public partial class ForgotPassword : BasePage<ForgotPasswordPresenter,IForgotPassword>,IForgotPassword
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Load();
        }

        protected void BtnCreateNewPasswordClick(object sender, EventArgs e)
        {
            Presenter.CreateNewPassword();
        }

        protected void BtnCancelClick(object sender, EventArgs e)
        {
            Presenter.Cancel();
        }

        protected void BtnReturnToMainClick(object sender, EventArgs e)
        {
            Presenter.ReturnToMain();
        }

        bool IForgotPassword.IsPostBack
        {
            get{return IsPostBack;}
        }

        public string EMail
        {
            get { return TxtEMail.Text; }
            set { TxtEMail.Text = value; }
        }

        public void ShowStartView()
        {
            MVForgotPass.SetActiveView(VStart);
        }

        public void RedirectToMain()
        {
            Response.Redirect("~/Views/Pages/Default.aspx");
        }

        public void ShowMessage(string message)
        {
            LblMessage.Text = message;
        }

        public void ShowSuccessView()
        {
            MVForgotPass.SetActiveView(VSuccess);
        }
    }
}