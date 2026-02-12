using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySHop.Data;
using MySHop.Models;

namespace MySHop.pages.Admin
{
    public class DeleteModel : PageModel
    {
        private MyShopContext _context;
        public DeleteModel(MyShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product product { get; set; }
        public void OnGet(int id)
        {
            product = _context.products.Include(p => p.item).FirstOrDefault(p => p.Id == id);     
        }

        public IActionResult OnPost()
        {
            var productt = _context.products
                      .Include(p => p.item)
                      .FirstOrDefault(p => p.Id == product.Id);
            if (productt == null)
                return RedirectToPage("Index");

            if (productt.item != null)
                _context.Items.Remove(productt.item);

            _context.products.Remove(productt);
            _context.SaveChanges();

            string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                   "wwwroot",
                   "Images",
                   productt.Id + "jpg");
            if (System.IO.File.Exists(FilePath))
            {
                System.IO.File.Delete(FilePath);
            }

            return RedirectToPage("Index");

        }
       
    }
}
