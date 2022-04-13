using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BackendTest.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
