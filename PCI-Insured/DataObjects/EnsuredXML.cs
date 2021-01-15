using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace DataObjects
{
	public class EnsuredXML : XmlDocument
	{
		//Creating an ensure XML Document
		public void Overhaul()
		{
			try
			{
				//Adding a signature to the Document.
				RSA key = RSA.Create();
				this.PreserveWhitespace = false;
				SignedXml signedXml = new SignedXml(this);
				signedXml.SigningKey = key;
				Reference reference = new Reference();
				XmlDsigBase64Transform xmlDsigBase64 = new XmlDsigBase64Transform();
				reference.AddTransform(xmlDsigBase64);
				KeyInfo keyInfo = new KeyInfo();
				keyInfo.AddClause(new RSAKeyValue((RSA)key));
				signedXml.KeyInfo = keyInfo;
				signedXml.ComputeSignature();
				XmlElement xmlElement = signedXml.GetXml();
				this.DocumentElement.AppendChild(this.ImportNode(xmlElement, true));

				if(this.FirstChild is XmlDeclaration)
				{
					this.RemoveChild(this.FirstChild);
				}
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
		}

		//Verify if the Document have a valid Signature.
		public Boolean EnsureScheme(RSA key)
		{
			this.PreserveWhitespace = true;
			SignedXml signedXml = new SignedXml(this);
			XmlNodeList xmlNodeList = this.GetElementsByTagName("Signature");
			signedXml.LoadXml((XmlElement)xmlNodeList[0]);
			return signedXml.CheckSignature();
		}
	}
}
