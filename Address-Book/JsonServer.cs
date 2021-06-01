using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public void postContact(Contact contact)
        {
            RestRequest request = new RestRequest("/contacts", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("FirstName", contact.FirstName);
            jObjectbody.Add("LastName", contact.LastName);
            jObjectbody.Add("Address", contact.Address);
            jObjectbody.Add("City", contact.City);
            jObjectbody.Add("State", contact.State);
            jObjectbody.Add("Zip", contact.Zip);
            jObjectbody.Add("PhoneNumber", contact.PhoneNumber);
            jObjectbody.Add("Email", contact.Email);
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            
            IRestResponse response = client.Execute(request);
           
            Contact responseData = JsonConvert.DeserializeObject<Contact>(response.Content);

            Console.WriteLine($"{responseData.FirstName} {responseData.LastName} - {responseData.PhoneNumber}");
        }
    }
}
