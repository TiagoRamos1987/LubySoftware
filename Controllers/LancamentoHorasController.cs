using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LubySoftware.Models;

namespace LubySoftware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoHorasController : ControllerBase
    {
        private readonly LancamentoHorasContext _context;

        public LancamentoHorasController(LancamentoHorasContext context)
        {
            _context = context;
        }

        // GET: api/LancamentoHoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LancamentoHoras>>> GetLubySoftware()
        {
            return await _context.LubySoftware.ToListAsync();
        }

        // GET: api/LancamentoHoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LancamentoHoras>> GetLancamentoHoras(long id)
        {
            var lancamentoHoras = await _context.LubySoftware.FindAsync(id);

            if (lancamentoHoras == null)
            {
                return NotFound();
            }

            return lancamentoHoras;
        }

        // PUT: api/LancamentoHoras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLancamentoHoras(long id, LancamentoHoras lancamentoHoras)
        {
            if (id != lancamentoHoras.Id)
            {
                return BadRequest();
            }

            _context.Entry(lancamentoHoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancamentoHorasExists(id))
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

        // POST: api/LancamentoHoras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LancamentoHoras>> PostLancamentoHoras(LancamentoHoras lancamentoHoras)
        {
            _context.LubySoftware.Add(lancamentoHoras);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetLancamentoHoras", new { id = lancamentoHoras.Id }, lancamentoHoras);
            return CreatedAtAction(nameof(GetLancamentoHoras), new { id = lancamentoHoras.Id }, lancamentoHoras);
        }

        // DELETE: api/LancamentoHoras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LancamentoHoras>> DeleteLancamentoHoras(long id)
        {
            var lancamentoHoras = await _context.LubySoftware.FindAsync(id);
            if (lancamentoHoras == null)
            {
                return NotFound();
            }

            _context.LubySoftware.Remove(lancamentoHoras);
            await _context.SaveChangesAsync();

            return lancamentoHoras;
        }

        private bool LancamentoHorasExists(long id)
        {
            return _context.LubySoftware.Any(e => e.Id == id);
        }
    }
}
