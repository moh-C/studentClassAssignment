using System;
using System.IO;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Birthdate = new DateTime(1929, 12, 12);
            System.Console.WriteLine(person.Birthdate);

            person.Birthdate = new DateTime(1999, 12, 12);
            System.Console.WriteLine(person.Birthdate);
        }
    }
}