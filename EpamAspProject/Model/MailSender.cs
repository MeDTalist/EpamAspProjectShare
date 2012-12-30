using System.Globalization;
using System.Net.Mail;
using System.Text;
using EpamAspProject.Types;

namespace EpamAspProject.Model
{
    public class MailSender
    {

        public static void SendSecretKey(string eMail, int secretKey)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(eMail);
            mailMessage.Subject = "Secret Key";
            var message = new StringBuilder();
            message.Append("Your secret key ");
            message.Append(secretKey.ToString(CultureInfo.InvariantCulture));
            mailMessage.Body = message.ToString();
            var smptClient = new SmtpClient();
            smptClient.Send(mailMessage);
        }

        public static void SendNewPass(RichUser user)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(user.EMail);
            mailMessage.Subject = "Reset password";
            var message = new StringBuilder();
            message.Append("Hello, ");
            message.Append(user.Login);
            message.Append(". Your new password is \"");
            message.Append(user.Password);
            message.Append("\"");
            mailMessage.Body = message.ToString();
            var smptClient = new SmtpClient();
            smptClient.Send(mailMessage);
        }
    }
}