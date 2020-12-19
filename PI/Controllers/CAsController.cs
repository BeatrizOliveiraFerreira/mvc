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
    public class CAsController : ControllerBase
    {
        private readonly CO _context;

        public CAsController(CO CO)
        {
            _context = CO;
        }

        // GET: api/CAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CA>>> GetCAS()
        {
            return await _context.CAS.ToListAsync();
        }

        // GET: api/CAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CA>> GetCA(int id)
        {
            var cA = await _context.CAS.FindAsync(id);


            if (cA == null)
            {
                return NotFound();
            }

            return cA;
        }

        // PUT: api/CAs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCA(int id, CA cA)

        {
            if (id != cA.Id)
            {
                return BadRequest();
            }

            _context.Entry(cA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAExists(id))
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

        // POST: api/CAs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CA>> PostCA(CA cA)
        {
            _context.CAS.Add(cA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCA", new { id = cA.Id }, cA);
        }

        // DELETE: api/CAs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CA>> DeleteCA(int id)
        {
            var cA = await _context.CAS.FindAsync(id);
            if (cA == null)
            {
                return NotFound();
            }

            _context.CAS.Remove(cA);
            await _context.SaveChangesAsync();

            return cA;
        }

        private bool CAExists(int id)
        {
            return _context.CAS.Any(e => e.Id == id);
        }
    }
}



// O comentário XML ausente para tipo publicamente visível ou membro "CAS
