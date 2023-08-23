using System.ComponentModel.DataAnnotations;

namespace MvcLuat.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateTime { get; set; }
        public int ChapterID { get; set;}
        public virtual Chapter? Chapter { get; set; }
        public virtual ICollection<Section>? Sections { get; set; }  


    }
}
