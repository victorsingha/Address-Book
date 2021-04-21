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

            ContactOperation contactOperation = new ContactOperation();
            contactOperation.addContact("victor", "singha", "addrezzz", "cityx", "statez", "766452", "8756473625", "victor@gmail.com");
            contactOperation.showList();

            Console.ReadKey();
        }
    }
}
