using Microsoft.AspNetCore.Mvc;
using MvcLuat.Data;

namespace MvcLuat.Models
{
    public class AdminIndexChapter : ViewComponent
    {
        private readonly MyDbContext _context;

        public AdminIndexChapter(MyDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Chapters.ToList());        
        }
    }
}
