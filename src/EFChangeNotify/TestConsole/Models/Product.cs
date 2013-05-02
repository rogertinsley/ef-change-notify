using System;
using System.Collections.Generic;

namespace TestConsole.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime LastEditDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
