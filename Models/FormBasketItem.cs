using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class FormBasketItem
    {        
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
    }
}
