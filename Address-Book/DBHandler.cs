using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Address_Book
{
    public class DBHandler
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=address_book_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        List<Contact> contactList = new List<Contact>();
        public List<Contact> GetAllData()
        {
            try
            {
                using (this.connection)
                {
                    string query = @"Select * from contacts;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Contact contact = new Contact();
                            contact.FirstName = dr.GetString(1);
                            contact.LastName = dr.GetString(2);
                            contact.Address = dr.GetString(3);
                            contact.City = dr.GetString(4);
                            contact.State = dr.GetString(5);
                            contact.Zip = dr.GetString(6);
                            contact.PhoneNumber = dr.GetString(7);
                            contact.Email = dr.GetString(8);

                            //System.Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                            //System.Console.WriteLine("\n");
                            contactList.Add(contact);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return contactList;
        }
    }
}
