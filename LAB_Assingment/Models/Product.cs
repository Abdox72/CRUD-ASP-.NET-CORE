using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_Assingment.Models
{
    public class Product
    {
        [DisplayName("Product ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [DisplayName("Product Title")]
        [MaxLength(30)]
        [MinLength(3)]
        public required string Title { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [Precision(18, 2)]
        [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1,000,000.")]
        public decimal Price{ get; set; }

        public string? Image{ get; set; }
    }
}
