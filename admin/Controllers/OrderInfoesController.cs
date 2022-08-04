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
    public class OrderInfoesController : Controller
    {
        private readonly LockerLuckContext _context;

        public OrderInfoesController(LockerLuckContext context)
        {
            _context = context;
        }

        // GET: OrderInfoes
        public async Task<IActionResult> Index(int ? page =1)
           
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //return _context.OrderInfos != null ? 
            //              View(await _context.OrderInfos.ToListAsync()) :
            //              Problem("Entity set 'LockerLuckContext.OrderInfos'  is null.");
            return View(_context.OrderInfos.ToPagedList(pageNumber, pageSize));
        }

        // GET: OrderInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.OrderInfos == null)
            {
                return NotFound();
            }

            var orderInfo = await _context.OrderInfos
                .FirstOrDefaultAsync(m => m.訂單id == id);
            if (orderInfo == null)
            {
                return NotFound();
            }

            return View(orderInfo);
        }

        // GET: OrderInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("訂單id,付款金額,創建時間,下單id,訂單留言,付款方式,折扣代碼,折扣數據,付款id")] OrderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderInfo);
        }

        // GET: OrderInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.OrderInfos == null)
            {
                return NotFound();
            }

            var orderInfo = await _context.OrderInfos.FindAsync(id);
            if (orderInfo == null)
            {
                return NotFound();
            }
            return View(orderInfo);
        }

        // POST: OrderInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("訂單id,付款金額,創建時間,下單id,訂單留言,付款方式,折扣代碼,折扣數據,付款id")] OrderInfo orderInfo)
        {
            if (id != orderInfo.訂單id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderInfoExists(orderInfo.訂單id))
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
            return View(orderInfo);
        }

        // GET: OrderInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.OrderInfos == null)
            {
                return NotFound();
            }

            var orderInfo = await _context.OrderInfos
                .FirstOrDefaultAsync(m => m.訂單id == id);
            if (orderInfo == null)
            {
                return NotFound();
            }

            return View(orderInfo);
        }

        // POST: OrderInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.OrderInfos == null)
            {
                return Problem("Entity set 'LockerLuckContext.OrderInfos'  is null.");
            }
            var orderInfo = await _context.OrderInfos.FindAsync(id);
            if (orderInfo != null)
            {
                _context.OrderInfos.Remove(orderInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderInfoExists(string id)
        {
          return (_context.OrderInfos?.Any(e => e.訂單id == id)).GetValueOrDefault();
        }
    }
}
