using System.ComponentModel.DataAnnotations;

namespace MvcLuat.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public string? Email { get; set; }
        public int Mobile { get; set; }
        public string? Role { get; set; }

    }
}
