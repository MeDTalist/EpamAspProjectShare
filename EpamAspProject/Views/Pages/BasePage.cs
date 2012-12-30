using EpamAspProject.Presenters;

namespace EpamAspProject.Views.Pages
{
    public class BasePage<T, V> : System.Web.UI.Page
        where T : BasePresenter<V>, new()
        where V : class
    {
        private T _presenter;

        protected T Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new T { View = this as V };
                }
                return _presenter;
            }
        }
    }
}