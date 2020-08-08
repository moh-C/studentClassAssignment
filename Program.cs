using System;
using System.IO;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = new Point(40, 30);
            System.Console.WriteLine("{0}, {1}", point.X, point.Y);
            point.Move(new Point(20, 10));
            System.Console.WriteLine("{0}, {1}", point.X, point.Y);
        }
    }
}