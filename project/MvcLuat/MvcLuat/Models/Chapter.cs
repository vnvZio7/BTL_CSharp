using System.ComponentModel.DataAnnotations;

namespace MvcLuat.Models
{
    public class Chapter
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateTime { get; set; }
        public int Decree { get; set; }
        public virtual ICollection<Article>? Articles { get; set; }
    }
}
