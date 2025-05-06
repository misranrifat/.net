using System.ComponentModel.DataAnnotations;

namespace DotNetApi.DTOs
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }
    }
} 