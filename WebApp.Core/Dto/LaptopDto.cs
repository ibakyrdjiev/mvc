using System.ComponentModel.DataAnnotations;

namespace WebApp.Core.Dto
{
    public class LaptopDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(20)]
        public string Make { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}