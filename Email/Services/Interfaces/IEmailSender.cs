using Email.Models;

namespace Email.Services.Interfaces
{
    public interface IEmailSender
	{
		Task SendEmailAsync(SettingEmailSender setting, EmailSenderDto request, CancellationToken cancellationToken = default);
	}
}

