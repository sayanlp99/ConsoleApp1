using System;

namespace ConsoleApp1
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }

        public Person()
        {
        }

        public Person(int id, string name, int age)
        {
            ID = id;
            Name = name;
            Age = age;
        }
    }
}

