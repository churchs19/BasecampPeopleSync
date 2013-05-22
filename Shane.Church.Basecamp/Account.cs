using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Shane.Church.Basecamp
{
//<account>
//  <id type="integer">1</id>
//  <name>Your Company</name>
//  <account-holder-id type="integer">1</account-holder-id>
//  <primary-company-id type="integer">1</primary-company-id>
//  <ssl-enabled type="boolean">true</ssl-enabled>
//  <email-notification-enabled type="boolean">true</email-notification-enabled>
//  <time-tracking-enabled type="boolean">true</time-tracking-enabled>
//  <updated-at type="datetime">2009-10-09T17:52:46Z</updated-atcription>
//  <subscription>
//    <name>Premium</name>
//    <writeboards type="float">Infinity</writeboards>
//    <projects type="integer">100</projects>
//    <storage type="integer">32212254720</storage>
//    <ssl type="boolean">true</ssl>
//    <time-tracking type="boolean">true</time-tracking>
//  </subscription>
//  <default-attachment-categories>
//    <category>Documents</category>
//    <category>Pictures</category>
//    <category>Sounds</category>
//  </default-attachment-categories>
//  <default-post-categories>
//    <category>Design</category>
//    <category>Code</category>
//    <category>Copywriting</category>
//    <category>Transcripts</category>
//    <category>Assets</category>
//    <category>Miscellaneous</category>
//  </default-post-categories>
//</account>
	public class Account: Base
	{
		public Account(string BasecampUrl, string APIKey): 
			base(BasecampUrl, APIKey)
		{
			string xml = ExecuteWebRequest(MainBasecampURI + "account.xml");

			XElement item = XElement.Parse(xml);

			Id = int.Parse(item.Element("id").Value);
			Name = item.Element("name").Value;
			AccountHolderId = int.Parse(item.Element("account-holder-id").Value);
			PrimaryCompanyId = int.Parse(item.Element("primary-company-id").Value);
			SslEnabled = bool.Parse(item.Element("ssl-enabled").Value);
			EmailNotificationEnabled = bool.Parse(item.Element("email-notification-enabled").Value);
			TimeTrackingEnabled = bool.Parse(item.Element("time-tracking-enabled").Value);
			UpdatedAt = DateTime.Parse(item.Element("updated-at").Value);
			Subscription = new Subscription(item.Element("subscription"));

			DefaultAttachmentCategories = new List<string>();
			XElement attachmentCategories = item.Element("default-attachment-categories");
			if (attachmentCategories != null)
			{
				foreach (XElement element in attachmentCategories.Elements("category"))
				{
					DefaultAttachmentCategories.Add(element.Value);
				}
			}

			DefaultPostCategories = new List<string>();
			XElement postCategories = item.Element("default-post-categories");
			if (postCategories != null)
			{
				foreach (XElement element in postCategories.Elements("category"))
				{
					DefaultPostCategories.Add(element.Value);
				}
			}
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public int AccountHolderId { get; set; }
		public int PrimaryCompanyId { get; set; }
		public bool SslEnabled { get; set; }
		public bool EmailNotificationEnabled { get; set; }
		public bool TimeTrackingEnabled { get; set; }
		public DateTime UpdatedAt { get; set; }
		public Subscription Subscription { get; set; }
		public List<string> DefaultAttachmentCategories { get; set; }
		public List<string> DefaultPostCategories { get; set; }
	}

	public class Subscription
	{
		//  <subscription>
		//    <name>Premium</name>
		//    <writeboards type="float">Infinity</writeboards>
		//    <projects type="integer">100</projects>
		//    <storage type="integer">32212254720</storage>
		//    <ssl type="boolean">true</ssl>
		//    <time-tracking type="boolean">true</time-tracking>
		//  </subscription>

		public Subscription(XElement item)
		{
			Name = item.Element("name").Value;
			Writeboards = float.Parse(item.Element("writeboards").Value);
			Projects = float.Parse(item.Element("projects").Value);
			Storage = float.Parse(item.Element("storage").Value);
			Ssl = bool.Parse(item.Element("ssl").Value);
			TimeTracking = bool.Parse(item.Element("time-tracking").Value);
		}

		public string Name { get; set; }
		public float Writeboards { get; set; }
		public float Projects { get; set; }
		public float Storage { get; set; }
		public bool Ssl { get; set; }
		public bool TimeTracking { get; set; }
	}
}
