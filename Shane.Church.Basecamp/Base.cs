using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Shane.Church.Basecamp
{
	public abstract class Base
	{
		protected const string _BasecampURLSuffix = ".basecamphq.com/";
		protected const string _BasecampURLPrefix = "https://";
		protected string _BasecampURL = "";
		protected string _APIKey = "";

		protected Base(string BasecampUrl, string APIKey)
		{
			_BasecampURL = BasecampUrl;
			_APIKey = APIKey;
		}

		protected Uri MainBasecampURI
		{
			get
			{
				return new Uri(_BasecampURLPrefix + _BasecampURL + _BasecampURLSuffix);
			}
		}

		protected string ExecuteWebRequest(string Url)
		{
			HttpWebResponse response = null;
			try
			{
				HttpWebRequest request = WebRequest.Create(Url) as HttpWebRequest;
				request.Credentials = new NetworkCredential(_APIKey, "x");
				request.ContentType = "application/xml";
				request.Accept = "application/xml";

				response = request.GetResponse() as HttpWebResponse;
				StreamReader reader = new StreamReader(response.GetResponseStream());
				string xml = reader.ReadToEnd();
				response.Close();

				return xml;
			}
			finally
			{
				response.Close();
			}
		}
	}
}
