using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Address_Book
{
    class FileIO
    {
        public static void WriteToTxt(List<Contact> contactList)
        {
            string path = @"C:\Users\vicun\source\repos\Address-Book\Address-Book\Data.txt";
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(string.Format("FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email"));
                foreach (Contact contact in contactList)
                {
                    tw.WriteLine(string.Format($"{contact.FirstName},{contact.LastName},{contact.Address},{contact.City},{contact.State},{contact.Zip},{contact.PhoneNumber},{contact.Email}"));
                }
            }
        }
    }
}
