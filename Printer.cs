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
            Options.Clear();
            
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
            Console.WriteLine("\n\n");
            Options.Add('Q', "Quit");
            Options.Add('M', "Main Page");
            OptionsPrinter();
            choice = IOption();
            switch(choice)
            {
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'M':
                    MainProcessor();
                    break;
            }
        }

        public static void MainStudentHandler(List<Student> students, string head = "\n\tHere is the students' Info\n\n")
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
                MainProcessor();
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

            char _choice = Convert.ToChar(Unprocessed.ToUpper());
            
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
            Console.Clear();
            Options.Clear();
            
            Options.Add('1', "Displaying");
            Options.Add('2', "Searching");
            Options.Add('3', "Editing");
            Options.Add('Q', "Quit");

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
                    edit();
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
            Options.Add('M', "Main Menu");
            Options.Add('Q', "Quit");
            OptionsPrinter();

            choice = IOption();
            string head = "\n\tHere is the students' Info\n\n";
            switch (choice)
            {
                case '1':
                    head = "\n\tHere is the students' list: \n\n";
                    sortedStudents = Students;
                    break;
                case '2':
                    sortedStudents = Student.Sort(Students, 'F');
                    head = "\n\tHere is the students' list sorted by their first names: \n\n";
                    break;
                case '3':
                    sortedStudents = Student.Sort(Students, 'L');
                    head = "\n\tHere is the students' list sorted by their last names: \n\n";
                    break;
                case '4':
                    head = "\n\tHere is the students' list sorted by their GPA: \n\n";
                    sortedStudents = Student.Sort(Students, 'G');
                    break;
                case 'M':
                    MainProcessor();
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
            }
            MainStudentHandler(sortedStudents, head);
        }

        private static void search()
        {
            string query = null, head = "\n\tHere is the students' Info\n\n";
            Console.Clear();
            Console.WriteLine("\n\n");

            Options.Clear();
            Options.Add('1', "Search for a student by their first name");
            Options.Add('2', "Search for students by their major");
            Options.Add('3', "Search for students whose GPA is higher than your given GPA");
            Options.Add('4', "Search for students whose GPA is lowe than your given GPA");
            Options.Add('M', "Main Menu");
            Options.Add('Q', "Quit");
            OptionsPrinter();

            choice = IOption();
            switch(choice)
            {
                case '1':
                    Console.WriteLine("Please enter ID of the student you want: ");
                    query = Convert.ToString(Console.ReadLine());
                    sortedStudents = Student.FindStudent(Students, query, "ID");
                    break;
                case '2':
                    Console.WriteLine("Please enter the Major you are interested in: ");
                    query = Convert.ToString(Console.ReadLine());
                    sortedStudents = Student.FindStudent(Students, query, "Major");
                    break;
                case '3':
                    Console.WriteLine("Please enter the desired GPA");
                    query = Convert.ToString(Console.ReadLine());
                    sortedStudents = Student.FindStudent(Students, query, "GPA_H");
                    break;
                case '4':
                    Console.WriteLine("Please enter the desired GPA");
                    query = Convert.ToString(Console.ReadLine());
                    sortedStudents = Student.FindStudent(Students, query, "GPA_L");
                    break;
                case 'M':
                    MainProcessor();
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
            }
            MainStudentHandler(sortedStudents, head);
        }

        private static void edit()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            
            Options.Clear();
            Console.WriteLine("Please enter the ID of the student you want to edit: ");
            string query = Convert.ToString(Console.ReadLine());
            Student student = Student.FindStudent(Students, query, "ID")[0];

            
            Options.Clear();
            Options.Add('1', "Edit First Name");
            Options.Add('2', "Edit Last Name");
            Options.Add('3', "Major");
            Options.Add('4', "Phone Number");
            Options.Add('5', "GPA");
            Options.Add('6', "Birthdate");
            Options.Add('A', "Abort");
            Options.Add('Q', "Quit");
            OptionsPrinter();

            choice = IOption();
            switch (choice)
            {
                case '1':
                    Console.WriteLine("Enter the first name: ");
                    student.FirstName = Convert.ToString(Console.ReadLine());
                    break;
                case '2':
                    Console.WriteLine("Enter the last name: ");
                    student.LastName = Convert.ToString(Console.ReadLine());
                    break;
                case '3':
                    Console.WriteLine("Enter the major: ");
                    student.Major = Convert.ToString(Console.ReadLine());
                    break;
                case '4':
                    Console.WriteLine("Enter the Phone No.: ");
                    student.Phone = Convert.ToString(Console.ReadLine());
                    break;
                case '5':
                    Console.WriteLine("Enter the GPA: ");
                    string gpa = Convert.ToString(Console.ReadLine());
                    student.GPA = float.Parse(gpa);
                    break;
                case '6':
                    Console.WriteLine("Enter the Birthdate: ");
                    string date = Convert.ToString(Console.ReadLine());
                    student.DateOfBirth = DateTime.Parse(date);
                    break;
                case 'M':
                    MainProcessor();
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
            }
        }
    }
}