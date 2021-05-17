using CsvHelper;
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
        public static void WriteToCSVFile(List<Contact> contactList)
        {
            string exportFilePath = @"C:\Users\vicun\source\repos\Address-Book\Address-Book\Data.csv";
            var records = contactList;
            using (var writer = new StreamWriter(exportFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }
    }
}
