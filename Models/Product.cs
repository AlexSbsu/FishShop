using System.ComponentModel.DataAnnotations;

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
        
        [Required]
        public string CategoryId { get; set; }
    }
}
