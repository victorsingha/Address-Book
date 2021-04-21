using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book
{
    public class ContactOperation
    {
        private List<Contact> ContactList;
        public ContactOperation()
        {
            this.ContactList = new List<Contact>();
        }

        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            this.ContactList.Add(newContact);
        }
        public void showList()
        {
           foreach(var contact in ContactList)
            {
                Console.WriteLine("FirstName: "+contact.FirstName);
                Console.WriteLine("LastName: "+contact.LastName);
                Console.WriteLine("Address: "+contact.Address);
                Console.WriteLine("City: "+contact.City);
                Console.WriteLine("State: "+contact.State);
                Console.WriteLine("ZipCode: "+contact.Zip);
                Console.WriteLine("Phone Number: "+contact.PhoneNumber);
                Console.WriteLine("Email: "+contact.Email);
                Console.WriteLine("-----------------");

            }
        }
    }
}
