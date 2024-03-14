using ConsoleApp1;
using System;

namespace HelloWorld
{
    class Program
    {
        static string connectionString = "YourConnectionStringHere";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Get all persons");
                Console.WriteLine("2. Insert new person");
                Console.WriteLine("3. Get person by ID");
                Console.WriteLine("4. Delete person by ID");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        List<Person> allPersons = PersonUtil.GetAllPersons();
                        foreach (Person person in allPersons)
                        {
                            Console.WriteLine($"ID: {person.ID}, Name: {person.Name}, Age: {person.Age}");
                        }
                        break;
                    case 2:
                        Console.Write("Enter person ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        Console.Write("Enter person name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter person age: ");
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            Console.WriteLine("Invalid age.");
                            return;
                        }
                        Person newPerson = new Person(id, name, age);
                        PersonUtil.InsertPerson(newPerson);
                        break;
                    case 3:
                        Console.Write("Enter person ID: ");
                        if (int.TryParse(Console.ReadLine(), out int personId))
                        {
                            PersonUtil.GetPersonById(personId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case 4:
                        Console.Write("Enter person ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            PersonUtil.DeletePersonById(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
