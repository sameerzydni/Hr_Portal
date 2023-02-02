using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr_Portal.Models;

namespace Hr_Portal.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public async Task<IActionResult> Index()
        {
              return _context.Logins != null ? 
                          View(await _context.Logins.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Logins'  is null.");
        }

        // GET: Login/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Logins == null)
            {
                return NotFound();
            }

            var loginModel = await _context.Logins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginModel == null)
            {
                return NotFound();
            }

            return View(loginModel);
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password")] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginModel);
        }

        // GET: Login/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Logins == null)
            {
                return NotFound();
            }

            var loginModel = await _context.Logins.FindAsync(id);
            if (loginModel == null)
            {
                return NotFound();
            }
            return View(loginModel);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password")] LoginModel loginModel)
        {
            if (id != loginModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginModelExists(loginModel.Id))
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
            return View(loginModel);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Logins == null)
            {
                return NotFound();
            }

            var loginModel = await _context.Logins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginModel == null)
            {
                return NotFound();
            }

            return View(loginModel);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Logins == null)
            {
                return Problem("Entity set 'AppDbContext.Logins'  is null.");
            }
            var loginModel = await _context.Logins.FindAsync(id);
            if (loginModel != null)
            {
                _context.Logins.Remove(loginModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginModelExists(int id)
        {
          return (_context.Logins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
