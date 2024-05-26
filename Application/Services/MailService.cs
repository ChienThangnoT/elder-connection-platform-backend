using Application.Helper;
using Application.IServices;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MailService(IOptions<EmailConfig> emailConfig) : IMailService
    {
        readonly EmailConfig _emailConfig = emailConfig.Value;

        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailConfig.Mail);
            email.To.Add(MailboxAddress.Parse(emailRequest.To));
            email.Subject = emailRequest.Subject;
            var builder = new BodyBuilder();

            //Attachment
            if (emailRequest.AttachmentFilePaths != null)
            {
                byte[] fileBytes;
                foreach (var file in emailRequest.AttachmentFilePaths)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            //Body
            builder.HtmlBody = emailRequest.Content;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_emailConfig.Host, _emailConfig.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailConfig.Mail, _emailConfig.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
        public async Task SendConFirmEmailAsync(EmailRequest emailRequest)
        {
            string MailText = emailRequest.Content;
            MailText = MailText.Replace("[ConfirmLink]", emailRequest.Content);

            //Setup email
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailConfig.Mail);
            email.To.Add(MailboxAddress.Parse(emailRequest.To));
            email.Subject = emailRequest.Subject;
            var builder = new BodyBuilder();

            //Body contain the confirm link
            builder.HtmlBody = MailText; //Using Html file edited instead of request.body
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_emailConfig.Host, _emailConfig.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailConfig.Mail, _emailConfig.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
    }
}