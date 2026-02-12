using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySHop.Data;
using MySHop.Models;

namespace MySHop.pages.Admin
{
    public class EditModel : PageModel
    {
        private MyShopContext _context;
        public EditModel(MyShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel product { get; set; }
        public void OnGet(int id)
        {
            product = _context.products.Include(p => p.item)
                .Where(p => p.Id == id)
                .Select(s => new AddEditProductViewModel()
                {
                    Id = s.Id,
                    ProductName = s.Name,
                    Description = s.Description,
                    QuantityInStock = s.item.QuantityInStock,
                    Price = s.item.Price,
                }).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            //var productt = _context.products.Find(product.Id);
            //var itemm = _context.Items.First(p => p.Id ==productt.item.Id);
            var productt = _context.products
                       .Include(p => p.item)
                       .FirstOrDefault(p => p.Id == product.Id);
            var itemm = productt.item;


            productt.Name = product.ProductName;
            productt.Description = product.Description;
            itemm.Price = product.Price;
            itemm.QuantityInStock = product.QuantityInStock;

            _context.SaveChanges();

            if (product.Picture?.Length > 0)
            {
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                    productt.Id + Path.GetExtension(product.Picture.FileName));
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    product.Picture.CopyTo(stream);
                }
            }
            
            return RedirectToPage("Index");
        }
    }
}
