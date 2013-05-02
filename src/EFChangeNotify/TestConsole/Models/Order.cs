using System.Collections.Generic;

namespace TestConsole.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
