using Microsoft.AspNetCore.Mvc;
using MvcLuat.Data;

namespace MvcLuat.Models
{
    public class indexChapter : ViewComponent
    {
        private readonly MyDbContext _context;

        public indexChapter(MyDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Chapters.ToList());        
        }
    }
}
