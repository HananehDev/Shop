using Microsoft.Build.Execution;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySHop.Models
{
    public class OrderDetail
    {
        [Key]
        public int DetailId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        public int Count { get; set; }

        //
        public Order order { get; set; }

        [ForeignKey("ProductID")]
        public Product product { get; set; }
    }
}
