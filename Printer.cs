using System;
using System.IO;
using System.Collections.Generic;

namespace myapp
{
    class Printer
    {
        private static string format = "{0,-10} {1,-20} {2, -20} {3, -10} {4, -15} {5, -10} {6, -10}";
        private static void writeHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string header = "\t";
            header += String.Format(format, "ID", "First name", "Last name", "Major", "Phone No.", "GPA", "Date\n") + "\t";
            header += String.Format(format, "--", "----------", "---------", "-----", "---------", "---", "----\n");
            Console.WriteLine(header);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void studentListPrinter(List<Student> students, string head)
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

        public static void MainHandler(List<Student> students, string head)
        {
            Console.Clear();
            if(students.Count != 0) {
                studentListPrinter(students, head);
            }
            else {
                Console.WriteLine("No records found!");
            }
        }
    }
}