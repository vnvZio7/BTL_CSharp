namespace MvcLuat.Models
{
    public class MyViewModel
    {
        public Chapter? Chapter { get; set; }
        public Article? Article { get; set; }
        public IEnumerable<MvcLuat.Models.Article>? Articles { get; set; }

        public IEnumerable<MvcLuat.Models.Section>? Sections { get; set; }


    }
}
