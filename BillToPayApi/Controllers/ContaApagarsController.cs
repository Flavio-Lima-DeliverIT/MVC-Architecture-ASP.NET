using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillToPayApi.Models;

namespace BillToPayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaApagarsController : ControllerBase
    {
        private readonly ContaApagarContext _context;

        public ContaApagarsController(ContaApagarContext context)
        {
            _context = context;
        }

        // GET: api/ContaApagars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaApagar>>> GetContaApagar()
        {
            return await _context.ContaApagar.ToListAsync();
        }

        // GET: api/ContaApagars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaApagar>> GetContaApagar(int id)
        {
            var contaApagar = await _context.ContaApagar.FindAsync(id);

            if (contaApagar == null)
            {
                return NotFound();
            }

            return contaApagar;
        }

        // PUT: api/ContaApagars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContaApagar(int id, ContaApagar contaApagar)
        {
            if (id != contaApagar.Id)
            {
                return BadRequest();
            }

            _context.Entry(contaApagar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaApagarExists(id))
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

        // POST: api/ContaApagars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContaApagar>> PostContaApagar(ContaApagar contaApagar)
        {
            _context.ContaApagar.Add(contaApagar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContaApagar", new { id = contaApagar.Id }, contaApagar);
        }

        // DELETE: api/ContaApagars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContaApagar>> DeleteContaApagar(int id)
        {
            var contaApagar = await _context.ContaApagar.FindAsync(id);
            if (contaApagar == null)
            {
                return NotFound();
            }

            _context.ContaApagar.Remove(contaApagar);
            await _context.SaveChangesAsync();

            return contaApagar;
        }

        private bool ContaApagarExists(int id)
        {
            return _context.ContaApagar.Any(e => e.Id == id);
        }
    }
}
