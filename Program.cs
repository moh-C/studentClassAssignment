using System;
using System.IO;
using System.Collections.Generic;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student();
            List<Student> students = Student.load_data();
            System.Console.WriteLine(students.Count);
            System.Console.WriteLine(students[0].DateOfBirth.ToShortDateString());
            System.Console.WriteLine(students[2].DateOfBirth.ToShortDateString());

        }
    }
}