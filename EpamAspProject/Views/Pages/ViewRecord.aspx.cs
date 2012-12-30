using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EpamAspProject.Presenters;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Views.Pages
{
    public partial class ViewRecord : BasePage<ViewRecordPresenter, IViewRecord>,IViewRecord
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Load();
        }

        public User GetLoginFromCookie()
        {
            HttpCookie userInfoCookies = Request.Cookies["UserInfo"];
            if (userInfoCookies == null)
            {
                return null;
            }
            var result = new User { Login = userInfoCookies["UserName"], Password = userInfoCookies["UserPassword"] };
            return result;
        }

        public void RedirectTo(string page)
        {
            Response.Redirect(page);
        }

        public string GetFromUrl(string geted)
        {
            return Request.QueryString[geted];
        }

        public void DisplayImage(int id)
        {
            ImgImage.Src = "~/Views/Image.ashx?id=" + id.ToString();
        }

        //Так проще
        public void SetInLabelValue(string label, string value)
        {
            //Так как FindControl почему то не работает
            //ищем контрол вручную
            var labelControl =  FindControlRecursive(Page, label) as Label;
            if (labelControl != null)
            {
                labelControl.Text = value;
            }
        }

        public void ShowMovieView()
        {
            MVType.SetActiveView(VMovie);
        }

        public void ShowBookView()
        {
            MVType.SetActiveView(VBook);
        }

        public void ShowMusicView()
        {
            MVType.SetActiveView(VMusic);
        }

        public static Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }

            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }

            return null;
        }

        protected void BtnReturnClick(object sender, EventArgs e)
        {
            Presenter.Return();
        }

        protected void BtnDownloadClick(object sender, EventArgs e)
        {
            Presenter.Download();
        }
    }
}