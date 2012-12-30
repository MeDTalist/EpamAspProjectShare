using EpamAspProject.Model;
using EpamAspProject.Presenters.Interfaces.UC;
using EpamAspProject.Types;

namespace EpamAspProject.Presenters
{
    public class UCLoginPresenter : BasePresenter<IUCLogin>
    {
        private void DefaulLoad()
        {
            var login = View.GetLogin();
            if (login != null)
            {
                if (Users.IsCorrectLogin(login))
                {
                    View.SetUserName(login.Login);
                    View.ShowSuccessLoginView();
                }
                else
                {
                    View.RemoveLogin();
                    View.ShowNoLoginView();
                }
            }
            else
            {
                View.ShowNoLoginView();
            }
        }

        public void Load()
        {
            if (View.IsOnUserPages)
            {
                View.ShowDisableView();
            }
            else
            {
                if (!View.IsPostBack)
                {
                    DefaulLoad();
                }
                else
                {
                    if (View.IsActiveNoLoginView)
                    {
                        View.Message = "";
                    }
                    if (View.IsActiveExitView)
                    {
                        View.ShowSuccessLoginView();
                    }
                    if (View.IsActiveDisableView)
                    {
                        View.ShowNoLoginView();
                    }
                }
            }
        }

        public void Registration()
        {
            View.RedirectToRegistration();
        }

        public void FogotPass()
        {
            View.RedirectToFogotPass();
        }

        public void Login()
        {
            var login = new User
                            {
                                Login = View.Login,
                                Password = View.Password
                            };
            if (Users.IsCorrectLogin(login))
            {
                View.SetLogin(login);
                View.ShowSuccessLoginView();
                View.SetUserName(View.Login);
                View.Refresh();
            }
            else
            {
                View.Message = "Invalid login";
            }
        }

        public void Exit()
        {
            View.ShowExitView();
        }

        public void Yes()
        {
            View.RemoveLogin();
            View.ShowNoLoginView();
            View.Refresh();
        }

        public void No()
        {
            View.ShowSuccessLoginView();
        }
    }
}