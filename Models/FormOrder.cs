using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class FormOrder
    {
        [Required]
        [MaxLength(200)]
        public string Comment { get; set; }

        [Required]
        public decimal TotalCost { get; set; }
        
        [Required]
        public List<FormBasketItem> BasketItems { get; set; }
    }
}
