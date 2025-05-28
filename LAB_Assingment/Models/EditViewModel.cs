namespace LAB_Assingment.Models
{
    public class EditViewModel
    {
            public int ID { get; set; }
            public required string Title { get; set; }
            public string? Description { get; set; }
            public decimal Price { get; set; }
            //public file
            public IFormFile? Image { get; set; }
    }
}
