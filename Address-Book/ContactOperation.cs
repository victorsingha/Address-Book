using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book
{
    public class ContactOperation
    {
        
        private Dictionary<string, Contact> ContactLists = new Dictionary<string,Contact>();
        private Dictionary<string, List<Contact>> CitiesDict = new Dictionary<string, List<Contact>>();
        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            this.ContactLists.Add(firstName, newContact);
            addCityList(newContact);
        }
        public void showList()
        {
           foreach(var contact in ContactLists)
            {
                Console.WriteLine("#####################");
                Console.WriteLine("FirstName: "+contact.Value.FirstName);
                Console.WriteLine("LastName: "+contact.Value.LastName);
                Console.WriteLine("Address: "+contact.Value.Address);
                Console.WriteLine("City: "+contact.Value.City);
                Console.WriteLine("State: "+contact.Value.State);
                Console.WriteLine("ZipCode: "+contact.Value.Zip);
                Console.WriteLine("Phone Number: "+contact.Value.PhoneNumber);
                Console.WriteLine("Email: "+contact.Value.Email);
                Console.WriteLine("#####################");

            }
        }
        public void editContact(string fName)
        {
            foreach(var contact in ContactLists)
            {
                if(contact.Value.FirstName == fName)
                {
                    Console.WriteLine("Edit? Old FirstName: " + contact.Value.FirstName);
                    string newFirstName = Console.ReadLine();
                    Console.WriteLine("Edit? Old LastName: " + contact.Value.LastName);
                    string newLastName = Console.ReadLine();
                    Console.WriteLine("Edit? Old Address: " + contact.Value.Address);
                    string newAddress = Console.ReadLine();
                    Console.WriteLine("Edit? Old City: " + contact.Value.City);
                    string newCity = Console.ReadLine();
                    Console.WriteLine("Edit? Old State: " + contact.Value.State);
                    string newState = Console.ReadLine();
                    Console.WriteLine("Edit? Old ZipCode: " + contact.Value.Zip);
                    string newZip = Console.ReadLine();
                    Console.WriteLine("Edit? Old Phone Number: " + contact.Value.PhoneNumber);
                    string newPhoneNumber = Console.ReadLine();
                    Console.WriteLine("Edit? Old Email: " + contact.Value.Email);
                    string newEmail = Console.ReadLine();
                    Console.WriteLine("-----------------");

                    if(newFirstName != "")
                    {
                        contact.Value.FirstName = newFirstName;
                    }
                    if (newLastName != "")
                    {
                        contact.Value.LastName = newLastName;
                    }
                    if (newAddress != "")
                    {
                        contact.Value.Address = newAddress;
                    }
                    if (newCity != "")
                    {
                        contact.Value.City = newCity;
                    }
                    if (newState != "")
                    {
                        contact.Value.State = newState;
                    }
                    if (newZip != "")
                    {
                        contact.Value.Zip = newZip;
                    }
                    if (newPhoneNumber != "")
                    {
                        contact.Value.PhoneNumber = newPhoneNumber;
                    }
                    if (newEmail != "")
                    {
                        contact.Value.Email = newEmail;
                    }
                }
            }

        }
        public void deleteContact(string fname)
        {
            foreach(var contact in ContactLists)
            {
                if (contact.Value.FirstName == fname)
                {
                    ContactLists.Remove(contact.Key);
                    Console.WriteLine("Contact Deleted Successfully.");
                    break;
                }
            }
        }
        public void addCityList(Contact contact)
        {         
                string key = contact.City;
                Contact value = contact;
                if (CitiesDict.ContainsKey(key))
                {
                    CitiesDict[key].Add(value);                
            }
                else
                {
                    List<Contact> contactList = new List<Contact>();
                    CitiesDict.Add(key, contactList);
                    CitiesDict[key].Add(value);
            }
                    
           
        }
        public void searchCityState(string city)
        {
            List<Contact> list = CitiesDict[city];
            foreach (var i in list)
            {
                Console.WriteLine("City: " + i.City + " || FirstName: " + i.FirstName);
            }
        }
    }
}
