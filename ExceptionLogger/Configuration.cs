namespace Idmediaworks.ExceptionLogger
{
	using System;
	using System.Configuration;
	using System.Xml;

	public class Configuration
	{
		/// <summary>
		/// Create an instance of Handler loading the configuration
		/// </summary>
		public static Configuration GetConfig()
		{
			try
			{
				return (Configuration)ConfigurationManager.GetSection("idmediaworks/exceptionLogger");
			}
			catch (Exception ex)
			{
				throw new ConfigurationErrorsException("Could not load configuration for idmediaworks/exceptionLogger!", ex);
			}
		}

		public void LoadValues(XmlNode node)
		{
			var mailNode = node.SelectSingleNode("mail");

			// Set properties
			MailTo = mailNode.Attributes["to"].Value.ToLower();
		}

		/// <summary>
		/// Default connection string name for framework DB
		/// </summary>
		public string MailTo { get; private set; }
	}
}
