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
    public class UplatasController : ControllerBase
    {
        private readonly UplataDB _context;

        public UplatasController(UplataDB context)
        {
            _context = context;
        }

        // GET: api/Uplatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uplatum>>> GetUplata()
        {
            return await _context.Uplata.ToListAsync();
        }

        // GET: api/Uplatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uplatum>> GetUplatum(int id)
        {
            var uplatum = await _context.Uplata.FindAsync(id);

            if (uplatum == null)
            {
                return NotFound();
            }

            return uplatum;
        }

        // PUT: api/Uplatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUplatum(int id, Uplatum uplatum)
        {
            if (id != uplatum.UplataId)
            {
                return BadRequest();
            }

            _context.Entry(uplatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UplatumExists(id))
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

        // POST: api/Uplatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Uplatum>> PostUplatum(Uplatum uplatum)
        {
            _context.Uplata.Add(uplatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUplatum", new { id = uplatum.UplataId }, uplatum);
        }

        // DELETE: api/Uplatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUplatum(int id)
        {
            var uplatum = await _context.Uplata.FindAsync(id);
            if (uplatum == null)
            {
                return NotFound();
            }

            _context.Uplata.Remove(uplatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UplatumExists(int id)
        {
            return _context.Uplata.Any(e => e.UplataId == id);
        }
    }
}
