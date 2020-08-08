using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public Student()
    {
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

    private int IDGenerator;
    public int StudentID { get; set; }
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
                sortedStudents = students.OrderBy(s => s.GPA).ToList();
                break;
        }
        
        return sortedStudents;
    }
}