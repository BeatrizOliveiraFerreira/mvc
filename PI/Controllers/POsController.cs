using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using a.Models;

namespace PI
{
    [Route("api/[controller]")]
    [ApiController]
    public class POsController : ControllerBase
    {
        private readonly CO _context;

        public POsController(CO context)
        {
            _context = context;
        }

        // GET: api/POs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PO>>> GetPOS()
        {
            return await _context.POS.Include("CA").ToListAsync();
        }

        // GET: api/POs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PO>> GetPO(int id)
        {
            var pO = await _context.POS.Include("CA").FirstOrDefaultAsync(x => x.Id == id);

            if (pO == null)
            {
                return NotFound();
            }

            return pO;
        }

        // PUT: api/POs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPO(int id, PO pO)
        {
            if (id != pO.Id)
            {
                return BadRequest();
            }

            _context.SetModified(pO);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/POs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PO>> PostPO(PO pO)
        {
            _context.POS.Add(pO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPO", new { id = pO.Id }, pO);
        }

        // DELETE: api/POs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PO>> DeletePO(int id)
        {
            var pO = await _context.POS.FindAsync(id);
            if (pO == null)
            {
                return NotFound();
            }

            _context.POS.Remove(pO);
            await _context.SaveChangesAsync();

            return pO;
        }

        private bool POExists(int id)
        {
            return _context.POS.Any(e => e.Id == id);
        }
    }
}
