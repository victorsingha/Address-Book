using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book
{
    public class Contact
    {
        private String firstName;
        private String lastName;
        private String address;
        private String city;
        private String state;
        private String zip;
        private String phoneNumber;
        private String email;

        public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
        public Contact()
        {

        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
    }
}
