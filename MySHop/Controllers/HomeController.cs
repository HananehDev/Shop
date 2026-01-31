using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySHop.Data;
using MySHop.Models;

namespace MySHop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyShopContext _context; 
        private static Cart _cart = new Cart();

        public HomeController(ILogger<HomeController> logger , MyShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.products.ToList();
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = _context.products
                .Include(p => p.item)
                .SingleOrDefault(p=>p.Id==id);

            if(product == null)
            {
                return NotFound();
            }
            var categories = _context.products
                .Where(p=>p.Id == id)
                .SelectMany(c=> c.CategoryToProducts)
                .Select(ca=>ca.Category).ToList();

            var vm = new DetailsViewModel()
            {
                products = product
                ,
                categories = categories
            };


            return View(vm); 
        }

        public IActionResult AddToCart(int itemId)
        {
            var product = _context.products.Include(p => p.item)
                .SingleOrDefault(p => p.item.Id==itemId);
            
            if(product != null)
            {
                var CartItem = new CartItem()
                {
                    Item = product.item,
                    Quantity =1 

                };
                _cart.AddItem(CartItem);
            }
            return RedirectToAction("ShowCart"); 
        }

        public IActionResult RemoveCart(int itemId)
        {
            _cart.RemoveItem(itemId);
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart()
        {
            var cartVM = new CartViewModel()
            {
                CartItems = _cart.CartItems,
                TotalOrder = _cart.CartItems.Sum(c => c.GetTotalPrice())
            };
            return View(cartVM); 
        }

        [Route ("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
