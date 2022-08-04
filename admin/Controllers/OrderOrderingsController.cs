using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using admin.Models;
using X.PagedList;

namespace admin.Controllers
{
    public class OrderOrderingsController : Controller
    {
        private readonly LockerLuckContext _context;

        public OrderOrderingsController(LockerLuckContext context)
        {
            _context = context;
        }

        // GET: OrderOrderings
        public async Task<IActionResult> Index(int ? page=1)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //var lockerLuckContext = _context.OrderOrderings.Include(o => o.訂單);
            //return View(await lockerLuckContext.ToListAsync());
            return View(_context.OrderOrderings.ToPagedList(pageNumber, pageSize));
        }

        // GET: OrderOrderings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderOrderings == null)
            {
                return NotFound();
            }

            var orderOrdering = await _context.OrderOrderings
                .Include(o => o.訂單)
                .FirstOrDefaultAsync(m => m.No == id);
            if (orderOrdering == null)
            {
                return NotFound();
            }

            return View(orderOrdering);
        }

        // GET: OrderOrderings/Create
        public IActionResult Create()
        {
            ViewData["訂單id"] = new SelectList(_context.OrderInfos, "訂單id", "訂單id");
            return View();
        }

        // POST: OrderOrderings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("訂單id,商品id快照,子項id快照,商品名稱快照,子項名稱快照,商品主圖快照,子項獨立編號,長快照,寬快照,高快照,啟用日期,停用日期,商品郵遞區號快照,商品地址快照,Is買方取消,Is賣方取消,No")] OrderOrdering orderOrdering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderOrdering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["訂單id"] = new SelectList(_context.OrderInfos, "訂單id", "訂單id", orderOrdering.訂單id);
            return View(orderOrdering);
        }

        // GET: OrderOrderings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderOrderings == null)
            {
                return NotFound();
            }

            var orderOrdering = await _context.OrderOrderings.FindAsync(id);
            if (orderOrdering == null)
            {
                return NotFound();
            }
            ViewData["訂單id"] = new SelectList(_context.OrderInfos, "訂單id", "訂單id", orderOrdering.訂單id);
            return View(orderOrdering);
        }

        // POST: OrderOrderings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("訂單id,商品id快照,子項id快照,商品名稱快照,子項名稱快照,商品主圖快照,子項獨立編號,長快照,寬快照,高快照,啟用日期,停用日期,商品郵遞區號快照,商品地址快照,Is買方取消,Is賣方取消,No")] OrderOrdering orderOrdering)
        {
            if (id != orderOrdering.No)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderOrdering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderOrderingExists(orderOrdering.No))
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
            ViewData["訂單id"] = new SelectList(_context.OrderInfos, "訂單id", "訂單id", orderOrdering.訂單id);
            return View(orderOrdering);
        }

        // GET: OrderOrderings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderOrderings == null)
            {
                return NotFound();
            }

            var orderOrdering = await _context.OrderOrderings
                .Include(o => o.訂單)
                .FirstOrDefaultAsync(m => m.No == id);
            if (orderOrdering == null)
            {
                return NotFound();
            }

            return View(orderOrdering);
        }

        // POST: OrderOrderings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderOrderings == null)
            {
                return Problem("Entity set 'LockerLuckContext.OrderOrderings'  is null.");
            }
            var orderOrdering = await _context.OrderOrderings.FindAsync(id);
            if (orderOrdering != null)
            {
                _context.OrderOrderings.Remove(orderOrdering);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderOrderingExists(int id)
        {
          return (_context.OrderOrderings?.Any(e => e.No == id)).GetValueOrDefault();
        }
    }
}
