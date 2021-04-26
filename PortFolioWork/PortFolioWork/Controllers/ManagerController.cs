using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortFolioWork.Data;
using PortFolioWork.Models;

namespace PortFolioWork.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manager
        public async Task<IActionResult> Index()
        {
            return View(await _context.Managers.ToListAsync());
        }

        // GET: Manager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managers == null)
            {
                return NotFound();
            }

            return View(managers);
        }

        // GET: Manager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cate,Subject,Contents,RegDate")] Managers managers)
        {
            if (ModelState.IsValid)
            {
                managers.RegDate = DateTime.Now;
                _context.Add(managers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(managers);
        }

        // GET: Manager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers.FindAsync(id);
            if (managers == null)
            {
                return NotFound();
            }
            return View(managers);
        }

        // POST: Manager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cate,Subject,Contents,RegDate")] Managers managers)
        {
            if (id != managers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(managers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagersExists(managers.Id))
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
            return View(managers);
        }

        // GET: Manager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managers == null)
            {
                return NotFound();
            }

            return View(managers);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var managers = await _context.Managers.FindAsync(id);
            _context.Managers.Remove(managers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagersExists(int id)
        {
            return _context.Managers.Any(e => e.Id == id);
        }
    }
}
