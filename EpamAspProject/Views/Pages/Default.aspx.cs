using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using EpamAspProject.Presenters;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Views.Pages
{
    public partial class Default : BasePage<DefaultPresenter, IDefault>, IDefault
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Load();
        }

        public void SetSelectInGV()
        {
            GVLibrary.AutoGenerateSelectButton = true;
        }

        public void DisplayLibr( List<Record> librs, int page = 0, int selectedIndex = -1)
        {
            if (librs.Count != 0)
            {
                GVLibrary.DataSource = librs;
                GVLibrary.PageIndex = page;
                GVLibrary.SelectedIndex = selectedIndex;
                GVLibrary.DataBind();
            }
            else
            {
                ShowMessage("No records");
            }
        }

        public void SetSelectedIndex(int newSelectedIndex)
        {
            GVLibrary.SelectedIndex = newSelectedIndex;
        }

        bool IDefault.IsPostBack
        {
            get { return IsPostBack; }
        }

        public string Conains
        {
            get { return TxtContains.Text; }
            set { TxtContains.Text = value; }
        }

        public void FillFilter()
        {
            DDLFiterFor.DataSource = CreateDataSourse();
            DDLFiterFor.DataTextField = "FilterFor";
            DDLFiterFor.DataBind();
        }

        private object CreateDataSourse()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("FilterFor", typeof(string)));
            dt.Rows.Add(CreateRow("Name", dt));
            dt.Rows.Add(CreateRow("Author", dt));
            dt.Rows.Add(CreateRow("Year", dt));
            dt.Rows.Add(CreateRow("Type", dt));
            dt.Rows.Add(CreateRow("Format", dt));
            return dt;
        }

        private DataRow CreateRow(string field, DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr[0] = field;
            return dr;
        }

        protected void GVLibrarySelectedIndexChanged(object sender, GridViewSelectEventArgs e)
        {
            //Presenter.SelectedIndexChanged(e.NewSelectedIndex);
        }

        protected void GVLibraryPageIndexChange(object sender, GridViewPageEventArgs e)
        {
            Presenter.PageIndexChange(e.NewPageIndex);
        }

        protected void BTNViewClick(object sender, EventArgs e)
        {
            Presenter.ViewClick();
        }

        protected void DDLFiterFor_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        public void ShowUserButtons()
        {
            BtnDownload.Visible = true;
            BTNView.Visible = true;
        }

        public void ShowAdminButtons()
        {
            BTNAdd.Visible = true;
            BTNDelete.Visible = true;
        }

        public void HideUserButtons()
        {
            BtnDownload.Visible = false;
            BTNView.Visible = false;
        }

        public void HideAdminButtons()
        {
            BTNAdd.Visible = false;
            BTNDelete.Visible = false;
        }

        public void UnSetSelectInGV()
        {
            GVLibrary.AutoGenerateSelectButton = false;
        }

        public void RedirectToAdd()
        {
            Response.Redirect("~/Views/Pages/AddNewRecord.aspx");
        }

        public void RedirectToView()
        {
            Response.Redirect("~/Views/Pages/ViewRecord.aspx");
        }

        public int GetSelectedIndex()
        {
            return GVLibrary.SelectedIndex;
        }

        public void ShowMessage(string message)
        {
            LblMessage.Text = message;
        }

        public int GetSelectedID()
        {
            return int.Parse(GVLibrary.SelectedRow.Cells[1].Text);
        }

        public void RedirectTo(string page)
        {
            Response.Redirect(page);
        }

        public void DisplayDel()
        {
            LblQuastion.Visible = true;
            BtnYes.Visible = true;
            BtnNo.Visible = true;
        }

        public void HideDel()
        {
            LblQuastion.Visible = false;
            BtnYes.Visible = false;
            BtnNo.Visible = false;
        }

        public void RefrashPage()
        {
            Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
        }

        public string GetPagePath()
        {
            return HttpContext.Current.Request.Url.AbsolutePath;
        }

        public string GetFind()
        {
            return DDLFiterFor.SelectedItem.Value;
        }

        public string GetFromUrl(string geted)
        {
            return Request.QueryString[geted];
        }

        protected void BTNAdd_Click(object sender, EventArgs e)
        {
            Presenter.Add();
        }

        protected void DownloadClick(object sender, EventArgs e)
        {
            Presenter.Download();
        }

        protected void BTNDelete_Click(object sender, EventArgs e)
        {
            Presenter.Delete();
        }

        protected void BtnYesClick(object sender, EventArgs e)
        {
            Presenter.Yes();
        }

        protected void BTNFind_Click(object sender, EventArgs e)
        {
            Presenter.Find();
        }

        protected void BtnAllClick(object sender, EventArgs e)
        {
            Presenter.ShowAll();
        }
    }
}