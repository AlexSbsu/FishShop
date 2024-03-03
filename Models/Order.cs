using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class Order
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]        
        public string Number { get; set; }

        [Required]
        [MaxLength(200)]
        public string Comment { get; set; }
        
        [Required]
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        
        [Required]
        public decimal TotalCost { get; set; }
        
        [Required]
        public string UserId { get; set; }

        [Required]        
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
