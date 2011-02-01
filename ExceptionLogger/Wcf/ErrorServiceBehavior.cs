namespace Idmediaworks.ExceptionLogger.Wcf
{
	using System.Collections.ObjectModel;
	using System.ServiceModel;
	using System.ServiceModel.Channels;
	using System.ServiceModel.Description;
	using System.ServiceModel.Dispatcher;

	public class ErrorServiceBehavior : IServiceBehavior
	{
		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
		}

		public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
			var handler = new WcfErrorHandler();

			foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
				dispatcher.ErrorHandlers.Add(handler);
		}
	}
}