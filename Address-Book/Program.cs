﻿using System;

namespace Address_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            //CSVHandler.ReadFromCSV();       
            ContactOperation contactOperation = new ContactOperation();
            contactOperation.generateData();
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("        Welcome To Address Book");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("------------- CONTACT LIST -----------");
                Console.WriteLine("--------------------------------------");
                contactOperation.ShowInBrief();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("  Select Choice:");
                Console.WriteLine("  Add Contact     [1]");
                Console.WriteLine("  Show Contacts   [2]");
                Console.WriteLine("  Edit Contact    [3]");
                Console.WriteLine("  Delete Contact  [4]");
                Console.WriteLine("  Search by City  [5]");
                Console.WriteLine("  Search by State [6]");
                Console.WriteLine("  Exit            [7]");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("  Select an Option / Type First Name of the Contact.:");

                try
                {
                    string data = Console.ReadLine();
                    int input = 0;
                    bool result = int.TryParse(data, out input);
                    if (result)
                    {
                        switch (input)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("--Add Contact Details--");
                                Console.WriteLine("First Name:");
                                string firstName = Console.ReadLine();
                                bool isDuplicate = contactOperation.checkDuplicate(firstName);
                                if (isDuplicate) break;
                                Console.WriteLine("Last Name:");
                                string lastName = Console.ReadLine();
                                Console.WriteLine("Address:");
                                string address = Console.ReadLine();
                                Console.WriteLine("City:");
                                string city = Console.ReadLine();
                                Console.WriteLine("State:");
                                string state = Console.ReadLine();
                                Console.WriteLine("Zip Code:");
                                string zip = Console.ReadLine();
                                Console.WriteLine("Phone Number:");
                                string phoneNumber = Console.ReadLine();
                                Console.WriteLine("Email Address:");
                                string email = Console.ReadLine();
                                contactOperation.addContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                                break;

                            case 2:
                                Console.Clear();
                                contactOperation.showList();
                                break;

                            case 3:
                                Console.WriteLine("Enter First Name of the Contact You Want to Edit.");
                                string fName = Console.ReadLine();
                                contactOperation.editContact(fName);
                                break;

                            case 4:
                                Console.WriteLine("Enter First Name of the Contact You Want to Delete.");
                                string name = Console.ReadLine();
                                contactOperation.deleteContact(name);
                                break;

                            case 5:
                                Console.WriteLine("Enter City Name.");
                                string cityName = Console.ReadLine();
                                contactOperation.searchCityOrState(cityName);
                                DBHandler.countCity(cityName);
                                break;

                            case 6:
                                Console.WriteLine("Enter State Name.");
                                string stateName = Console.ReadLine();
                                contactOperation.searchCityOrState(stateName);
                                DBHandler.countState(stateName);
                                break;

                            case 7:
                                System.Environment.Exit(1);
                                break;
                            default:
                                Console.WriteLine($"{input} is Invalid Choice!");
                                break;
                        }

                    }
                    else
                    {
                        contactOperation.ShowOneContact(data);
                    }                 
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Invalid Choice!");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }            
        }
    }
}
