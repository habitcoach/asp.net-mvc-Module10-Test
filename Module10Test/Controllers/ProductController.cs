using Microsoft.AspNetCore.Mvc;
using Module10Test.Models;
using Module10Test.Services;

namespace Module10Test.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductRepo _context;
        public ProductController(IProductRepo context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products);
        }

        public IActionResult Create(Product product)
        {
            return View(_context.Add(product));
        }
    }
}
