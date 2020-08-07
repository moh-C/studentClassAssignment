using System;
using System.IO;

namespace myapp
{
    class Person
    {
        public string Name;
        public void Introduce(string to) {
            Console.WriteLine("Hello {0}, my name is {1}!", to, this.Name);
        }

        public static Person Parse(string someName){
            var person = new Person();
            person.Name = someName;
            return person;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person.Parse("Mammad").Introduce("Ali");
        }
    }
}