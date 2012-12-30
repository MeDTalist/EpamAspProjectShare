using System.Collections.Generic;
using EpamAspProject.Types;

namespace EpamAspProject.Presenters.Interfaces.View
{
    public interface IDefault
    {
        bool IsPostBack { get; }
        string Conains { get; set; }

        void SetSelectInGV();
        void DisplayLibr(List<Record> librs, int page = 0, int selectedIndex = -1);
        void SetSelectedIndex(int newSelectedIndex);
        void FillFilter();
        User GetLogin();
        void ShowUserButtons();
        void ShowAdminButtons();
        void HideUserButtons();
        void HideAdminButtons();
        void UnSetSelectInGV();
        void RedirectToAdd();
        void RedirectToView();
        int GetSelectedIndex();
        void ShowMessage(string message);
        int GetSelectedID();
        void RedirectTo(string page);
        void DisplayDel();
        void HideDel();
        void RefrashPage();
        string GetPagePath();
        string GetFind();
        string GetFromUrl(string geted);
    }
}