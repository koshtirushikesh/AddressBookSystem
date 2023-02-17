using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        Contact contact = new Contact();
        List<Contact> contactsList = new List<Contact>();

        public void CreatContact()
        {
            Contact contact = new Contact();
            Console.WriteLine(" *************** Creating New Contact ");
            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine();
            Console.Write("Address: ");
            contact.Address = Console.ReadLine();
            Console.Write("City: ");
            contact.City = Console.ReadLine();
            Console.Write("State: ");
            contact.State = Console.ReadLine();
            Console.Write("Zip Code: ");
            contact.Zipcode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            contactsList.Add(contact);
        }

        public void Display()
        {
            foreach (var contact in contactsList)
            {
                Console.WriteLine("\nContact Details\n" + "\n" + "First Name: " + contact.FirstName);
                Console.WriteLine("Last Name: " + contact.LastName);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("City: " + contact.City);
                Console.WriteLine("State: " + contact.State);
                Console.WriteLine("Zip Code: " + contact.Zipcode);
                Console.WriteLine("PhoneNumber: " + contact.PhoneNumber);
                Console.WriteLine("E mail: " + contact.Email);
            }
        }

        public void Edit(string name)
        {
            foreach (var contact in contactsList)
            {
                if (contact.FirstName.Equals(name))
                {
                    char input = 'y';
                    while (input == 'y')
                    {
                        Console.WriteLine("1. Address");
                        Console.WriteLine("2. City");
                        Console.WriteLine("3. State");
                        Console.WriteLine("4. ZipCode");
                        Console.WriteLine("5. Phone Number");
                        Console.WriteLine("6. Email");
                        Console.Write("Enter option:");
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.Write("Enter The New Address: ");
                                contact.Address = Console.ReadLine();
                                break;

                            case 2:
                                Console.Write("Enter The New City: ");
                                contact.City = Console.ReadLine();
                                break;
                            case 3:
                                Console.Write("Enter The New State: ");
                                contact.State = Console.ReadLine();
                                break;
                            case 4:
                                Console.Write("Enter The New Zipcode: ");
                                contact.Zipcode = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 5:
                                Console.Write("Enter The New Phone Number: ");
                                contact.PhoneNumber = Console.ReadLine();
                                break;
                            case 6:
                                Console.Write("Enter The New Email: ");
                                contact.Email = Console.ReadLine();
                                break;
                        }
                        Console.Write("Do you want to chang any thing else: (y = YES,n = NO): ");
                        input = Convert.ToChar(Console.ReadLine());
                    }
                }
                else
                {
                    Console.WriteLine("Contact not found: " + name);
                }
            }
        }

        public void Delete(string name)
        {

            foreach (var contact in contactsList)
            {
                if (contact.FirstName == name)
                {
                    contactsList.Remove(contact);
                    Console.WriteLine("Contact deleted successfully");
                    break;
                }else
                {
                    Console.WriteLine("Contact name not found "); 
                }
            }
        }
    }
}
