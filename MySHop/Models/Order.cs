using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySHop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]  
        public int UserId { get; set; }
        [Required]  
        public DateTime CreateDate { get; set; }
        public bool IsFinally { get; set; }

        //navigation property
        [ForeignKey("UserId")]
        public Users User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } 
    }
}
