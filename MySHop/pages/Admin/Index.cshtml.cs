using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySHop.Data;
using MySHop.Models;

namespace MySHop.pages.Admin
{
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class IndexModel : PageModel
    {
        private MyShopContext _context;
        public IndexModel(MyShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _context.products.Include(p => p.item).Include(p=>p.OrderDetail);
        }

        public void OnPost()
        {
        }
    }
}
