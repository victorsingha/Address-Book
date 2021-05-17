﻿using System;
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
            // generating data from JSON file.
            ContactLists = JsonHandler.GetDataFromJson();
            filterCityState(ContactLists);
        }
        public bool checkDuplicate(string firstName) 
        {
            bool flag = false;
            foreach (Contact contact in ContactLists)
            {
                if (contact.FirstName.ToLower() == firstName.ToLower())
                {
                    flag = true;
                    Console.WriteLine("Contact already exist with same FirstName.");
                    break;
                }
            }
            if (flag) return true;
            else return false;
        }
        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            this.ContactLists.Add(newContact);
            filterCityState(ContactLists);
            
            //writing to txt,csv,json
            CSVHandler.WriteToCSVFile(ContactLists);
            FileIO.WriteToTxt(ContactLists);
            JsonHandler.WriteToJson(ContactLists);
        }
        public void showList()
        {
           foreach(var contact in ContactLists)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("FirstName: "+contact.FirstName);
                Console.WriteLine("LastName: "+contact.LastName);
                Console.WriteLine("Address: "+contact.Address);
                Console.WriteLine("City: "+contact.City);
                Console.WriteLine("State: "+contact.State);
                Console.WriteLine("ZipCode: "+contact.Zip);
                Console.WriteLine("Phone Number: "+contact.PhoneNumber);
                Console.WriteLine("Email: "+contact.Email);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("                                   ");
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
                Console.WriteLine($"No Contact with this City. {e}");
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
