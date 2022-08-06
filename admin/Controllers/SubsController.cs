using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using admin.Models;
using X.PagedList;
using System.Linq;

namespace admin.Controllers
{
    public class SubsController : Controller
    {
        private readonly LockerLuckContext _context;

        public SubsController(LockerLuckContext context)
        {
            _context = context;
        }

        // GET: Subs
        public async Task<IActionResult> Index(string sortOrder, string searchString, int? page = 1)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var subs = from s in _context.Subs
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                subs = _context.Subs.Where(s => s.子項名稱.Contains(searchString) || s.子項單價.ToString().Contains(searchString)); ;
            }

            switch (sortOrder)
            {
                case "name_desc":
                    subs = subs.OrderByDescending(s => s.子項名稱);
                    break;
                case "Date":
                    subs = subs.OrderBy(s => s.創建時間);
                    break;
                case "date_desc":
                    subs = subs.OrderByDescending(s => s.創建時間);
                    break;
                default:
                    subs = subs.OrderBy(s => s.子項名稱);
                    break;
            }



            return View( subs.ToPagedList(pageNumber, pageSize));
        }

        //public async Task<IActionResult> Index(int? page = 1)
        //{
        //    //var lockerLuckContext = _context.Subs.Include(s => s.商品);
        //    //return View(await lockerLuckContext.ToListAsync());

        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    return View(_context.Subs.ToPagedList(pageNumber, pageSize));
        //}



        // GET: Subs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Subs == null)
            {
                return NotFound();
            }

            var sub = await _context.Subs
                .Include(s => s.商品)
                .FirstOrDefaultAsync(m => m.子項id == id);
            if (sub == null)
            {
                return NotFound();
            }

            return View(sub);
        }

        // GET: Subs/Create
        public IActionResult Create()
        {
            ViewData["商品id"] = new SelectList(_context.Items, "商品id", "商品id");
            return View();
        }

        // POST: Subs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("子項id,商品id,子項名稱,子項主圖,子項簡述,子項數量,子項單價,長,寬,高,創建時間,Is啟用,Is刪除")] Sub sub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["商品id"] = new SelectList(_context.Items, "商品id", "商品id", sub.商品id);
            return View(sub);
        }

        // GET: Subs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Subs == null)
            {
                return NotFound();
            }

            var sub = await _context.Subs.FindAsync(id);
            if (sub == null)
            {
                return NotFound();
            }
            ViewData["商品id"] = new SelectList(_context.Items, "商品id", "商品id", sub.商品id);
            return View(sub);
        }

        // POST: Subs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("子項id,商品id,子項名稱,子項主圖,子項簡述,子項數量,子項單價,長,寬,高,創建時間,Is啟用,Is刪除")] Sub sub)
        {
            if (id != sub.子項id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubExists(sub.子項id))
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
            ViewData["商品id"] = new SelectList(_context.Items, "商品id", "商品id", sub.商品id);
            return View(sub);
        }

        // GET: Subs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Subs == null)
            {
                return NotFound();
            }

            var sub = await _context.Subs
                .Include(s => s.商品)
                .FirstOrDefaultAsync(m => m.子項id == id);
            if (sub == null)
            {
                return NotFound();
            }

            return View(sub);
        }

        // POST: Subs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Subs == null)
            {
                return Problem("Entity set 'LockerLuckContext.Subs'  is null.");
            }
            var sub = await _context.Subs.FindAsync(id);
            if (sub != null)
            {
                _context.Subs.Remove(sub);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubExists(string id)
        {
          return (_context.Subs?.Any(e => e.子項id == id)).GetValueOrDefault();
        }
    }
}
