using LAB_Assingment.Data;
using LAB_Assingment.DTOs;
using LAB_Assingment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using static System.Net.Mime.MediaTypeNames;

namespace LAB_Assingment.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext DbContext;
        public ProductController(ApplicationDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public ViewResult Index()
        {
            return View(DbContext.Products.ToList());
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductDto _product)
        {
            try
            {

            Product product = new Product
            {
                ID = _product.ID, 
                Title = _product.Title,
                Description = _product.Description,
                Price = _product.Price,
            };
            if (_product.Image != null && _product.Image.Length > 0)
            {
                var filePath = Path.Combine("/images", _product.Image.FileName);
                using (var stream = new FileStream(Directory.GetCurrentDirectory() + "/wwwroot" + filePath, FileMode.Create))
                {
                    _product.Image.CopyTo(stream);
                }
                product.Image = filePath; 
            }
            else
            {
                return BadRequest("Image file is required.");
            }
            DbContext.Products.Add(product);
            DbContext.SaveChanges();
            return Redirect("/Product/Index");

            }
            catch(Exception ex)
            {
                return BadRequest("An error occurred while creating the product: " + ex.Message);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                DbContext.Products.Remove(DbContext.Products.Find(id));
                DbContext.SaveChanges();
                return Redirect("/Product/Index");
            }
            catch(Exception ex)
            {
                return BadRequest("An error occurred while Deleting the product: " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product? product = DbContext.Products.FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return NotFound() ;
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductDto? _product)
        {
            try
            {
                Product? product = DbContext.Products.FirstOrDefault(p => p.ID == _product.ID);
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
                DbContext.SaveChanges();
                return Redirect("/Product/Index");
            }
            catch(Exception ex)
            {
                return BadRequest("An error occurred while editing the product: " + ex.Message);
            }
        }
    }
}
