using System;
using System.IO;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(new DateTime(1929, 12, 12));
            System.Console.WriteLine(person.Birthdate);
            System.Console.WriteLine(person.Age);

            var person2 = new Person(new DateTime(1999, 12, 12));
            System.Console.WriteLine(person2.Birthdate);
            System.Console.WriteLine(person2.Age);
        }
    }
}