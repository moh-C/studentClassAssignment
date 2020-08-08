using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Student
{   
    public Student()
    {
        
        string[] res = File.ReadAllLines("CurrID.txt");
        IDGenerator = Convert.ToInt32(res[0]);
        IDGenerator++;
    }
    public Student(int studentID, DateTime date)
    {
        StudentID = studentID;
    }
    private Student(int id, string firstName, string lastName, string major, string phone, float gpa)
        : this()
    {
        StudentID = id;
        FirstName = firstName;
        LastName = lastName;
        Major = major;
        Phone = phone;
        GPA = gpa;
    }
    public Student(int id, string firstName, string lastName, string major, string phone, float gpa, DateTime date)
        : this(id, firstName, lastName, major, phone, gpa)
    {
        DateOfBirth = date;
    }

    public static int IDGenerator;
    public int StudentID { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Major { get; set; }
    public string Phone { get; set; }
    public float GPA { get; set; }
    public DateTime DateOfBirth { get; set; }

    public static List<Student> load_data()
    {
        List<Student> students = new List<Student>();
        
        string filename = "studentList.txt";
        if(! File.Exists(filename)) {
            throw new Exception("Make sure you have the studentList.txt in this directory!");
        }

        string[] lines = File.ReadAllLines(filename);
        foreach ( string line in lines ) {
            var newStudent = new Student();
            string[] col = line.Split(',');
            newStudent.StudentID = int.Parse(col[0]);
            newStudent.FirstName = col[1];
            newStudent.LastName = col[2];
            newStudent.Major = col[3];
            newStudent.Phone = col[4];
            newStudent.GPA = float.Parse(col[5]);
            newStudent.DateOfBirth = DateTime.Parse(col[6]);
            students.Add(newStudent);
        }
        return students;
    }

    public static void Submit_Save(List<Student> allOfStudents, Student editedStudent)
    {
        List<string> editedStudentList = new List<string>();
        foreach (Student student_ in allOfStudents)
        {
            var student = new Student();
            if(student_.StudentID == editedStudent.StudentID)
                student = editedStudent;
            else
                student = student_;

            editedStudentList.Add(
                String.Format("{0},{1},{2},{3},", student.StudentID, student.FirstName, student.LastName, student.Major) +
                String.Format("{0},{1},{2}", student.Phone, student.GPA, student.DateOfBirth.ToShortDateString())
            );
        }
        try
        {
            File.WriteAllLines("studentList.txt", editedStudentList);
            Console.WriteLine("File Saved successfully!");
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("Some error has occured");
        }
    }
    
    public static void Save(List<Student> allOfStudents, Student newStudent)
    {
        allOfStudents.Add(newStudent);
        List<string> editedStudentList = new List<string>();
        foreach (Student student in allOfStudents)
        {
            editedStudentList.Add(
                String.Format("{0},{1},{2},{3},", student.StudentID, student.FirstName, student.LastName, student.Major) +
                String.Format("{0},{1},{2}", student.Phone, student.GPA, student.DateOfBirth.ToShortDateString())
            );
        }
        try
        {
            File.WriteAllLines("studentList.txt", editedStudentList);
            File.WriteAllText("currID.txt", IDGenerator.ToString());

            Console.WriteLine("File Saved successfully!");
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("Some error has occured");
        }
    }

    public static List<Student> Sort(List<Student> students, char sortBy)
    {
        List<Student> sortedStudents = new List<Student>();

        switch (sortBy)
        {
            case 'F':
                sortedStudents = students.OrderBy(s => s.FirstName).ToList();
                break;

            case 'L':
                sortedStudents = students.OrderBy(s => s.LastName).ToList();
                break;

            case 'G':
                sortedStudents = students.OrderByDescending(s => s.GPA).ToList();
                break;
        }
        
        return sortedStudents;
    }

    public static List<Student> FindStudent(List<Student> students, string query, string option)
    {
        List<Student> foundStudents = new List<Student>();
        switch (option)
        {
            case "ID":
            foundStudents = students.FindAll( s => s.StudentID == int.Parse(query));
            break;

            case "Major":
            foundStudents = students.FindAll( s => s.Major == query);
            break;

            case "GPA_H":
            foundStudents = students.FindAll( s => s.GPA >= int.Parse(query));
            break;

            case "GPA_L":
            foundStudents = students.FindAll( s => s.GPA <= int.Parse(query));
            break;
        }
        return foundStudents;
    }
}