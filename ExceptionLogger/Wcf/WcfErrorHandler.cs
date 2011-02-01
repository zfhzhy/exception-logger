namespace Idmediaworks.ExceptionLogger.Wcf
{
	using System;
	using System.ServiceModel.Channels;
	using System.ServiceModel.Dispatcher;

	public class WcfErrorHandler : IErrorHandler
	{
		public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
		{
		}

		public bool HandleError(Exception exception)
		{
			// get the inner exception if there is one 
			exception = exception.InnerException ?? exception;

			// get details for top exception
			var details = new ExceptionDetails(exception, System.ServiceModel.OperationContext.Current);

			Logger.Log(details);

			return false;
		}
	}
}
