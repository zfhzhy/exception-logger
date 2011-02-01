namespace Idmediaworks.ExceptionLogger
{
	using System;
	using System.Net;
	using System.ServiceModel;
	using System.Web;

	public sealed class ExceptionDetails
	{
		public ExceptionDetails(Exception exception, OperationContext application)
		{
			Hostname = application.Channel.LocalAddress.Uri.Host;
			MachineName = Dns.GetHostName();
			Url = application.Channel.LocalAddress.Uri.ToString();

			Time = DateTime.Now;
			Message = exception.Message;
			StackTrace = exception.StackTrace;
		}

		public ExceptionDetails(Exception exception, HttpApplication application)
		{
			Url = application.Request.Url.ToString();
			UrlReferer = null != application.Request.UrlReferrer ? application.Request.UrlReferrer.ToString() : string.Empty;
			Hostname = application.Request.Url.Host;

			if (application.User.Identity.IsAuthenticated)
			{
				AuthenticationType = application.User.Identity.AuthenticationType;
				AuthenticatedUsername = application.User.Identity.Name;
			}

			MachineName = application.Server.MachineName;

			Time = DateTime.Now;
			Message = exception.Message;
			StackTrace = exception.StackTrace;
		}

		public string Url { get; set; }
		public string UrlReferer { get; set; }
		public string Hostname { get; set; }
		public string AuthenticationType { get; set; }
		public string AuthenticatedUsername { get; set; }
		public string MachineName { get; set; }
		public DateTime Time { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }
	}
}