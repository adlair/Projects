#define NON_SECURE_TEST

using System.Xml;
using System.Text;
using DataObjects;

namespace CloudDataGateway
{
	public class DataGatewayAccess
    {
        //Processing step 1.
        public EnsuredXML GetEnsuredXML()
        {
#if NON_SECURE_TEST
            // Create a new XmlDocument object.
            EnsuredXML document = new EnsuredXML();
            XmlNode node = document.CreateNode(XmlNodeType.Element, "", "Element", "sample");
            node.InnerText = "Example text to be signed.";
            document.AppendChild(node);
            XmlTextWriter xmltw = new XmlTextWriter("XML_Sampler", new UTF8Encoding(false));
            document.WriteTo(xmltw);
            xmltw.Close();
#else
            EnsuredXML document = new EnsuredXML();
            document.Load(ConfigurationManager.AppSettings.Get("XML"));
#endif
            return document;
        }

        public bool PRD (params object[] ps)
		{
#if NON_SECURE_TEST
            return true;
#else
            NetworkCredential credential = new NetworkCredential();
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

            //Assign address
            var address = new EndpointAddress(ConfigurationManager.AppSettings.Get("PRD"));

            //Create service client
            string WSHttpBindingName = "Binding";
            ServiceEndpoint specialServiceEndpoint = new ServiceEndpoint(
                ContractDescription.GetContract(typeof(DataContractFormatAttribute)), new WSHttpBinding(WSHttpBinding), address
                );
#endif
        }

        public bool UAT(params object[] ps)
        {
#if NON_SECURE_TEST
            return true;
#else
            NetworkCredential credential = new NetworkCredential();
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

            //Assign address
            var address = new EndpointAddress(ConfigurationManager.AppSettings.Get("UAT"));

            //Create service client
            string WSHttpBindingName = "Binding";
            ServiceEndpoint specialServiceEndpoint = new ServiceEndpoint(
                ContractDescription.GetContract(typeof(DataContractFormatAttribute)), new WSHttpBinding(WSHttpBinding), address
                );
#endif
        }

        public bool DEV(params object[] ps)
        {
#if NON_SECURE_TEST
            return true;
#else
            NetworkCredential credential = new NetworkCredential();
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

            //Assign address
            var address = new EndpointAddress(ConfigurationManager.AppSettings.Get("DEV"));

            //Create service client
            string WSHttpBindingName = "Binding";
            ServiceEndpoint specialServiceEndpoint = new ServiceEndpoint(
                ContractDescription.GetContract(typeof(DataContractFormatAttribute)), new WSHttpBinding(WSHttpBinding), address
                );
#endif
        }
    }
}
