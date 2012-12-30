using System.Web;
using EpamAspProject.Model;

namespace EpamAspProject.Views
{
    /// <summary>
    /// Summary description for Image
    /// </summary>
    public class Image : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                var record = Records.GetRecordByID(id);
                if (record != null)
                {
                    if (record.Image != "")
                    {
                        context.Response.WriteFile(record.Image);
                    }
                    else
                    {
                        context.Response.WriteFile(@"~/Images/NoImage.png");
                    }
                }
                else
                {
                    context.Response.WriteFile(@"~/Images/NoFile.png");
                }
            }
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