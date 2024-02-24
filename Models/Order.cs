using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class Order
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string UserId { get; set; }
        
        [Required]
        public User User { get; set; }

        public string Address { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        public readonly DateTime OrderDate = DateTime.UtcNow;
        
        [Required]
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalCost { get; set; }
    }
}
