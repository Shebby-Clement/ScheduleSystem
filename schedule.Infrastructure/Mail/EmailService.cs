using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using schedule.Application.Contracts;
using schedule.Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }
        public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = mailSettings.Value;
            _logger = logger;
        }
        public async Task<bool> SendEmail(Email emailModel)
        {
            try
            {

                var message = new MailMessage();

                string[] multipleRec = emailModel.To.ToArray();

                foreach (var item in multipleRec)
                {
                    message.To.Add(new MailAddress(item));
                }

                if (emailModel.Attachment?.Length > 0)
                {
                    string fileName = Path.GetFileName(emailModel.Attachment.FileName);
                    message.Attachments.Add(new Attachment(emailModel.Attachment.OpenReadStream(), fileName));
                }

                message.Priority = MailPriority.High;
                message.From = new MailAddress(_emailSettings.AdminUser);
                message.Subject = emailModel.Subject;
                message.IsBodyHtml = true;
                message.Body = emailModel.Body;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = _emailSettings.AdminUser,
                        Password = _emailSettings.AdminPassword
                    };

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Host = _emailSettings.SMTPName;
                    smtp.Port = _emailSettings.SMTPPort;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                    _logger.LogInformation($"Email sent sucessfully");

                    return true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occured sending email. Error: {e.Message}");

                return false;
            }

        }
    }
}
