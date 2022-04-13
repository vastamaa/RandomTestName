#nullable disable

using System.Text.Json.Serialization;

namespace BackendTest.Models
{
    public partial class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public int ProductId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
