using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class BasketItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public decimal FullCost { get; set; }

        [Required]
        public string OrderId { get; set; }
    }
}
