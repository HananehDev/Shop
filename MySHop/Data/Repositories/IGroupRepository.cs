using MySHop.Models;

namespace MySHop.Data.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowGroupViewModel> GetGroupForShow();

    }

    public class GroupRepository : IGroupRepository
    {
        private MyShopContext _context;
        public GroupRepository(MyShopContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {
            return _context.Categories
                .Select(c => new ShowGroupViewModel()
                {
                    GruopId = c.Id,
                    GroupName = c.Title,
                    ProductCount = _context.categoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();
        }
    }
}
