using System;
using System.IO;
using System.Web;
using EpamAspProject.Model;
using EpamAspProject.Types;

namespace EpamAspProject.Views
{
    /// <summary>
    /// Summary description for Download
    /// </summary>
    public class Download : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpCookie userInfoCookies = context.Request.Cookies["UserInfo"];
            if (userInfoCookies == null)
            {
                context.Response.Redirect("~/Views/Pages/Default.aspx");
                return;
            }
            var login = new User {Login = userInfoCookies["UserName"], Password = userInfoCookies["UserPassword"]};
            if (!Users.IsCorrectLogin(login))
            {
                context.Response.Redirect("~/Views/Pages/Default.aspx");
            }
            int id;
            if (int.TryParse(context.Request.QueryString["id"],out id))
            {
                var record = Records.GetRecordByID(id);
                if (record != null)
                {

                    var file = new FileInfo(record.FileWay);
                    if (file.Exists)
                    {
                        context.Response.Clear();
                        context.Response.ClearHeaders();
                        context.Response.ClearContent();
                        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                        context.Response.AddHeader("Content-Length", file.Length.ToString());
                        context.Response.Flush();
                        context.Response.TransmitFile(file.FullName);
                        context.Response.End();
                    }
                    else
                    {
                        context.Response.ContentType = "image";
                        context.Response.WriteFile(@"~/Images/NoFile.png");
                    }
                }
                else
                {
                    context.Response.ContentType = "image";
                    context.Response.WriteFile(@"~/Images/NoFile.png");
                }
            }
            context.Response.ContentType = "image";
            context.Response.WriteFile(@"~/Images/NoFile.png");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}