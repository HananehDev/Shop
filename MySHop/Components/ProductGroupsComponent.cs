using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySHop.Data;
using MySHop.Models;

namespace MySHop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private MyShopContext _context;

        public ProductGroupsComponent(MyShopContext Context)
        {
            _context = Context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _context.Categories
                .Select(c => new ShowGroupViewModel()
                {
                    GruopId = c.Id,
                    GroupName = c.Title,
                    ProductCount = _context.categoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();
            return View("/Views/Component/ProductGroupsComponent.cshtml", categories);   
        }
    }
}
