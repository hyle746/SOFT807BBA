
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBA.Data;
using BBA.Models;

namespace BBA.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BooksController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
              return _context.Book != null ? 
                          View(await _context.Book.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Book'  is null.");
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Authorize("UserName")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("UserName")]
        public async Task<IActionResult> Create(BookView bm)
        {
            string FileName = UploadFile(bm);
            var book = new Book
            {
                BookID = bm.BookID,
                BookImage = FileName,
                Title = bm.Title,
                Author = bm.Author,
                Publisher = bm.Publisher,
                Genre = bm.Genre,
                Description = bm.Description
            };
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        private string UploadFile(BookView bm)
        {
            string file = null;
            if (bm.BookImage != null)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                file = Guid.NewGuid().ToString() + "-" + bm.BookImage.FileName;
                string filePath = Path.Combine(uploadDir, file);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    bm.BookImage.CopyTo(fileStream);
                }
            }
            return file;
        }

        // GET: Books/Edit/5
        [Authorize("UserName")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("UserName")]
        public async Task<IActionResult> Edit(int id, BookView bm)
        {
            string FileName = UploadFile(bm);
            var book = new Book
            {
                BookID = bm.BookID,
                BookImage = FileName,
                Title = bm.Title,
                Author = bm.Author,
                Publisher = bm.Publisher,
                Genre = bm.Genre,
                Description = bm.Description
            };

            if (id != book.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize("UserName")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("UserName")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Book'  is null.");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.Book?.Any(e => e.BookID == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> SearchResults(string SearchPhrase)
        {
            if (SearchPhrase == null)
            {
                return View("Index", await _context.Book.ToListAsync());
            }
            else
            {
                return View("Index", await _context.Book
                    .Where(x => x.Title.Contains(SearchPhrase) || x.Author.Contains(SearchPhrase) || x.Publisher.Contains(SearchPhrase) || x.Genre.Contains(SearchPhrase))
                    .ToListAsync());
            }
        }
    }
}
