namespace Idmediaworks.ExceptionLogger
{
	using System.Configuration;
	using System.Xml;

	public class ConfigurationHandler : IConfigurationSectionHandler
	{
		public object Create(object parent, object context, XmlNode node)
		{
			var config = new Configuration();
			config.LoadValues(node);
			return config;
		}
	}
}
