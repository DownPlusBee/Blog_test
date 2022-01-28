using Blog.Application.Interfaces.Infrastructure;
using Blog.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }

        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _emailSettings = mailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            SendGridClient client = new("");

            string subject = email.Subject;
            EmailAddress to = new(email.To);
            string emailBody = email.Body;

            EmailAddress from = new()
            {
                Email = "testemail98234@gmail.com",
                Name = "Test"
            };

            SendGridMessage sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            Response response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}
