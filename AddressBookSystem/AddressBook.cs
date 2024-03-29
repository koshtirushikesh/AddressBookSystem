﻿using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AddressBookSystem
{
    public class AddressBook
    {
        Contact contact = new Contact();
        List<Contact> contactsList = new List<Contact>();
        Dictionary<string, Contact> addressBookDictonary = new Dictionary<string, Contact>();
        Dictionary<string, List<Contact>> addressBookDictonaryByCity = new Dictionary<string, List<Contact>>();
        string addressBookTextFilePath = "C:\\Users\\Rushi\\source\\repos\\AddressBookSystem\\AddressBookSystem\\AddressBookContactFiles\\AddressBookTextFile.txt";
        string addressBookCsvFilePath = "C:\\Users\\Rushi\\source\\repos\\AddressBookSystem\\AddressBookSystem\\AddressBookContactFiles\\AddressBook.csv";
        string addressBookJsonFilePath = "C:\\Users\\Rushi\\source\\repos\\AddressBookSystem\\AddressBookSystem\\AddressBookContactFiles\\AddressBookJson.json";

        public void CreatContact()
        {
            bool flage = true;
            Contact contact = new Contact();

            Console.WriteLine(" *************** Creating New Contact ");
            while (flage)
            {
                Console.Write("First Name: ");
                contact.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine();

                if (contactsList.Any(x => x.FirstName == contact.FirstName && x.LastName == contact.LastName))
                {
                    Console.WriteLine("\nthis Person is already in the collection. \n");
                }
                else
                {
                    flage = false;
                }
            }

            Console.Write("Address: ");
            contact.Address = Console.ReadLine();
            Console.Write("City: ");
            contact.City = Console.ReadLine();
            Console.Write("State: ");
            contact.State = Console.ReadLine();
            Console.Write("Zip Code: ");
            contact.Zipcode = Console.ReadLine();
            Console.Write("Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            if (contactsList.Any(x => x.FirstName == contact.FirstName && x.LastName == contact.LastName))
            {
                Console.WriteLine("\nthis Person is already in the collection. ");
            }
            else
            {
                contactsList.Add(contact);
                addressBookDictonary.Add(contact.FirstName + contact.LastName, contact);

                if (addressBookDictonaryByCity.ContainsKey(contact.City))
                {
                    addressBookDictonaryByCity[contact.City].Add(contact);
                }
                else
                {
                    addressBookDictonaryByCity.Add(contact.City, new List<Contact>());
                    addressBookDictonaryByCity[contact.City].Add(contact);
                }
                Console.WriteLine("\nthis Person is successfully add to the collection.");
            }
        }

        public void Display()
        {
            foreach (var contact in addressBookDictonary)
            {
                Console.WriteLine("\nContact Details\n" + "\n" + "First Name: " + contact.Value.FirstName);
                Console.WriteLine("Last Name: " + contact.Value.LastName);
                Console.WriteLine("Address: " + contact.Value.Address);
                Console.WriteLine("City: " + contact.Value.City);
                Console.WriteLine("State: " + contact.Value.State);
                Console.WriteLine("Zip Code: " + contact.Value.Zipcode);
                Console.WriteLine("PhoneNumber: " + contact.Value.PhoneNumber);
                Console.WriteLine("E mail: " + contact.Value.Email);
            }
        }

        public void Edit(string firstName, string lastName)
        {
            foreach (var contact in addressBookDictonary)
            {
                if (contact.Key.Equals(firstName + lastName))
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
                                contact.Value.Address = Console.ReadLine();
                                break;

                            case 2:
                                Console.Write("Enter The New City: ");
                                contact.Value.City = Console.ReadLine();
                                break;
                            case 3:
                                Console.Write("Enter The New State: ");
                                contact.Value.State = Console.ReadLine();
                                break;
                            case 4:
                                Console.Write("Enter The New Zipcode: ");
                                contact.Value.Zipcode = Console.ReadLine();
                                break;
                            case 5:
                                Console.Write("Enter The New Phone Number: ");
                                contact.Value.PhoneNumber = Console.ReadLine();
                                break;
                            case 6:
                                Console.Write("Enter The New Email: ");
                                contact.Value.Email = Console.ReadLine();
                                break;
                        }
                        Console.Write("Do you want to chang any thing else: (y = YES,n = NO): ");
                        input = Convert.ToChar(Console.ReadLine());
                    }
                }
                else
                {
                    Console.WriteLine("Contact not found: " + firstName + " " + lastName);
                }
            }
        }

        public void Delete(string firstName, string lastName)
        {
            foreach (var contact in addressBookDictonary)
            {
                if (addressBookDictonary.ContainsKey(firstName + lastName))
                //if (contact.FirstName == name)
                {
                    //contactsList.Remove(contact);
                    addressBookDictonary.Remove(firstName + lastName);
                    Console.WriteLine("Contact deleted successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("Contact name not found ");
                }
            }
        }

        public void SearchByCity()
        {
            Console.Write("Enter the City Name: ");
            string CityName = Console.ReadLine();
            Console.WriteLine("All the Contact Name of: " + CityName + "\n");
            foreach (var contact in addressBookDictonaryByCity[CityName])
            {
                Console.WriteLine("Name: " + contact.FirstName + " " + contact.LastName);
            }
        }

        public void ViewByCity()
        {
            Console.Write("Enter the City Name: ");
            string CityName = Console.ReadLine();
            Console.WriteLine("\nAll the Contact details of: " + CityName + "\n");

            foreach (var contact in addressBookDictonaryByCity[CityName])
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

        public void CountByCity()
        {
            Console.Write("Enter the City Name: ");
            string CityName = Console.ReadLine();
            int count = addressBookDictonaryByCity[CityName].Count();
            Console.WriteLine("\nCity Name : " + CityName + ": No of Contact : " + count);
        }

        public void SortAddressBookByFirstName()
        {
            foreach (var contact in addressBookDictonary.OrderBy(x => x.Value.FirstName))
            {
                Console.WriteLine("Last Name: " + contact.Value.FirstName);
                Console.WriteLine("Last Name: " + contact.Value.LastName);
                Console.WriteLine("Address: " + contact.Value.Address);
                Console.WriteLine("City: " + contact.Value.City);
                Console.WriteLine("State: " + contact.Value.State);
                Console.WriteLine("Zip Code: " + contact.Value.Zipcode);
                Console.WriteLine("PhoneNumber: " + contact.Value.PhoneNumber);
                Console.WriteLine("E mail: " + contact.Value.Email);
            }
        }

        public void SortAddressBookByCity()
        {
            foreach (var contact in addressBookDictonary.OrderBy(x => x.Value.City))
            {
                Console.WriteLine("Last Name: " + contact.Value.FirstName);
                Console.WriteLine("Last Name: " + contact.Value.LastName);
                Console.WriteLine("Address: " + contact.Value.Address);
                Console.WriteLine("City: " + contact.Value.City);
                Console.WriteLine("State: " + contact.Value.State);
                Console.WriteLine("Zip Code: " + contact.Value.Zipcode);
                Console.WriteLine("PhoneNumber: " + contact.Value.PhoneNumber);
                Console.WriteLine("E mail: " + contact.Value.Email);
            }
        }

        public void SortAddressBookByState()
        {
            foreach (var contact in addressBookDictonary.OrderBy(x => x.Value.State))
            {
                Console.WriteLine("Last Name: " + contact.Value.FirstName);
                Console.WriteLine("Last Name: " + contact.Value.LastName);
                Console.WriteLine("Address: " + contact.Value.Address);
                Console.WriteLine("City: " + contact.Value.City);
                Console.WriteLine("State: " + contact.Value.State);
                Console.WriteLine("Zip Code: " + contact.Value.Zipcode);
                Console.WriteLine("PhoneNumber: " + contact.Value.PhoneNumber);
                Console.WriteLine("E mail: " + contact.Value.Email);
            }
        }

        public void AddressBookFileReader()
        {
            using (StreamReader streamReader = File.OpenText(addressBookTextFilePath))
            {
                string printToConsole = "";
                while ((printToConsole = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(printToConsole);
                }
            }
        }

        public void AddressBookFileWrite()
        {
            using (StreamWriter streamWriter = File.AppendText(addressBookTextFilePath))
            {
                streamWriter.WriteLine("\nContact Details\n");

                foreach (var contact in addressBookDictonary)
                {
                    streamWriter.WriteLine("\nFirst Name: " + contact.Value.FirstName);
                    streamWriter.WriteLine("Last Name: " + contact.Value.LastName);
                    streamWriter.WriteLine("Address: " + contact.Value.Address);
                    streamWriter.WriteLine("City: " + contact.Value.City);
                    streamWriter.WriteLine("State: " + contact.Value.State);
                    streamWriter.WriteLine("Zip Code: " + contact.Value.Zipcode);
                    streamWriter.WriteLine("PhoneNumber: " + contact.Value.PhoneNumber);
                    streamWriter.WriteLine("E mail: " + contact.Value.Email);
                }

                streamWriter.Close();
                Console.WriteLine(File.ReadAllText(addressBookTextFilePath));
            }
        }

        public void AddressBookCSVFileWrite()
        {
            using (var writer = new StreamWriter(addressBookCsvFilePath))
            using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWrite.WriteRecords(contactsList);
            }
        }

        public void AddressBookCSVFileRead()
        {
            using (var reader = new StreamReader(addressBookCsvFilePath))
            using (var csvRead = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var addressBookRecords = csvRead.GetRecords<Contact>().ToList();

                foreach (var record in addressBookRecords)
                {
                    Console.WriteLine("\n" + record.FirstName);
                    Console.WriteLine(record.LastName);
                    Console.WriteLine(record.Address);
                    Console.WriteLine(record.City);
                    Console.WriteLine(record.State);
                    Console.WriteLine(record.Zipcode);
                    Console.WriteLine(record.PhoneNumber);
                }
            }
        }

        public void AddressBookCsvToJsonFileRead()
        {
            using (var stremReader = new StreamReader(addressBookCsvFilePath))
            using (var csvReader = new CsvReader(stremReader,CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<Contact>().ToList();

                foreach (var contacts in records)
                {
                    Console.WriteLine("\n"+contacts.FirstName);
                    Console.WriteLine(contacts.LastName);
                    Console.WriteLine(contacts.Address);
                    Console.WriteLine(contacts.City);
                    Console.WriteLine(contacts.State);
                    Console.WriteLine(contacts.Zipcode);
                    Console.WriteLine(contacts.PhoneNumber);
                    Console.WriteLine(contacts.Email);
                }

                Console.WriteLine("******* Reading from csv file & writing to json file");
                JsonSerializer jsonSerializer = new JsonSerializer();

                using (StreamWriter streamWriter = new StreamWriter(addressBookJsonFilePath))
                using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(jsonWriter, records);
                }
            }
        }
    }
}
