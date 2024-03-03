using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class OrderItem
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string ProductId { get; set; }

        [Required]        
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public decimal FullCost { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public Order Order { get; set; }
    }
}
