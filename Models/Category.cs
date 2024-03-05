using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class Category
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
