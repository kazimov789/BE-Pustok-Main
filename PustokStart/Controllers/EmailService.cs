	using MailKit.Net.Smtp;
	using MailKit.Security;
	using Microsoft.Extensions.Options;
	using MimeKit;
	using MimeKit.Text;
namespace PustokStart.Controllers
{

	public interface IEmailService
	{
		void Send(string to, string subject, string html, string from = null);
	}

	internal class  EmailService 
	{
		private readonly AppSettings _appSettings;

		public EmailService(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		 Send("rhdkazimov@gmail.com", "rhdkazimov@gmail.com", "rhdkazimov@gmail.com");
		}

		public void Send(string to, string subject, string html, string from = null)
		{
			// create message
			var email = new MimeMessage();
			email.From.Add(MailboxAddress.Parse(from ?? _appSettings.EmailFrom));
			email.To.Add(MailboxAddress.Parse(to));
			email.Subject = subject;
			email.Body = new TextPart(TextFormat.Html) { Text = html };

			// send email
			using var smtp = new SmtpClient();
			smtp.Connect(_appSettings.SmtpHost.ToString(),Convert.ToInt32(_appSettings.SmtpPort), SecureSocketOptions.StartTls);
			//smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
			smtp.Send(email);
			smtp.Disconnect(true);
		}


	}

}