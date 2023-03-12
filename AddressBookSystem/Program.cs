using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("6. Exit the program");
                
                Console.Write("Enter option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                
                switch (option)
                {
                    case 1: addressBook.CreatContact(); break;
                    case 2: addressBook.Display(); break;
                    case 3:
                        Console.Write("enter the name of contact to Edit: ");
                        string name = Console.ReadLine();
                        addressBook.Edit(name);
                        addressBook.Display();
                        break;

                    case 4:
                        Console.Write("enter the name of contact to Delete: ");
                        name = Console.ReadLine();
                        addressBook.Delete(name);
                        break;
                    case 5: addressBook.SearchByCity();break;
                    case 6: flag = false; break;
                }
            }
        }
    }
}
