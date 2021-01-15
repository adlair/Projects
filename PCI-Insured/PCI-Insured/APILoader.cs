#define NON_SECURE_TEST

using CloudDataGateway;
using DataObjects;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

namespace PCIInsured
{

	public class APILoader
	{
#if NON_SECURE_TEST
		object[] tags;
#endif
		DataGatewayAccess dataGateway = new DataGatewayAccess();
		EnsuredXML document = new EnsuredXML();

		public APILoader()
		{
#if DEBUG
			document = dataGateway.GetEnsuredXML();
#endif
			MappingXMLToObject(document);
		}

		private void MappingXMLToObject(EnsuredXML document)
		{
			string responseData = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><tag><bar>test</bar></tag>";
			using (TextReader contain = new StringReader(responseData))
			{
				var deserializer = new XmlSerializer(typeof(List<DataSource>));
				DataSource response = (DataSource)deserializer.Deserialize(contain);
			}
		}

		private void DataAnalizer()
		{
#if DEBUG
			try
			{
				if (dataGateway.PRD(tags))
					if (dataGateway.UAT(tags))
						if (dataGateway.DEV(tags))
							CallAS400();
			}
			catch (Exception e)
			{
				//Log messages can be registered.
				using (EventLog eventLog = new EventLog("PCI-Insured"))
				{
					eventLog.Source = "PCI-Insured";
					eventLog.WriteEntry("Log: " + e.Source, EventLogEntryType.Information, 101, 1);
				}
			}
#endif
		}

		private void CallAS400()
		{
			//TODO
		}
	}
}
