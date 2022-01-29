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
    public class KurirsController : ControllerBase
    {
        private readonly UplataDB _context;

        public KurirsController(UplataDB context)
        {
            _context = context;
        }

        // GET: api/Kurirs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kurir>>> GetKurirs()
        {
            return await _context.Kurirs.ToListAsync();
        }

        // GET: api/Kurirs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kurir>> GetKurir(int id)
        {
            var kurir = await _context.Kurirs.FindAsync(id);

            if (kurir == null)
            {
                return NotFound();
            }

            return kurir;
        }

        // PUT: api/Kurirs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKurir(int id, Kurir kurir)
        {
            if (id != kurir.KurirId)
            {
                return BadRequest();
            }

            _context.Entry(kurir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KurirExists(id))
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

        // POST: api/Kurirs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kurir>> PostKurir(Kurir kurir)
        {
            _context.Kurirs.Add(kurir);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKurir", new { id = kurir.KurirId }, kurir);
        }

        // DELETE: api/Kurirs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKurir(int id)
        {
            var kurir = await _context.Kurirs.FindAsync(id);
            if (kurir == null)
            {
                return NotFound();
            }

            _context.Kurirs.Remove(kurir);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KurirExists(int id)
        {
            return _context.Kurirs.Any(e => e.KurirId == id);
        }
    }
}
