using MailKit.Net.Smtp;
using MimeKit;
using SocialNetwork.Core.Application.DTOS.Email;
using SocialNetwork.Core.Application.Interface.Services;
using SocialNetwork.Core.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructured.Shared.Services
{
    public class EmailService : IEmailServices
    {
        private MailSettings mailSettings { get; }
        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            try
            {
                MimeMessage email = new();
                email.Sender = MailboxAddress.Parse(mailSettings.DisplayName + " <"+mailSettings.EmailFrom+" >");
                email.To.Add(MailboxAddress.Parse(emailRequest.To));
                email.Subject = emailRequest.Subject;
                BodyBuilder bodyBuilder = new();
                bodyBuilder.HtmlBody = emailRequest.Body;
                email.Body = bodyBuilder.ToMessageBody();
                using SmtpClient smtpClient = new();
                smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtpClient.Connect(mailSettings.SmtpHost, mailSettings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                smtpClient.Authenticate(mailSettings.SmtpUser, mailSettings.SmtpPass);
                await smtpClient.SendAsync(email);
                smtpClient.Disconnect(true);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
