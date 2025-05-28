using LAB_Assingment.Data;
using LAB_Assingment.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace LAB_Assingment.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult Index()
        {
            return View(Data.ApplicationDbContext.ProductsRepo);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Title, string Description, decimal Price, IFormFile Image )
        {
            Product product = new Product
            {
                ID = Data.ApplicationDbContext.ProductsRepo.Count + 1, 
                Title = Title,
                Description = Description,
                Price = Price,
            };
            if (Image != null && Image.Length > 0)
            {
                var filePath = Path.Combine("/images", Image.FileName);
                using (var stream = new FileStream(Directory.GetCurrentDirectory() + "/wwwroot" + filePath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }
                product.Image = filePath; 
            }
            else
            {
                return BadRequest("Image file is required.");
            }
            Data.ApplicationDbContext.ProductsRepo.Add(product);
            return Redirect("/Product/Index");
        }

        public RedirectResult Delete(int id)
        {
            Data.ApplicationDbContext.ProductsRepo.RemoveAll(p => p.ID == id);
            return Redirect("/Product/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product? product = ApplicationDbContext.ProductsRepo.FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return NotFound() ;
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(EditViewModel? _product)
        {
            Product? product = ApplicationDbContext.ProductsRepo.FirstOrDefault(p => p.ID == _product?.ID);
            if (product == null)
            {
                return NotFound() ;
            }
            if (_product?.Image != null && _product.Image.Length > 0)
            {
                var filePath = Path.Combine("/images",_product.Image.FileName);
                using (var stream = new FileStream(Directory.GetCurrentDirectory()+"/wwwroot"+filePath, FileMode.Create))
                {
                    _product.Image.CopyTo(stream);
                }
                product.Image = filePath;
            }
            else
            {
                return BadRequest("Image file is required.");
            }
            if (_product != null)
            {
                product.Title = _product.Title;
                product.Description = _product.Description;
                product.Price = _product.Price;
            }
            else
            {
                return BadRequest("Product data is invalid.");
            }
            return Redirect("/Product/Index");
        }
    }
}
