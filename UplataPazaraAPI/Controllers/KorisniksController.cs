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
    public class KorisniksController : ControllerBase
    {
        private readonly UplataDB _context;

        public KorisniksController(UplataDB context)
        {
            _context = context;
        }

        // GET: api/Korisniks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korisnik>>> GetKorisniks()
        {
            return await _context.Korisniks.ToListAsync();
        }

        // GET: api/Korisniks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Korisnik>> GetKorisnik(int id)
        {
            var korisnik = await _context.Korisniks.FindAsync(id);

            if (korisnik == null)
            {
                return NotFound();
            }

            return korisnik;
        }

        //Custom metoda za pronalaznje korisnika po imenu
        // GET: api/Korisniks/GetKorisnikByName/test1
        [HttpGet("GetKorisnikByName/{username}")]
        public async Task<ActionResult<Korisnik>> GetKorisnikByName(string username)
        {
            var korisnik =_context.Korisniks.FirstOrDefault(acc => acc.KorisnickoIme.Equals(username));

            if (korisnik == null)
            {
                return NotFound();
            }

            return korisnik;
        }

        // PUT: api/Korisniks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKorisnik(int id, Korisnik korisnik)
        {
            if (id != korisnik.KorisnikId)
            {
                return BadRequest();
            }

            _context.Entry(korisnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(id))
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

        // POST: api/Korisniks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Korisnik>> PostKorisnik(Korisnik korisnik)
        {
            _context.Korisniks.Add(korisnik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKorisnik", new { id = korisnik.KorisnikId }, korisnik);
        }

        // DELETE: api/Korisniks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnik(int id)
        {
            var korisnik = await _context.Korisniks.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            _context.Korisniks.Remove(korisnik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KorisnikExists(int id)
        {
            return _context.Korisniks.Any(e => e.KorisnikId == id);
        }
    }
}
