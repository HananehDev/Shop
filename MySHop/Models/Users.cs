using System.ComponentModel.DataAnnotations;

namespace MySHop.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password  { get; set; }
        [Required]
        [MaxLength(300)]
        public string Email { get; set; }
        [Required]
        public DateTime DateRegister { get; set; }
        public bool IsAdmin { get; set; }
        
    }
}
