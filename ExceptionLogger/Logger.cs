namespace Idmediaworks.ExceptionLogger
{
	using System;
	using System.Linq;
	using System.Net.Mail;
	using System.Reflection;

	public static class Logger
	{
		public static void Log(ExceptionDetails details)
		{
			var config = Configuration.GetConfig();

			using (var message = new MailMessage())
			{
				var subject = details.Message.Replace(Environment.NewLine, " ");

				message.From = new MailAddress(string.Format("{0}@{1}", details.MachineName, details.Hostname).ToLower());
				message.To.Add(config.MailTo);
				message.Subject = subject;
				message.Body = formatBody(details);
				message.IsBodyHtml = true;

				new SmtpClient().Send(message);
			}
		}

		private static string formatBody(ExceptionDetails details)
		{
			var body = "<style>dt, dd { font-family: Arial; font-size: 11px; } dd{ margin-bottom: 15px; }</style><dl>";

			foreach (var property in details.GetType().GetMembers().Where(x => x.MemberType == MemberTypes.Property))
			{
				var value = details.GetType().GetProperty(property.Name).GetValue(details, null);

				if (null != value && value.ToString().Length > 0)
				{
					body = string.Concat(body, "<dt><strong>", property.Name, "</strong></dt>");
					body = string.Concat(body, "<dd>", value, "</dd>");
				}
			}

			return string.Concat(body, "</dl>");
		}
	}
}
