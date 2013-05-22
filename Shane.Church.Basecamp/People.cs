using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;
using System.Net;

namespace Shane.Church.Basecamp
{
//<person>
//  <id type="integer">#{id}</id>
//  <first-name>#{first_name}</first-name>
//  <last-name>#{last_name}</last-name>
//  <title>#{title}</title>
//  <email-address>#{email_address}</email-address>
//  <im-handle>#{im_handle}</im-handle>
//  <im-service>#{im_service}</im-service>
//  <phone-number-office>#{phone_number_office}</phone-number-office>
//  <phone-number-office-ext>#{phone_number_office_ext}</phone-number-office-ext>
//  <phone-number-mobile>#{phone_number_mobile}</phone-number-mobile>
//  <phone-number-home>#{phone_number_home}</phone-number-home>
//  <phone-number-fax>#{phone_number_fax}</phone-number-fax>
//  <company-id type="integer">#{company_id}</company-id>
//  <client-id type="integer">#{client_id}</client-id>

//  <avatar-url>#{avatar_url}</avatar-url>

//  <!-- if user is an administrator, or is self -->
//  <user-name>#{user_name}</user-name>

//  <!-- if user is an administrator -->
//  <administrator type="boolean">#{administrator}</administrator>
//  <deleted type="boolean">#{deleted}</deleted>
//  <has-access-to-new-projects type="boolean">#{has_access_to_new_projects}</has-access-to-new-projects>
//</person>

	public class People: Base
	{
		public People(string BasecampUrl, string APIKey): 
			base(BasecampUrl, APIKey)
		{

		}

		public Person GetMe()
		{
			string xml = ExecuteWebRequest(MainBasecampURI + "me.xml");

			XElement personXml = XElement.Parse(xml);

			return new Person(personXml);
		}

		public List<Person> GetPeople()
		{
			string xml = ExecuteWebRequest(MainBasecampURI + "people.xml");

			XElement peopleXml = XElement.Parse(xml);

			List<Person> peopleToReturn = new List<Person>();

			var people = (from c in peopleXml.Descendants("person")
							 select c);

			foreach (XElement p in people)
			{
				Person company = new Person(p);

				peopleToReturn.Add(company);
			}

			return peopleToReturn;
		}

		public List<Person> GetPeopleForCompany(int CompanyId)
		{
			string xml = ExecuteWebRequest(MainBasecampURI + "/companies/" + CompanyId.ToString() + "/people.xml");

			XElement peopleXml = XElement.Parse(xml);

			List<Person> peopleToReturn = new List<Person>();

			var people = (from c in peopleXml.Descendants("person")
						  select c);

			foreach (XElement p in people)
			{
				Person company = new Person(p);

				peopleToReturn.Add(company);
			}

			return peopleToReturn;
		}
	}

	public class Person
	{
		public Person()
		{

		}

		public Person(XElement item)
		{
			this.Id = int.Parse(item.Element("id").Value);
			this.FirstName = item.Element("first-name").Value;
			this.LastName = item.Element("last-name").Value;
			this.Title = item.Element("title").Value;
			this.EmailAddress = item.Element("email-address").Value;
			this.IMHandle = item.Element("im-handle").Value;
			this.IMService = item.Element("im-service").Value;
			this.OfficePhone = item.Element("phone-number-office").Value;
			this.OfficePhoneExt = item.Element("phone-number-office-ext").Value;
			this.MobilePhone = item.Element("phone-number-mobile").Value;
			this.HomePhone = item.Element("phone-number-home").Value;
			this.FaxPhone = item.Element("phone-number-fax").Value;
			this.CompanyId = int.Parse(item.Element("company-id").Value);
			this.ClientId = int.Parse(item.Element("client-id").Value);
			this.AvatarUrl = item.Element("avatar-url").Value;
		}

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string EmailAddress { get; set; }
		public string IMHandle { get; set; }
		public string IMService { get; set; }
		public string OfficePhone { get; set; }
		public string OfficePhoneExt { get; set; }
		public string MobilePhone { get; set; }
		public string HomePhone { get; set; }
		public string FaxPhone { get; set; }
		public int CompanyId { get; set; }
		public int ClientId { get; set; }
		public string AvatarUrl { get; set; }

		public Bitmap GetAvatarBitmap()
		{
			if (!string.IsNullOrEmpty(AvatarUrl))
			{
				HttpWebResponse response = null;
				try
				{
					HttpWebRequest request = WebRequest.Create(AvatarUrl) as HttpWebRequest;

					response = request.GetResponse() as HttpWebResponse;
					return new Bitmap(response.GetResponseStream());
				}
				catch
				{
					return null;
				}
				finally
				{
					response.Close();
				}
			}
			else
			{
				return null;
			}
		}
	}
}
