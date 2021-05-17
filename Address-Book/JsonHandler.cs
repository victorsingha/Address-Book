using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Address_Book
{
    class JsonHandler
    {
        public static void WriteToJson(List<Contact> contactList)
        {
            string sJSONResponse = JsonConvert.SerializeObject(contactList);
            string path = @"C:\Users\vicun\source\repos\Address-Book\Address-Book\Data.json";
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(sJSONResponse);
            }
        }
    }
}
