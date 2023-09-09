namespace Email.Models
{
    public class SettingEmailSender
	{
		public string SMTPHost { get; set; } = "smtp.gmail.com";
        public int SMTPHostPort { get; set; } = 587;
		public required string EmailSender { get; set; }
        public required string EmailPassword{ get; set; }
		public string EmailSenderName { get; set; } = string.Empty;
    }
}

