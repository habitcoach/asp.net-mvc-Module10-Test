using System.ComponentModel.DataAnnotations;

namespace Module10Test.Models
{
    public class Product
    {
        [Required]
        public string Name { get; set; }
        
        public int Id { get; set; }

        [Required]
        public float BasePrice { get; set; }
    }
}
