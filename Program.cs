using System;
using System.IO;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            int firstOne = calculator.Add(1,2,3);
            int secondOne = calculator.Add(new int[] {1,20,3});
            System.Console.WriteLine("{0}, {1}", firstOne, secondOne);

            
            static void usePoint()
            {
                try
                {
                    var point = new Point(40, 30);
                    System.Console.WriteLine("{0}, {1}", point.X, point.Y);
                    point.Move(null);
                    System.Console.WriteLine("{0}, {1}", point.X, point.Y);
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Some err happened!");
                    //throw;
                }
            }
        }
    }
}