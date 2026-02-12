using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySHop.Data;
using MySHop.Models;
using System.Runtime.CompilerServices;

namespace MySHop.pages.Admin
{
    public class AddModel : PageModel
    {
        MyShopContext _Context;
        public AddModel(MyShopContext context)
        {
            _Context = context; 
        }

        [BindProperty]
        public AddEditProductViewModel product { get; set; }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var item = new Item()
            {
                Price = product.Price,
                QuantityInStock = product.QuantityInStock
            };
            //_Context.Add(item);
            

            var pro = new Product()
            {
                Name = product.ProductName,
                item= item,
                Description = product.Description
            };
            _Context.Add(pro);
            _Context.SaveChanges();
            //pro.item.Id = pro.Id;
            //_Context.SaveChanges();

            if(product.Picture?.Length > 0)
            {
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                    pro.Id +Path.GetExtension(product.Picture.FileName));
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    product.Picture.CopyTo(stream);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
