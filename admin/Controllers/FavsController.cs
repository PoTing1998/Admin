using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using admin.Models;

namespace admin.Controllers
{
    public class FavsController : Controller
    {
        private readonly LockerLuckContext _context;

        public FavsController(LockerLuckContext context)
        {
            _context = context;
        }

        // GET: Favs
        public async Task<IActionResult> Index()
        {
            var lockerLuckContext = _context.Favs.Include(f => f.商品).Include(f => f.會員);
            return View(await lockerLuckContext.ToListAsync());
        }

        // GET: Favs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Favs == null)
            {
                return NotFound();
            }

            var fav = await _context.Favs
                .Include(f => f.商品)
                .Include(f => f.會員)
                .FirstOrDefaultAsync(m => m.商品id == id);
            if (fav == null)
            {
                return NotFound();
            }

            return View(fav);
        }

        // GET: Favs/Create
        public IActionResult Create()
        {
            ViewData["商品id"] = new SelectList(_context.Items, "商品id", "商品id");
            ViewData["會員id"] = new SelectList(_context.Users, "會員id", "會員id");
            return View();
        }

        // POST: Favs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("商品id,會員id,No")] Fav fav)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fav);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["商品id"] = new SelectList(_context.Items, "商品id", "商品id", fav.商品id);
            ViewData["會員id"] = new SelectList(_context.Users, "會員id", "會員id", fav.會員id);
            return View(fav);
        }

        // GET: Favs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Favs == null)
            {
                return NotFound();
            }

            var fav = await _context.Favs.FindAsync(id);
            if (fav == null)
            {
                return NotFound();
            }
            ViewData["商品id"] = new SelectList(_context.Items, "商品id", "商品id", fav.商品id);
            ViewData["會員id"] = new SelectList(_context.Users, "會員id", "會員id", fav.會員id);
            return View(fav);
        }

        // POST: Favs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("商品id,會員id,No")] Fav fav)
        {
            if (id != fav.商品id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fav);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavExists(fav.商品id))
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
            ViewData["商品id"] = new SelectList(_context.Items, "商品id", "商品id", fav.商品id);
            ViewData["會員id"] = new SelectList(_context.Users, "會員id", "會員id", fav.會員id);
            return View(fav);
        }

        // GET: Favs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Favs == null)
            {
                return NotFound();
            }

            var fav = await _context.Favs
                .Include(f => f.商品)
                .Include(f => f.會員)
                .FirstOrDefaultAsync(m => m.商品id == id);
            if (fav == null)
            {
                return NotFound();
            }

            return View(fav);
        }

        // POST: Favs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Favs == null)
            {
                return Problem("Entity set 'LockerLuckContext.Favs'  is null.");
            }
            var fav = await _context.Favs.FindAsync(id);
            if (fav != null)
            {
                _context.Favs.Remove(fav);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavExists(string id)
        {
          return (_context.Favs?.Any(e => e.商品id == id)).GetValueOrDefault();
        }
    }
}
