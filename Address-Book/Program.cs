using System;

namespace Address_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book");
            Console.WriteLine("-----------------------");
            
            ContactOperation contactOperation = new ContactOperation();
            while (true)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Select Choice:");
                Console.WriteLine("1.Add Contact");
                Console.WriteLine("2.Show Contacts");
                Console.WriteLine("3.Edit Contact");
                Console.WriteLine("4.Delete Contact");
                Console.WriteLine("5.Search by City");
                Console.WriteLine("6.Exit");
                Console.WriteLine("-----------------------");
                int choice = Convert.ToInt32(Console.ReadLine());
  
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--Add Contact Details--");
                        Console.WriteLine("First Name:");
                        string firstName = Console.ReadLine();
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
                        string nameCityState = Console.ReadLine();
                        contactOperation.searchCityState(nameCityState);
                        break;
                    case 6:
                        System.Environment.Exit(1);
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            
        }
    }
}
