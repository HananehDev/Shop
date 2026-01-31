using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySHop.Data;
using System.Runtime.Intrinsics.Arm;

namespace MySHop.Controllers
{
    public class ProductController : Controller
    {
        private MyShopContext _context;
        public ProductController(MyShopContext context)
        {
            _context = context; 
        }

        [Route ("Group/{id}/{name}")]
        public IActionResult ShowProductByGroup(int id , string name)
        {
            ViewData["GroupName"] = name;
            var products = _context.categoryToProducts
                .Where(c => c.CategoryId == id)
                .Include(p => p.Product)
                .Select(p => p.Product)
                .ToList();
            
            return View(products);
        }
    }
}
