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
    public class POsController : Controller
    {
        private readonly CO _context;

        public POsController(CO context)
        {
            _context = context;
        }

        // GET: POs
        public async Task<IActionResult> Index()
        {
            var cO = _context.POS.Include(p => p.CA);
            return View(await cO.ToListAsync());
        }

        // GET: POs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pO = await _context.POS
                .Include(p => p.CA)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pO == null)
            {
                return NotFound();
            }

            return View(pO);
        }

        // GET: POs/Create
        public IActionResult Create()
        {
            ViewData["CAId"] = new SelectList(_context.CAS, "Id", "Descricao");
            return View();
        }

        // POST: POs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Quantidade,CAId")] PO pO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CAId"] = new SelectList(_context.CAS, "Id", "Descricao", pO.CAId);
            return View(pO);
        }

        // GET: POs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pO = await _context.POS.FindAsync(id);
            if (pO == null)
            {
                return NotFound();
            }
            ViewData["CAId"] = new SelectList(_context.CAS, "Id", "Descricao", pO.CAId);
            return View(pO);
        }

        // POST: POs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Quantidade,CAId")] PO pO)
        {
            if (id != pO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!POExists(pO.Id))
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
            ViewData["CAId"] = new SelectList(_context.CAS, "Id", "Descricao", pO.CAId);
            return View(pO);
        }

        // GET: POs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pO = await _context.POS
                .Include(p => p.CA)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pO == null)
            {
                return NotFound();
            }

            return View(pO);
        }

        // POST: POs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pO = await _context.POS.FindAsync(id);
            _context.POS.Remove(pO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool POExists(int id)
        {
            return _context.POS.Any(e => e.Id == id);
        }
    }
}
