using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book
{
    public class ContactOperation
    {
        private List<Contact> ContactLists = new List<Contact>();
        private Dictionary<string, List<Contact>> CitiesDict = new Dictionary<string, List<Contact>>();
        private Dictionary<string, List<Contact>> StatesDict = new Dictionary<string, List<Contact>>();
        public void generateData()
        {
            Contact data1 = new Contact("amar", "seth", "606-3727 Ullamcorper. Street", "mumbai", "maharastra", "766584", "7654635245", "amar@gmail.com");
            Contact data2 = new Contact("iris", "watson", "San Antonio MI 47096", "mumbai", "maharastra", "633564", "8576456736", "iris@techz.co.in");
            Contact data3 = new Contact("kyla", "olsen", "Ap #651-8679 Sodales Av.", "mumbai", "maharastra", "876554", "9877687745", "kyla@yahoo.com");
            Contact data4 = new Contact("hiroku", "moreno", "935-9940 Tortor. Street.", "bengaluru", "karnataka", "566475", "7587465546", "hiroku@gmail.com");
            Contact data5 = new Contact("ina", "moran", "Erie Rhode Island 24975", "bengaluru", "karnataka", "655739", "6878998709", "ina@yahoo.com");
            ContactLists.Add(data1);
            ContactLists.Add(data2);
            ContactLists.Add(data3);
            ContactLists.Add(data4);
            ContactLists.Add(data5);
            filterCityState(ContactLists);
        }
        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            bool flag = false;
            foreach(Contact contact in ContactLists)
            {
                if (contact.FirstName.ToLower() == firstName.ToLower()) 
                {
                    flag = true;
                    break;
                } 
            }
            Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            if (flag)
            {
                Console.WriteLine("Contact already exist with same FirstName.");
            }
            else
            {
                //Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                this.ContactLists.Add(newContact);
                filterCityState(ContactLists);
            }         
        }
        public void showList()
        {
           foreach(var contact in ContactLists)
            {
                Console.WriteLine("#####################");
                Console.WriteLine("FirstName: "+contact.FirstName);
                Console.WriteLine("LastName: "+contact.LastName);
                Console.WriteLine("Address: "+contact.Address);
                Console.WriteLine("City: "+contact.City);
                Console.WriteLine("State: "+contact.State);
                Console.WriteLine("ZipCode: "+contact.Zip);
                Console.WriteLine("Phone Number: "+contact.PhoneNumber);
                Console.WriteLine("Email: "+contact.Email);
                Console.WriteLine("#####################");
            }
        }
        public void editContact(string fName)
        {
            foreach(var contact in ContactLists)
            {
                if(contact.FirstName.ToLower() == fName.ToLower())
                {
                    Console.WriteLine("Edit? Old FirstName: " + contact.FirstName);
                    string newFirstName = Console.ReadLine();
                    Console.WriteLine("Edit? Old LastName: " + contact.LastName);
                    string newLastName = Console.ReadLine();
                    Console.WriteLine("Edit? Old Address: " + contact.Address);
                    string newAddress = Console.ReadLine();
                    Console.WriteLine("Edit? Old City: " + contact.City);
                    string newCity = Console.ReadLine();
                    Console.WriteLine("Edit? Old State: " + contact.State);
                    string newState = Console.ReadLine();
                    Console.WriteLine("Edit? Old ZipCode: " + contact.Zip);
                    string newZip = Console.ReadLine();
                    Console.WriteLine("Edit? Old Phone Number: " + contact.PhoneNumber);
                    string newPhoneNumber = Console.ReadLine();
                    Console.WriteLine("Edit? Old Email: " + contact.Email);
                    string newEmail = Console.ReadLine();
                    Console.WriteLine("-----------------");

                    if(newFirstName != "")
                    {
                        contact.FirstName = newFirstName;
                    }
                    if (newLastName != "")
                    {
                        contact.LastName = newLastName;
                    }
                    if (newAddress != "")
                    {
                        contact.Address = newAddress;
                    }
                    if (newCity != "")
                    {
                        contact.City = newCity;
                        filterCityState(ContactLists);
                    }
                    if (newState != "")
                    {
                        contact.State = newState;
                        filterCityState(ContactLists);
                    }
                    if (newZip != "")
                    {
                        contact.Zip = newZip;
                    }
                    if (newPhoneNumber != "")
                    {
                        contact.PhoneNumber = newPhoneNumber;
                    }
                    if (newEmail != "")
                    {
                        contact.Email = newEmail;
                    }
                }
            }
        }
        public void deleteContact(string fname)
        {
            foreach(var contact in ContactLists)
            {
                if (contact.FirstName.ToLower() == fname.ToLower())
                {
                    ContactLists.Remove(contact);
                    Console.WriteLine("Contact Deleted Successfully.");
                    filterCityState(ContactLists);
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
        public void searchCity(string city)
        {
            try
            {
                List<Contact> list = CitiesDict[city];
                foreach (var contact in list)
                {
                    Console.WriteLine("City: " + contact.City + " || FirstName: " + contact.FirstName);
                }
                Console.WriteLine("Total Count Based on City: " + list.Count);
            }catch(Exception e)
            {
                Console.WriteLine("No Contact with this City.");
            }
            
        }
        public void addStateList(Contact contact)
        {
            string key = contact.State;
            Contact value = contact;
            if (StatesDict.ContainsKey(key))
            {
                StatesDict[key].Add(value);
            }
            else
            {
                List<Contact> contactList = new List<Contact>();
                StatesDict.Add(key, contactList);
                StatesDict[key].Add(value);
            }
        }
        public void searchState(string state)
        {
            try
            {
                List<Contact> list = StatesDict[state];
                foreach (var contact in list)
                {
                    Console.WriteLine("State: " + contact.State + " || FirstName: " + contact.FirstName);
                }
                Console.WriteLine("Total Count Based on State: " + list.Count);
            }catch(Exception e)
            {
                Console.WriteLine("No Contact with this State.");
            }
            
        }
        public void filterCityState(List<Contact> ContactLists)
        {
            CitiesDict.Clear();
            StatesDict.Clear();
            foreach (var contact in ContactLists)
            {
                addCityList(contact);
                addStateList(contact);
            }
        }
    }
}
