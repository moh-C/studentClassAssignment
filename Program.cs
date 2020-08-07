using System;
using System.IO;

class Student
{
    public int studentID {get; set;}
    public string Name { get; set; }
    public void setStudentID(){
        string filename = "currID.txt";
        int currID = Convert.ToInt32(File.ReadAllText(filename));
        Console.WriteLine(currID);
    }
}

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "text.txt";
            string[] lines = File.ReadAllLines( filename );
            foreach ( string line in lines )
            {
                string[] col = line.Split(',');
                foreach (var item in col)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n\n\n\n\n");
            }
        }
    }
}