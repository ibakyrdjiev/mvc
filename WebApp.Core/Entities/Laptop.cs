using System.ComponentModel.DataAnnotations;

namespace WebApp.Core.Entities
{
    public class Laptop : Entity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Make { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }
    }
}