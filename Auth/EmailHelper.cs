using System.Net.Mail;

namespace JWTRefreshToken.Auth
{
    public class EmailHelper
    {
        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("mjogi1306@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("mjogi1306@gmail.com", "zabg adru adfb qdcz");
            client.Host = "smtpout.secureserver.net";
            client.Port = 80;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
    }
}
