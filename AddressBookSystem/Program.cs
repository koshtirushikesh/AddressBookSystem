using System;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Welcome to Address Book");
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("\n1. Create Contact");
                Console.WriteLine("2. Display All Contact");
                Console.WriteLine("3. Edit The contact");
                Console.WriteLine("4. Delete The contact");
                Console.WriteLine("5. Search By city");
                Console.WriteLine("6. view By city");
                Console.WriteLine("7. Count By city");
                Console.WriteLine("8. Sort Address book By First Name");
                Console.WriteLine("9. Sort Address book By City Name");
                Console.WriteLine("10. Sort Address book By State Name");
                Console.WriteLine("11. Write Text File");
                Console.WriteLine("12. Read Text File");
                Console.WriteLine("13. Write csv File");
                Console.WriteLine("14. Read csv File");
                Console.WriteLine("15. Read csv And Write Json File");
                Console.WriteLine("16. Exit the program");

                Console.Write("\nEnter option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (option)
                {
                    case 1: addressBook.CreatContact(); break;
                    case 2: addressBook.Display(); break;
                    case 3:
                        Console.Write("enter the first name of contact to Edit: ");
                        string firstName = Console.ReadLine();
                        Console.Write("enter the last name of contact to Edit: ");
                        string lastName = Console.ReadLine();
                        addressBook.Edit(firstName, lastName);
                        addressBook.Display();
                        break;

                    case 4:
                        Console.Write("enter the first name of contact to Delete: ");
                        firstName = Console.ReadLine();
                        Console.Write("enter the last name of contact to Delete: ");
                        lastName = Console.ReadLine();
                        addressBook.Delete(firstName, lastName);
                        break;
                    case 5: addressBook.SearchByCity(); break;
                    case 6: addressBook.ViewByCity(); break;
                    case 7: addressBook.CountByCity(); break;
                    case 8: addressBook.SortAddressBookByFirstName(); break;
                    case 9: addressBook.SortAddressBookByCity(); break;
                    case 10: addressBook.SortAddressBookByState(); break;
                    case 11: addressBook.AddressBookFileWrite(); break;
                    case 12: addressBook.AddressBookFileReader(); break;
                    case 13: addressBook.AddressBookCSVFileWrite(); break;
                    case 14: addressBook.AddressBookCSVFileRead(); break;
                    case 15: addressBook.AddressBookCsvToJsonFileRead(); break;
                    case 16: flag = false; break;
                }
            }
        }
    }
}
