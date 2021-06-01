using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book
{
    public class JsonServer
    {
        static RestClient client = new RestClient("http://localhost:3000");

        public static IRestResponse getContactsList()
        {
            RestRequest request = new RestRequest("/contacts", Method.GET);
            IRestResponse response = client.Execute(request);
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            foreach(var contact in dataResponse)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName} - {contact.PhoneNumber}");
            }
            
            return response;
        }
    }
}
