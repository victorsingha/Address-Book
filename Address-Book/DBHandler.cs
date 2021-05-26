using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Address_Book
{
    public class DBHandler
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=address_book_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        List<Contact> contactList = new List<Contact>();
        public List<Contact> GetAllData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"Select * from contacts;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
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
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return contactList;
        }

        public void addContact(Contact contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = $"insert into contacts (Firstname, Lastname, Address, City, State, Zip, PhoneNumber, Email) values ('{contact.FirstName}','{contact.LastName}','{contact.Address}','{contact.City}','{contact.State}','{contact.Zip}','{contact.PhoneNumber}','{contact.Email}')";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Data Inserted.");                
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void removeContact(String firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = $"delete from contacts where Firstname = '{firstName}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Contact Deleted from DB.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static public void countCity(String city)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = $"select count(*) from contacts where City = '{city}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    int numrows = (int)cmd.ExecuteScalar();
                    connection.Close();
                    Console.WriteLine($"------------------------------------------");
                    Console.WriteLine($"Total Count of '{city}' city {numrows}");
                    Console.WriteLine($"------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static public void countState(String state)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = $"select count(*) from contacts where State = '{state}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    int numrows = (int)cmd.ExecuteScalar();
                    connection.Close();
                    Console.WriteLine($"------------------------------------------");
                    Console.WriteLine($"Total Count of '{state}' city {numrows}");
                    Console.WriteLine($"------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
