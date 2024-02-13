using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fish_Shop
{
    public class Product
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
                
        [MaxLength(50)]
        public string? ImageFile { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [MaxLength(10)]
        public string Units { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }

    public class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string? Surname { get; set; }
        public int? Age { get; set; }
        [MaxLength(20)]        
        public string? Patronymic { get; set; }        
        public List<Order>? Orders { get; set; } = new List<Order>();        
    }
    
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
        public readonly DateTime OrderDate  = DateTime.UtcNow;
        [Required]
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalCost { get; set; }
    }
}
