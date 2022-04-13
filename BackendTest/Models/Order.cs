using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BackendTest.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PaidAt { get; set; }
        public int CustomerId { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
