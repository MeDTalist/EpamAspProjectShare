using System.Collections.Generic;
using System.Text;
using EpamAspProject.Model;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Presenters
{
    public class DefaultPresenter : BasePresenter<IDefault>
    {
        public void Load()
        {
            //Куча багов, нужен рефакторинг и хорошая продуманность логики
            var login = View.GetLogin();
            if (login != null)
            {
                if (Users.IsCorrectLogin(login))
                {
                    View.ShowUserButtons();
                    View.SetSelectInGV();
                }
                else
                {
                    View.UnSetSelectInGV();
                    View.HideUserButtons();
                }
                if (Users.IsAdminUser(login))
                {
                    View.ShowAdminButtons();
                }
                else
                {
                    View.HideAdminButtons();
                }
            }
            View.ShowMessage("");
            View.HideDel();
            if (!View.IsPostBack)
            {
                View.FillFilter();
                DisplayLibr();
            }
        }

        private void DisplayLibr()
        {
            var display = new List<Record>();
            int page;
            var spage = View.GetFromUrl("Page");
            if(string.IsNullOrEmpty(spage))
            {
                page = 0;
            }
            else
            {
                if(int.TryParse(spage,out page))
                {
                    --page;
                }
                else
                {
                    View.RedirectTo(View.GetPagePath());
                }
            }
            var find = View.GetFromUrl("Find");
            if (find == "yes")
            {
                int findBy;
                switch (View.GetFromUrl("FindBy"))
                {
                    case "Name":
                        findBy = 0;
                        break;
                    case "Author":
                        findBy = 1;
                        break;
                    case "Year":
                        findBy = 2;
                        break;
                    case "Type":
                        findBy = 3;
                        break;
                    case "Format":
                        findBy = 4;
                        break;
                    default:
                        View.RedirectTo(View.GetPagePath());
                        return;
                }
                var contains = View.GetFromUrl("Contains");
                if(!string.IsNullOrEmpty(contains))
                {
                    display = Records.GetFindedLibr(findBy,contains);
                }
                else
                {
                    View.RedirectTo(View.GetPagePath());
                }
            }
            else
            {
                display = Records.GetAllLibr();
            }
            View.DisplayLibr(display,page);
        }

        public void PageIndexChange(int newPageIndex)
        {
            ++newPageIndex;
            var url = new StringBuilder();
            url.Append(View.GetPagePath());
            var find = View.GetFromUrl("Find");
            if(find=="yes")
            {
                url.Append("?Find=yes");
                url.Append("&FindBy=");
                url.Append(View.GetFromUrl("FindBy"));
                url.Append("&Contains=");
                url.Append(View.GetFromUrl("Contains"));
                url.Append("&Page=");
                url.Append(newPageIndex.ToString());
            }
            else
            {
                url.Append("?Page=");
                url.Append(newPageIndex.ToString());
            }
            View.RedirectTo(url.ToString());
        }

        /*public void SelectedIndexChanged(int newSelectedIndex)
        {
            View.SetSelectedIndex(newSelectedIndex);
        }*/

        internal void Add()
        {
            View.RedirectToAdd();
        }

        public void ViewClick()
        {
            var login = View.GetLogin();
            if (!Users.IsCorrectLogin(login))
            {
                View.ShowMessage("Only rgistered user can view file");
                return;
            }
            var i = View.GetSelectedIndex();
            if (i == -1)
            {
                View.ShowMessage("No element to download select");
                return;
            }
            string page = "~/Views/Pages/ViewRecord.aspx/?id=";
            var id = View.GetSelectedID();
            page += id;
            View.RedirectTo(page); 
        }

        public void Download()
        {
            var i =  View.GetSelectedIndex();
            if(i == -1)
            {
                View.ShowMessage("No element to download select");
                return;
            }
            string page = "~/Views/Download.ashx/?id=";
            var id = View.GetSelectedID();
            page += id;
            View.RedirectTo(page);
        }

        public void Delete()
        {
            if (View.GetSelectedIndex() != -1)
            {
                View.DisplayDel();
            }
            else
            {
                View.ShowMessage("No selected item to delete");
            }
        }

        public void Yes()
        {
            var login = View.GetLogin();
            if(!Users.IsAdminUser(login))
            {
                View.ShowMessage("Only admin user can delete file");
                return;
            }
            var id = View.GetSelectedID();
            Records.DeleteRecord(id);
            View.RefrashPage();
        }
        public void Find()
        {


            var url = new StringBuilder();
            url.Append(View.GetPagePath());
            url.Append("?Find=yes");
            url.Append("&FindBy=");
            url.Append(View.GetFind());
            url.Append("&Contains=");
            url.Append(View.Conains);
            View.RedirectTo(url.ToString());


        }

        public void ShowAll()
        {
            View.RedirectTo(View.GetPagePath());
        }
    }
}