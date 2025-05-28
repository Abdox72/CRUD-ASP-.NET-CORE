using LAB_Assingment.Models;

namespace LAB_Assingment.Data
{
    public static class ApplicationDbContext
    {
        public static List<Product> ProductsRepo = new List<Product>()
        {
            new Product{
                ID = 1,
                Title = "Product 1",
                Description = "Description for Product 1",
                Price = 10.99M,
            },
            new Product{
                ID = 2,
                Title = "Product 2",
                Description = "Description for Product 2",
                Price = 20.99M,
            },
            new Product{
                ID = 3,
                Title = "Product 3",
                Description = "Description for Product 3",
                Price = 30.99M,
            }
        };


    }
}
