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
    public class UsersController : Controller
    {
        private readonly LockerLuckContext _context;

        public UsersController(LockerLuckContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string sortOrder, string searchString, int? page = 1)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var Users = from s in _context.Users
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Users = _context.Users.Where(s => s.姓名.Contains(searchString) || s.地址.Contains(searchString)); ;
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Users = Users.OrderByDescending(s => s.姓名);
                    break;
                case "Date":
                    Users = Users.OrderBy(s => s.註冊時間);
                    break;
                case "date_desc":
                    Users = Users.OrderByDescending(s => s.註冊時間);
                    break;
                default:
                    Users = Users.OrderBy(s => s.姓名);
                    break;
            }

            return View( Users.ToPagedList(pageNumber, pageSize));
        }


        //public async Task<IActionResult> Index()
        //{
        //    
        //    //return _context.Users != null ? 
        //    //              View(await _context.Users.ToListAsync()) :
        //    //              Problem("Entity set 'LockerLuckContext.Users'  is null.");
        //    return View(await_context.Users.ToPagedList();
        //}


        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.會員id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("會員id,會員帳號,會員密碼,頭像檔名,姓名,暱稱,Email,郵遞區號,地址,電話,註冊時間,帳號權限,資料更新時間,Is啟用,Is刪除,違規次數,備註")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("會員id,會員帳號,會員密碼,頭像檔名,姓名,暱稱,Email,郵遞區號,地址,電話,註冊時間,帳號權限,資料更新時間,Is啟用,Is刪除,違規次數,備註")] User user)
        {
            if (id != user.會員id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.會員id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.會員id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'LockerLuckContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
          return (_context.Users?.Any(e => e.會員id == id)).GetValueOrDefault();
        }
    }
}
