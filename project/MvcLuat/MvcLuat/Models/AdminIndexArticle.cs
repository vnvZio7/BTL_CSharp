using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcLuat.Data;

namespace MvcLuat.Models
{
    public class AdminIndexArticle : ViewComponent
    {
        private readonly MyDbContext _context;

        public AdminIndexArticle(MyDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int? id)
        {
            return View(_context.Articles.ToList().Where(m=>m.ChapterID == id));
        }
    }
}
