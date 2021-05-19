using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Address_Book
{
    class CSVHandler
    {
        static string path = @"C:\Users\vicun\source\repos\Address-Book\Address-Book\Data.csv";
        public static void WriteToCSVFile(List<Contact> contactList)
        {     
            var records = contactList;
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }
        public static void ReadFromCSV()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                List<Contact> records = csv.GetRecords<Contact>().ToList();
                foreach (Contact contact in records)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                }
            }
            
            
        }
    }
}
