using System.ComponentModel.DataAnnotations;

namespace MySHop.Models
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public IFormFile Picture { get; set; }

    }
}
