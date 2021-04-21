using System;

namespace Address_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book");
            Console.WriteLine("-----------------------");
            Console.WriteLine("-----------------------");
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

        ContactOperation contactOperation = new ContactOperation();
            contactOperation.addContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            contactOperation.showList();

            Console.ReadKey();
        }
    }
}
