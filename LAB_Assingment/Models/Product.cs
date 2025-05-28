namespace LAB_Assingment.Models
{
    public class Product
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price{ get; set; }
        //public file
        public string? Image{ get; set; }
    }
}
