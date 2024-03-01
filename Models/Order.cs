using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class Order
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();        
        
        [Required]
        [MaxLength(200)]
        public string Comment { get; set; }
        
        [Required]
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        
        [Required]
        public decimal TotalCost { get; set; }
        
        [Required]

        public readonly DateTime OrderDate = DateTime.UtcNow;

        [Required]
        public string UserId { get; set; }
    }
}
