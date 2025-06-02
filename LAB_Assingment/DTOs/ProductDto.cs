using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LAB_Assingment.DTOs
{
    public class ProductDto
    {
        public int ID { get; set; }
        [MaxLength(30)]
        [MinLength(3)]
        public required string Title { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1,000,000.")]
        public decimal Price { get; set; }
        public IFormFile? Image { get; set; }
    }
}