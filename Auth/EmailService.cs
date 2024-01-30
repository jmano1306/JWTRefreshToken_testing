using MimeKit;
//using System.Net.Mail;
using MailKit.Net.Smtp;
using User.Management.Service.Model;
//using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace JWTRefreshToken.Auth
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void sendMail(EmailModel emailModel)
        {
            var emailMessage = new MimeMessage();
            var from = _config["EmailSettings:From"];
            emailMessage.From.Add(new MailboxAddress("Lets Program", from));
            emailMessage.To.Add(new MailboxAddress(emailModel.To, emailModel.To));
            emailMessage.Subject = emailModel.Subject;
            
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text=emailModel.Content.ToString()
                //Text = string.Format("model",emailModel.Content)
            };
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_config["EmailSettings:SmtpServer"], 465, true);
                    client.Authenticate(_config["EmailSettings:From"], _config["EmailSettings:Password"]);
                    client.Send(emailMessage);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }

            }
        }
    }
}
