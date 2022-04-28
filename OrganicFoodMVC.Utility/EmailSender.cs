using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OrganicFoodMVC.Utility
{
    public class EmailSender : IEmailSender
    {

        private readonly EmailOptions emailOptions;

        public EmailSender(IOptions<EmailOptions> options)
        {
            emailOptions = options.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            string serverMail = emailOptions.ServerMail, username = emailOptions.UsernameMail, pass = emailOptions.Password;
            int portMail = emailOptions.PortServerMail;

            SmtpClient mySmtpClient = new SmtpClient(serverMail, portMail);

            // set smtp-client with basicAuthentication
            mySmtpClient.UseDefaultCredentials = false;
            System.Net.NetworkCredential basicAuthenticationInfo = new
                System.Net.NetworkCredential(username, pass);
            mySmtpClient.Credentials = basicAuthenticationInfo;

            // add from,to mailaddresses
            MailAddress from = new MailAddress("developer.thuong@gmail.com", "Trọng Thưởng");
            MailAddress to = new MailAddress(email);
            MailMessage myMail = new MailMessage(from, to);

            // add ReplyTo
            MailAddress replyTo = new MailAddress("developer.thuong@gmail.com", "Trọng Thưởng");
            myMail.ReplyToList.Add(replyTo);

            // set subject and encoding
            myMail.Subject = subject;
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;

            // set body-message and encoding
            myMail.Body = htmlMessage;
            myMail.BodyEncoding = System.Text.Encoding.UTF8;
            // text or html
            myMail.IsBodyHtml = true;

            return mySmtpClient.SendMailAsync(myMail);
        }

    }
}
