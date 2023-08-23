using System.ComponentModel.DataAnnotations;

namespace MvcLuat.Models
{
    public class Section
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Min { set; get; }
        public string? Max { set; get; }
        public string? Avg { set; get; }
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateTime { get; set; }
        public int ArticleID { get; set; }
        public int DecreeID { set; get; }
        public virtual Article? Article { get; set; }

    }
}
