using System.Collections.Generic;

namespace myapp
{
    class Order
    {

    }
    class Customer
    {
        public int id;
        public string Name;
        public readonly List<Order> orders = new List<Order>();

        public Customer(int id)
        {
            this.id = id;
        }
        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {
            //this.orders = new List<Order>();
        }
    }
}