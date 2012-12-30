using EpamAspProject.Model;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Presenters
{
    public class ChangePasswordPresenter:BasePresenter<IChangePass>
    {
        public void Cancel()
        {
            View.ReturnToMain();
        }

        public void Change()
        {
            var oldUser = new User
                               {
                                   Login = View.GetLoginFromCookie(),
                                   Password = View.OldPassword
                               };
            if(Users.IsCorrectLogin(oldUser))
            {
                oldUser.Password = View.NewPass;
                if(Users.ChangePassTo(oldUser))
                {
                    View.SetLoginInCookie(oldUser);
                    View.ShowSuccessView();
                }
                else
                {
                    View.ShowMessage("Error: Can't change password");
                }
            }
            else
            {
                View.ShowMessage("Old password is invalid");
            }

        }

        public void Return()
        {
            View.ReturnToMain();
        }

        public void Load()
        {
            if(!View.IsPostBack)
            {
                View.ShowStartView();
            }
        }
    }
}