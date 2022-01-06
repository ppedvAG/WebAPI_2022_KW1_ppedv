using System.ComponentModel.DataAnnotations;

namespace WebAPISamples.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        public bool IsOnSale { get; set; }
    }
}
