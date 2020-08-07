using System.Collections.Generic;

namespace myapp
{
    class Customer
    {
        public int ID;
        public string Name;
        public List<Order> Orders;
        public Customer()
        {
            Orders = new List<Order>();
        }
        public Customer(int id)
            : this()
        {
            this.ID = id;
        }
        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }
    }
}