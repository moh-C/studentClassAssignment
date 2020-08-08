using System;
using System.IO;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookie = new HttpCookie();
            cookie["name"] = "Mammad";
            System.Console.WriteLine(cookie["name"]);
            System.Console.WriteLine(cookie.name);
        }
    }
}