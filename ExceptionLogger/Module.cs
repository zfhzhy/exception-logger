namespace Idmediaworks.ExceptionLogger
{
	using System;
	using System.Web;

	public class Module : IHttpModule
	{
		private HttpApplication _application;

		public void Init(HttpApplication application)
		{
			_application = application;
			_application.Error += applicationError;
		}

		private void applicationError(object sender, EventArgs e)
		{
			// get exception details
			var exception = _application.Server.GetLastError();

			// get the inner exception if there is one 
			exception = exception.InnerException ?? exception;

			// get details for top exception
			var details = new ExceptionDetails(exception, _application);

			Logger.Log(details);
		}

		public void Dispose()
		{
		}
	}
}
