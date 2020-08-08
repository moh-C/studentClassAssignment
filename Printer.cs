using System;
using System.Linq;
using System.Collections.Generic;

namespace myapp
{
    class Printer
    {
        private static string welcome;
        private static string format = "{0,-10} {1,-20} {2, -20} {3, -10} {4, -15} {5, -10} {6, -10}";
        private static char choice;
        private static List<Student> Students = new List<Student>();
        private static List<Student> sortedStudents = new List<Student>();
        private static Dictionary<char, string> Options = new Dictionary<char, string>();

        public Printer()
        {
            Students = Student.load_data();
            
            welcome = "\n\tChoose one of the following options: ";
            System.Console.WriteLine(welcome);
            
            Options.Add('1', "Displaying");
            Options.Add('2', "Searching");
            Options.Add('3', "Editing");
            Options.Add('Q', "Quit");
        }
        private static void OptionsPrinter()
        {
            Options.Select(i => $"\t{i.Key}. {i.Value}").ToList().ForEach(Console.WriteLine);
        }
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

        public static void MainStudentHandler(List<Student> students, string head)
        {
            Console.Clear();
            if(students.Count != 0)
            {
                studentListPrinter(students, head);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tNo records found!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static char IOption()
        {
            Console.WriteLine("\n\tPlease enter your choice");
            string Unprocessed = Console.ReadLine();
            if(Unprocessed.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ForegroundColor = ConsoleColor.White;
                return IOption();
            }

            char _choice = Convert.ToChar(Unprocessed);
            
            if(Options.ContainsKey(_choice))
                return _choice;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The choice does not exist.");
                Console.ForegroundColor = ConsoleColor.White;
                return IOption();
            }
        }

        public static void MainProcessor()
        {
            Console.WriteLine("Please enter your choice");
            OptionsPrinter();
            choice = IOption();

            switch (choice)
            {
                case '1':
                    display();
                    break;

                case '2':
                    search();
                    break;

                case '3':
                    break;
            }
        }

        private static void display()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            
            Options.Clear();
            Options.Add('1', "Display all students");
            Options.Add('2', "Display all students sorted by first name");
            Options.Add('3', "Display all students sorted by last name");
            Options.Add('4', "Display all students sorted by GPA");
            Options.Add('P', "Previous Menu");
            Options.Add('Q', "Quit");
            OptionsPrinter();

            choice = IOption();
            string query = null, head = "\n\tHere is the students' Info\n\n";
            switch (choice)
            {
                case '1':
                    head = "\n\tHere is the students' list: \n\n";
                    sortedStudents = Students;
                break;
                case '2':

                break;
                case '3':

                break;
                case '4':

                break;
                case 'P':

                break;
                case 'Q':

                break;
            }
        }

        private static void search()
        {
            Console.Clear();
            Console.WriteLine("\n\n");

            Options.Clear();
            Options.Add('1', "Search for a student by their first name");
            Options.Add('2', "Search for students by their major");
            Options.Add('3', "Search for students whose GPA is higher than your given GPA");
            Options.Add('4', "Search for students whose GPA is lowe than your given GPA");
            Options.Add('P', "Previous Menu");
            Options.Add('Q', "Quit");
            OptionsPrinter();

            choice = IOption();
        }

        public static void MainProcessor2()
        {
            List<Student> Students = Student.load_data();
            string choice = Convert.ToString(Console.ReadLine());
            
            string query = null, head = "\n\tHere is the students' Info\n\n";

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
                    query = Convert.ToString(Console.ReadLine());
                    sortedStudents = Student.FindStudent(Students, query, "ID");
                    break;

                case "6":
                    Console.WriteLine("Please enter the Major you are interested in: ");
                    query = Convert.ToString(Console.ReadLine());
                    sortedStudents = Student.FindStudent(Students, query, "Major");
                    break;
                
                case "7":
                    Console.WriteLine("Please enter the desired GPA");
                    query = Convert.ToString(Console.ReadLine());
                    sortedStudents = Student.FindStudent(Students, query, "GPA_H");
                    break;
                
                case "8":
                    Console.WriteLine("Please enter the desired GPA");
                    query = Convert.ToString(Console.ReadLine());
                    sortedStudents = Student.FindStudent(Students, query, "GPA_L");
                    break;
                
                case "9":
                    Console.Clear();
                    break;

                default:
                    break;
            }
            Printer.MainStudentHandler(sortedStudents, head);
        }
    }
}