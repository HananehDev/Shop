using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.products.Include(p => p.item)
                .SingleOrDefault(p => p.item.Id==itemId);
            
            if(product != null)
            {
               
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.orders.FirstOrDefault(o => o.UserId==userId && !o.IsFinally);
                if(order != null)
                {
                    var orderDetail = _context.ordersDetails.FirstOrDefault(d  => d.OrderId==order.OrderId && d.ProductID ==product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.ordersDetails.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductID = product.Id,
                            price = product.item.Price,
                            Count = 1
                        });
                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinally = false,
                        CreateDate = DateTime.Now,
                        UserId = userId
                    };
                    _context.orders.Add(order);
                    _context.SaveChanges();
                    _context.ordersDetails.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductID = product.Id,
                        price=product.item.Price,
                        Count =1
                    });
                }
                _context.SaveChanges();
            }
            return RedirectToAction("ShowCart"); 
        }

        [Authorize]
        public IActionResult RemoveCart(int DetailId)
        {
            var orederDetail = _context.ordersDetails.Find(DetailId);
            _context.Remove(orederDetail);
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public IActionResult ShowCart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.orders.Where(o =>o.UserId==userId && !o.IsFinally)
                .Include(o=>o.OrderDetails)
                .ThenInclude(o=> o.product)
                .FirstOrDefault();
            return View(order);
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
