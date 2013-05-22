using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace Shane.Church.Basecamp
{
//<company>
//  <id type="integer">#{id}</id>
//  <name>#{name}</name>
//  <address-one>#{address_one}</address-one>
//  <address-two>#{address_two}</address-two>
//  <city>#{city}</city>
//  <state>#{state}</state>
//  <zip>#{zip}</zip>
//  <country>#{country}</country>
//  <web-address>#{web_address}</web-address>
//  <phone-number-office>#{phone_number_office></phone-number-office>
//  <phone-number-fax>#{phone_number_fax}</phone-number-fax>
//  <time-zone-id>#{time_zone_id}</time-zone-id>
//  <can-see-private type="boolean">#{can_see_private}</can-see-private>

//  <!-- for non-client companies -->
//  <url-name>#{url_name}</url-name>
//</company>

	public class Companies: Base
	{
		public Companies(string BasecampUrl, string APIKey): 
			base(BasecampUrl, APIKey)
		{
	
		}		

		public List<Company> GetCompanies()
		{
			string xml = ExecuteWebRequest(MainBasecampURI + "companies.xml");

			XElement companiesXml = XElement.Parse(xml);

			List<Company> companiesToReturn = new List<Company>();			

			var companies = (from c in companiesXml.Descendants("company")
							 select c);

			foreach(XElement c in companies)
			{
				Company company = new Company(c);

				companiesToReturn.Add(company);
			}

			return companiesToReturn;
		}

		public Company GetCompany(int id)
		{
			string xml = ExecuteWebRequest(MainBasecampURI + "companies/" + id.ToString() + ".xml");

			XElement companyXml = XElement.Parse(xml);

			return new Company(companyXml);
		}
	}

	public class Company
	{
		public Company()
		{

		}

		public Company(XElement item)
		{
			this.Id = int.Parse(item.Element("id").Value);
			this.Name = item.Element("name").Value;
			this.AddressOne = item.Element("address-one").Value;
			this.AddressTwo = item.Element("address-two").Value;
			this.City = item.Element("city").Value;
			this.Country = item.Element("country").Value;
			this.State = item.Element("state").Value;
			this.Zip = item.Element("zip").Value;
			this.WebAddress = item.Element("web-address").Value;
			this.OfficePhone = item.Element("phone-number-office").Value;
			this.OfficeFax = item.Element("phone-number-fax").Value;
			this.TimeZoneId = item.Element("time-zone-id").Value;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string AddressOne { get; set; }
		public string AddressTwo { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Country { get; set; }
		public string WebAddress { get; set; }
		public string OfficePhone { get; set; }
		public string OfficeFax { get; set; }
		public string TimeZoneId { get; set; }
	}
}
