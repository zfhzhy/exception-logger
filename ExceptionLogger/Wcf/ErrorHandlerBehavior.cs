namespace Idmediaworks.ExceptionLogger.Wcf
{
	using System;
	using System.ServiceModel.Configuration;

	public class ErrorHandlerBehavior : BehaviorExtensionElement
	{
		protected override object CreateBehavior()
		{
			return new ErrorServiceBehavior();
		}

		public override Type BehaviorType
		{
			get { return typeof(ErrorServiceBehavior); }
		}
	}
}