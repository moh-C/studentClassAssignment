using System;
using System.IO;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(id: 12, name: "Mammad");
            var order = new Order();
            customer.Orders.Add(order);
            System.Console.WriteLine(customer.ID);
            System.Console.WriteLine(customer.Name);
        }
    }
}