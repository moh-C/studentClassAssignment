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
            List<Student> sortedStudents = new List<Student>();

            string format = "{0,-10} {1,-20} {2, -20} {3, -10} {4, -15} {5, -10} {6, -10}";

            string welcome = "\n\tHello!, welcome to my program. Choose one of the following options: ";
            string options = "\n\n\t1. Display all students\n";
            options += "\t2. Display all students sorted by first name\n";
            options += "\t3. Display all students sorted by last name\n";
            options += "\t4. Display all students sorted by GPA\n";
            
            string starting_msg = welcome + options;
            Console.Write(starting_msg);

            string choice = Convert.ToString(Console.ReadLine());
            
            string head = null;
            switch (choice)
            {
                case "1":
                    head = "\n\tHere is the students' list: \n\n";
                    sortedStudents = Students;
                    break;

                case "2":
                    sortedStudents = Student.Sort(Students, 'F');
                    head = "\n\tHere is the students' list sorted by their first names: \n\n";
                    break;

                case "3":
                    sortedStudents = Student.Sort(Students, 'L');
                    head = "\n\tHere is the students' list sorted by their last names: \n\n";
                    break;

                case "4":
                    head = "\n\tHere is the students' list sorted by their GPA: \n\n";
                    sortedStudents = Student.Sort(Students, 'G');
                    break;

                default:
                    break;
            }
            studentListPrinter(sortedStudents, head);
            
            void writeHeader()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string header = "\t";
                header += String.Format(format, "ID", "First name", "Last name", "Major", "Phone No.", "GPA", "Date\n") + "\t";
                header += String.Format(format, "--", "----------", "---------", "-----", "---------", "---", "----\n\n");
                Console.WriteLine(header);
                Console.ForegroundColor = ConsoleColor.White;
            }

            void studentListPrinter(List<Student> students, string head)
            {
                Console.Clear();
                Console.WriteLine(head);
                writeHeader();
                foreach (var student in students)
                {
                    string header = "\t";
                    header += String.Format(format, $"{student.StudentID}", $"{student.FirstName}",
                                                    $"{student.LastName}", $"{student.Major}",
                                                    $"{student.Phone}", $"{student.GPA}", $"{student.DateOfBirth.ToShortDateString()}");
                    Console.WriteLine(header);    
                }
            }
        }
    }
}