using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class BasketItem
    {
        [Key]
        public string Id { get; set; }
        public string CartId { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
