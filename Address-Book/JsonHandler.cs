using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Address_Book
{
    class JsonHandler
    {
        const string path = @"C:\Users\vicun\source\repos\Address-Book\Address-Book\Data.json";
        public static void WriteToJson(List<Contact> contactList)
        {
            string sJSONResponse = JsonConvert.SerializeObject(contactList);
            
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(sJSONResponse);
            }
        }
        public static List<Contact> GetDataFromJson()
        {
            string json = File.ReadAllText(path);
            var contactList = JsonConvert.DeserializeObject<List<Contact>>(json);
            foreach(Contact contact in contactList)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            }
            return contactList;
        }
    }
}
