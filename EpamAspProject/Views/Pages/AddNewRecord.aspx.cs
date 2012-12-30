using System;
using System.Globalization;
using System.IO;
using System.Web;
using EpamAspProject.Presenters;
using EpamAspProject.Presenters.Interfaces.View;
using EpamAspProject.Types;

namespace EpamAspProject.Views.Pages
{
    public partial class AddNewRecord : BasePage<AddNewRecordPresenter,IAddNewRecord>, IAddNewRecord
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.Load();
        }

        protected void BtnSelectClick(object sender, EventArgs e)
        {
            Presenter.Select();
        }

        protected void BtnCancelClick(object sender, EventArgs e)
        {
            Presenter.Cancel();
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

        public void RedirectToMain()
        {
            Response.Redirect("~/Views/Pages/Default.aspx");
        }

        public void ShowMainView()
        {
            MVNewRecord.SetActiveView(VChooseType);
        }

        bool IAddNewRecord.IsPostBack
        {
            get{return IsPostBack;}
        }

        public int SelectedType
        {
            get
            {
                if(RBMovie.Checked)
                {
                    return 1;
                }
                if(RBMusic.Checked)
                {
                    return 2;
                }
                if (RBBook.Checked)
                {
                    return 3;
                }
                throw new ApplicationException();
            }
        }

        public bool HasImage
        {
            get { return FUImage.HasFile; }
        }

        public string Author
        {
            get { return TxtAuthor.Text; }
            set { TxtAuthor.Text = value; }
        }

        public string Name
        {
            get { return TxtName.Text; }
            set { TxtName.Text = value; }
        }

        public int Year
        {
            get { return int.Parse(TxtYear.Text); }
            set { TxtYear.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public string Album
        {
            get { return TxtAlbum.Text; }
            set { TxtAlbum.Text = value; }
        }

        public int Bitrate
        {
            get
            {
                if (TxtBitRate.Text==string.Empty)
                {
                    return 0;
                }
                return int.Parse(TxtBitRate.Text);
            }
            set { TxtBitRate.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public string PlayTime2
        {
            get { return TxtPlayTime2.Text; }
            set { TxtPlayTime2.Text = value; }
        }

        public string Style
        {
            get { return TxtStyle.Text; }
            set { TxtStyle.Text = value; }
        }

        public string Genre
        {
            get { return TxtGenre.Text; }
            set {TxtGenre.Text = value; }
        }

        public string PlayTime
        {
            get { return TxtPlayTime.Text; }
            set { TxtPlayTime.Text = value; }
        }

        public string Quality
        {
            get { return TxtQuality.Text; }
            set { TxtQuality.Text = value; }
        }

        public int Pages
        {
            get 
            { 
                if(TxtPages.Text == "")
                {
                    return 0;
                }
                return int.Parse(TxtPages.Text);
            }
            set { TxtPages.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public string PublishingHouse
        {
            get { return TxtPublishingHouse.Text; }
            set { TxtPublishingHouse.Text = value; }
        }

        public void ShowMovieView()
        {
            MVTypeRecord.SetActiveView(VMovie);
        }

        public void ShowMusicView()
        {
            MVTypeRecord.SetActiveView(VMusic);
        }

        public void ShowBookView()
        {
            MVTypeRecord.SetActiveView(VBook);
        }

        public void ShowAddView()
        {
            MVNewRecord.SetActiveView(VAdd);
        }

        public string SaveImageTo(string savePath)
        {
            string fileName = Server.HtmlEncode(FUImage.FileName);
            savePath += fileName;
            FUImage.SaveAs(savePath);
            return savePath;
        }

        public void AddTypeToViewState(string type)
        {
            ViewState.Add("Type", type);
        }

        public bool HasFile()
        {
            return FUAddNew.HasFile;
        }

        public void ShowMessage(string message)
        {
            LblMessage.Text = message;
        }

        public string GetFileName()
        {
            return Server.HtmlEncode(FUAddNew.FileName);
        }

        public string GetTypeFromViewState()
        {
            return (string) ViewState["Type"];
        }

        public int GetFileSize()
        {
            return FUAddNew.PostedFile.ContentLength;
        }

        public string GetImageName()
        {
            return Server.HtmlEncode(FUImage.FileName);
        }

        public int GetImageSize()
        {
            return FUImage.PostedFile.ContentLength;
        }

        public string SaveFileTo(string savePath)
        {
            string fileName = Server.HtmlEncode(FUAddNew.FileName);
            if (!(Directory.Exists(savePath)))
            {
                Directory.CreateDirectory(savePath);
            }
            var saveFile = savePath + fileName;
            FUAddNew.SaveAs(saveFile);
            return saveFile;
        }

        public void ShowSuccessView()
        {
            MVNewRecord.SetActiveView(VSuccess);
        }

        protected void BtnAddClick(object sender, EventArgs e)
        {
            Presenter.Add();
        }

        protected void ReturnToMainClick(object sender, EventArgs e)
        {
            Presenter.ReturnToMain();
        }
    }
}