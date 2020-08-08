using System;
using System.IO;
using System.Collections.Generic;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> Students = Student.load_data();
            string welcome = "\n\tHello!, welcome to my program. Choose one of the following options: ";
            string options = "\n\n\t1. Display all students\n\t";
            options += "\t2. Display all students sorted by first name\n";
            options += "\t3. Display all students sorted by last name\n";
            options += "\t4. Display all students sorted by GPA\n";
            
            string starting_msg = welcome + options;
            Console.Write(starting_msg);
            string choice = Convert.ToString(Console.ReadLine());
            
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("\n\tHere is the students' list: \n\n");
                    foreach (var student in Students)
                    {
                        Console.WriteLine($"\tStudent's ID: {student.StudentID}");
                        Console.WriteLine($"\tStudent's full name: {student.FirstName} {student.LastName}");
                        Console.WriteLine($"\tStudent's major: {student.Major}");
                        Console.WriteLine($"\tStudent's phone no.: {student.Phone}");
                        Console.WriteLine($"\tStudent's GPA: {student.GPA}");
                        Console.WriteLine($"\tStudent's date of birth: {student.DateOfBirth.ToShortDateString()}");
                        Console.WriteLine("\n\n");
                    }
                    break;
                
                case "2":
                    List<Student> sortedFirstNameStudents = Student.Sort(Students, 'F');
                    Console.Clear();
                    Console.WriteLine("\n\tHere is the students' list sorted by their first names: \n\n");
                    foreach (var student in sortedFirstNameStudents)
                    {
                        Console.WriteLine($"\tStudent's ID: {student.StudentID}");
                        Console.WriteLine($"\tStudent's full name: {student.FirstName} {student.LastName}");
                        Console.WriteLine($"\tStudent's major: {student.Major}");
                        Console.WriteLine($"\tStudent's phone no.: {student.Phone}");
                        Console.WriteLine($"\tStudent's GPA: {student.GPA}");
                        Console.WriteLine($"\tStudent's date of birth: {student.DateOfBirth.ToShortDateString()}");
                        Console.WriteLine("\n\n");
                    }
                    break;

                case "3":
                    List<Student> sortedLastNameStudents = Student.Sort(Students, 'L');
                    Console.Clear();
                    Console.WriteLine("\n\tHere is the students' list sorted by their first names: \n\n");
                    foreach (var student in sortedLastNameStudents)
                    {
                        Console.WriteLine($"\tStudent's ID: {student.StudentID}");
                        Console.WriteLine($"\tStudent's full name: {student.FirstName} {student.LastName}");
                        Console.WriteLine($"\tStudent's major: {student.Major}");
                        Console.WriteLine($"\tStudent's phone no.: {student.Phone}");
                        Console.WriteLine($"\tStudent's GPA: {student.GPA}");
                        Console.WriteLine($"\tStudent's date of birth: {student.DateOfBirth.ToShortDateString()}");
                        Console.WriteLine("\n\n");
                    }
                    break;

                case "4":
                    List<Student> sortedGPAStudents = Student.Sort(Students, 'G');
                    Console.Clear();
                    Console.WriteLine("\n\tHere is the students' list sorted by their first names: \n\n");
                    foreach (var student in sortedGPAStudents)
                    {
                        Console.WriteLine($"\tStudent's ID: {student.StudentID}");
                        Console.WriteLine($"\tStudent's full name: {student.FirstName} {student.LastName}");
                        Console.WriteLine($"\tStudent's major: {student.Major}");
                        Console.WriteLine($"\tStudent's phone no.: {student.Phone}");
                        Console.WriteLine($"\tStudent's GPA: {student.GPA}");
                        Console.WriteLine($"\tStudent's date of birth: {student.DateOfBirth.ToShortDateString()}");
                        Console.WriteLine("\n\n");
                    }
                    break;

                default:
                    break;
            }
        }
    }
}