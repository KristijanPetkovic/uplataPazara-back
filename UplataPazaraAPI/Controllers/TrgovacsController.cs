#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UplataPazaraAPI.MsSqlDb;

namespace UplataPazaraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrgovacsController : ControllerBase
    {
        private readonly UplataDB _context;

        public TrgovacsController(UplataDB context)
        {
            _context = context;
        }

        // GET: api/Trgovacs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trgovac>>> GetTrgovacs()
        {
            return await _context.Trgovacs.ToListAsync();
        }

        // GET: api/Trgovacs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trgovac>> GetTrgovac(int id)
        {
            var trgovac = await _context.Trgovacs.FindAsync(id);

            if (trgovac == null)
            {
                return NotFound();
            }

            return trgovac;
        }

        // PUT: api/Trgovacs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrgovac(int id, Trgovac trgovac)
        {
            if (id != trgovac.TrgovacId)
            {
                return BadRequest();
            }

            _context.Entry(trgovac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrgovacExists(id))
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

        // POST: api/Trgovacs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trgovac>> PostTrgovac(Trgovac trgovac)
        {
            _context.Trgovacs.Add(trgovac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrgovac", new { id = trgovac.TrgovacId }, trgovac);
        }

        // DELETE: api/Trgovacs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrgovac(int id)
        {
            var trgovac = await _context.Trgovacs.FindAsync(id);
            if (trgovac == null)
            {
                return NotFound();
            }

            _context.Trgovacs.Remove(trgovac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrgovacExists(int id)
        {
            return _context.Trgovacs.Any(e => e.TrgovacId == id);
        }
    }
}
