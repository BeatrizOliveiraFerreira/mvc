using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using a.Models;

namespace a.Controllers
{
    public class CAsController : Controller
    {
        private readonly CO _context;

        public CAsController(CO context)
        {
            _context = context;
        }

        // GET: CAs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CAS.ToListAsync());
        }

        // GET: CAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cA = await _context.CAS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cA == null)
            {
                return NotFound();
            }

            return View(cA);
        }

        // GET: CAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] CA cA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cA);
        }

        // GET: CAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cA = await _context.CAS.FindAsync(id);
            if (cA == null)
            {
                return NotFound();
            }
            return View(cA);
        }

        // POST: CAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] CA cA)
        {
            if (id != cA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CAExists(cA.Id))
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
            return View(cA);
        }

        // GET: CAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cA = await _context.CAS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cA == null)
            {
                return NotFound();
            }

            return View(cA);
        }

        // POST: CAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cA = await _context.CAS.FindAsync(id);
            _context.CAS.Remove(cA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CAExists(int id)
        {
            return _context.CAS.Any(e => e.Id == id);
        }
    }
}
