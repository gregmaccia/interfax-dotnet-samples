using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Interfax_35_sample
{
	class Program
	{
		static void Main(string[] args)
		{
      // Your credentials
			const string username = "username";
			const string password = "password";
      
      // The fax you want to send
			const string faxFilePath = "fax.pdf";

      // The API method to call
			const string baseUri = "https://rest.interfax.net";
			string uploadUri = "/outbound/faxes";

			// Set the parameters as per
			// https://www.interfax.net/en/dev/rest/reference/2918
			var options = new Dictionary<String, String>(){
				{"faxNumber", "+11111111112"}
			};

			// Create a new web client for making API calls
			WebClient webClient = new WebClient();
		
			// Build the URL with the options defined earlier
			uploadUri += "?";
			foreach (var x in options.Keys)
			{
				uploadUri += x + '=' + options[x] + '&';
			}

			// Add the credentials to the headers
			var encodedAuth = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
			webClient.BaseAddress = baseUri;
			webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + encodedAuth);
			webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
			webClient.Headers.Add(HttpRequestHeader.ContentType, "application/pdf");

			// Submit the file
			var result = webClient.UploadFile(uploadUri, "post", faxFilePath);
		}
	}
}
