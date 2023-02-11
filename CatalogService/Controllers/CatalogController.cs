using CatalogService.Database;
using CatalogService.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CatalogController:ControllerBase
    {
        private readonly AppDbContext _db;

        public CatalogController(AppDbContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var data = _db.Products.ToList();
            return data;
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            var data = _db.Categories.ToList();
            return data;
        }


        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            var data = _db.Products.Find(id);
            return data;
        }

        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            try
            {
                _db.Products.Add(model);
                _db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
