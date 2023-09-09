using Email.Models;
using Email.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace Email.Services
{
    public class EmailSender : IEmailSender
    {

        public async Task SendEmailAsync(SettingEmailSender setting, EmailSenderDto request, CancellationToken cancellationToken = default)
        {
            using MimeMessage email = new();
            email.From.Add(new MailboxAddress(setting.EmailSenderName, setting.EmailSender));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using SmtpClient smtp = new();
            await smtp.ConnectAsync(setting.SMTPHost, setting.SMTPHostPort, SecureSocketOptions.StartTls,cancellationToken);
            await smtp.AuthenticateAsync(setting.EmailSender, setting.EmailPassword,cancellationToken);
            await smtp.SendAsync(email,cancellationToken);
            await smtp.DisconnectAsync(true,cancellationToken);
        }
    }
}

