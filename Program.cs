using System;
using System.IO;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            System.Console.WriteLine(person.GetName());
        }
    }
}