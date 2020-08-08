using System;
using System.Collections.Generic;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> Students = Student.load_data();
            List<Student> sortedStudents = new List<Student>();

            string welcome = "\n\tHello!, welcome to my program. Choose one of the following options: ";
            string options = "\n\n\t1. Display all students.\n";
            options += "\t2. Display all students sorted by first name.\n";
            options += "\t3. Display all students sorted by last name.\n";
            options += "\t4. Display all students sorted by GPA.\n";
            options += "\t5. Search for a student by their first name.\n";
            
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

                case "5":
                    Console.WriteLine("Please enter ID of the student you want: ");
                    string ID = Convert.ToString(Console.ReadLine());
                    head = "\n\tHere is the student's Info\n\n";
                    sortedStudents = Student.FindStudent(Students, ID, "ID");
                    if(sortedStudents.Count == 0) {
                        Console.WriteLine("No students were found!");
                    }
                    break;
                default:
                    break;
            }
            
            Printer.MainHandler(sortedStudents, head);
        }
    }
}