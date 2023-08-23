using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcLuat.Data;
using MvcLuat.Models;
using System.Data;

namespace MvcLuat.Controllers
{
    public class AdminController : Controller
    {

        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }
        //public IActionResult Index2(int? id)
        //{
        //    if (id == null)
        //    {
        //        return View(_context.Sections.ToList());
        //    }
        //    return View((_context.Sections.ToList().Where(m => m.ArticleID == id)));
        //}
        //public IActionResult Index()
        //{
        //    return RedirectToAction("Index","Account");
        //}
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.Value1 = _context.Sections.ToList();
            }
            else
            {
                ViewBag.Value1 = _context.Sections.ToList().Where(m => m.ArticleID == id);
            }
            return View();
        }

        // GET: Sections/Create
        public IActionResult SectionCreate()
        {
            ViewData["ArticleID"] = new SelectList(_context.Articles, "ID", "ID");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionCreate([Bind("ID,Title,Content,Min,Max,Avg,CreateTime,UpdateTime,ArticleID,DecreeID")] Section section)
        {
            if (ModelState.IsValid)
            {
                _context.Add(section);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Account");
            }
            ViewData["ArticleID"] = new SelectList(_context.Articles, "ID", "ID", section.ArticleID);
            return View(section);
        }
        // GET: Sections/Edit/5
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> SectionEdit(int? id)
        {
            if (id == null || _context.Sections == null)
            {
                return NotFound();
            }

            var section = await _context.Sections.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            ViewData["ArticleID"] = new SelectList(_context.Articles, "ID", "ID", section.ArticleID);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionEdit(int id, [Bind("ID,Title,Content,Min,Max,Avg,CreateTime,UpdateTime,ArticleID,DecreeID")] Section section)
        {
            if (id != section.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(section);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(section.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {id = section.ArticleID});
            }
            ViewData["ArticleID"] = new SelectList(_context.Articles, "ID", "ID", section.ArticleID);
            return View(section);
        }
        // GET: Sections/Delete/5
        public async Task<IActionResult> SectionDelete(int? id)
        {
            if (id == null || _context.Sections == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Article)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("SectionDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sections == null)
            {
                return Problem("Entity set 'MyDbContext.Sections'  is null.");
            }
            var section = await _context.Sections.FindAsync(id);
            if (section != null)
            {
                _context.Sections.Remove(section);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = section.ArticleID });
        }


        // GET: Chapters/Edit/5
        public async Task<IActionResult> ChapterEdit(int? id)
        {
            if (id == null || _context.Chapters == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }
            return View(chapter);
        }

        // POST: Chapters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChapterEdit(int id, [Bind("ID,Title,Content,CreateTime,UpdateTime,Decree")] Chapter chapter)
        {
            if (id != chapter.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chapter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChapterExists(chapter.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","Account");
            }
            return View(chapter);
        }
        // GET: Chapters/Delete/5
        public async Task<IActionResult> ChapterDelete(int? id)
        {
            if (id == null || _context.Chapters == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chapter == null)
            {
                return NotFound();
            }

            return View(chapter);
        }

        // POST: Chapters/Delete/5
        [HttpPost, ActionName("ChapterDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChapterDeleteConfirmed(int id)
        {
            if (_context.Chapters == null)
            {
                return Problem("Entity set 'MyDbContext.Chapters'  is null.");
            }
            var chapter = await _context.Chapters.FindAsync(id);
            if (chapter != null)
            {
                _context.Chapters.Remove(chapter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Account");
        }
        // GET: Articles/Edit/5
        public async Task<IActionResult> ArticleEdit(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["ChapterID"] = new SelectList(_context.Chapters, "ID", "ID", article.ChapterID);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArticleEdit(int id, [Bind("ID,Title,Content,CreateTime,UpdateTime,ChapterID")] Article article)
        {
            if (id != article.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Account");
            }
            ViewData["ChapterID"] = new SelectList(_context.Chapters, "ID", "ID", article.ChapterID);
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> ArticleDelete(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Chapter)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("ArticleDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArticleDeleteConfirmed(int id)
        {
            if (_context.Articles == null)
            {
                return Problem("Entity set 'MyDbContext.Articles'  is null.");
            }
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Account");
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            // Truy xuất dữ liệu về các hành vi, khung xử phạt, mức xử phạt và thẩm quyền xử phạt từ nguồn dữ liệu của bạn
            List<Section> contents = _context.Sections.Where(a => a.Content.Contains(searchQuery)).ToList();
            ViewBag.Value1 = searchQuery;
            ViewBag.Value2 = contents;
            return View();
        }
        private bool ArticleExists(int id)
        {
            return (_context.Articles?.Any(e => e.ID == id)).GetValueOrDefault();
        }
        private bool SectionExists(int id)
        {
            return (_context.Sections?.Any(e => e.ID == id)).GetValueOrDefault();
        }
        private bool ChapterExists(int id)
        {
            return (_context.Chapters?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
