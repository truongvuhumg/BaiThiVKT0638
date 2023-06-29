using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThiVKT.Models;
using BaiThiVKT.Models.Process;

namespace BaiThiVKT.Controllers
{
    public class VKTCau3Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        
        StringProcess StrPro = new StringProcess();

        public VKTCau3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VKTCau3
        public async Task<IActionResult> Index()
        {
              return _context.VKTCau3 != null ? 
                          View(await _context.VKTCau3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.VKTCau3'  is null.");
        }

        // GET: VKTCau3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VKTCau3 == null)
            {
                return NotFound();
            }

            var vKTCau3 = await _context.VKTCau3
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (vKTCau3 == null)
            {
                return NotFound();
            }

            return View(vKTCau3);
        }

        // GET: VKTCau3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VKTCau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName,Gender")] VKTCau3 vKTCau3)
        {
            if (ModelState.IsValid)
            {
                vKTCau3.StudentName =StrPro.AddToUpper(vKTCau3.StudentName);
                _context.Add(vKTCau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vKTCau3);
        }

        // GET: VKTCau3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VKTCau3 == null)
            {
                return NotFound();
            }

            var vKTCau3 = await _context.VKTCau3.FindAsync(id);
            if (vKTCau3 == null)
            {
                return NotFound();
            }
            return View(vKTCau3);
        }

        // POST: VKTCau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentID,StudentName,Gender")] VKTCau3 vKTCau3)
        {
            if (id != vKTCau3.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vKTCau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VKTCau3Exists(vKTCau3.StudentID))
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
            return View(vKTCau3);
        }

        // GET: VKTCau3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VKTCau3 == null)
            {
                return NotFound();
            }

            var vKTCau3 = await _context.VKTCau3
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (vKTCau3 == null)
            {
                return NotFound();
            }

            return View(vKTCau3);
        }

        // POST: VKTCau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VKTCau3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VKTCau3'  is null.");
            }
            var vKTCau3 = await _context.VKTCau3.FindAsync(id);
            if (vKTCau3 != null)
            {
                _context.VKTCau3.Remove(vKTCau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VKTCau3Exists(string id)
        {
          return (_context.VKTCau3?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
