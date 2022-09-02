using BillToPayApi.Models;
using BillToPayApi.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillToPayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaApagarDtoController : ControllerBase
    {
        private readonly ContaApagarContext _context;

        public ContaApagarDtoController(ContaApagarContext context)
        {
            _context = context;
        }

        // GET: api/ContaApagarDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaApagarDto>>> GetContaApagarDto()
        {
            return await _context.ContaApagarDto.ToListAsync();
        }

        // GET: api/ContaApagarDto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaApagarDto>> GetContaApagarDto(int id)
        {
            var contaApagarDto = await _context.ContaApagarDto.FindAsync(id);

            if (contaApagarDto == null)
            {
                return NotFound();
            }

            return contaApagarDto;
        }

        // PUT: api/ContaApagarDto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContaApagarDto(int id, ContaApagarDto contaApagarDto)
        {
            if (id != contaApagarDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(contaApagarDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaApagarDtoExists(id))
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

        // POST: api/ContaApagarDto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContaApagarDto>> PostContaApagarDto(ContaApagarDto contaApagarDto)
        {
            _context.ContaApagarDto.Add(contaApagarDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContaApagarDto", new { id = contaApagarDto.Id }, contaApagarDto);
        }

        // DELETE: api/ContaApagarDto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContaApagarDto>> DeleteContaApagarDto(int id)
        {
            var contaApagarDto = await _context.ContaApagarDto.FindAsync(id);
            if (contaApagarDto == null)
            {
                return NotFound();
            }

            _context.ContaApagarDto.Remove(contaApagarDto);
            await _context.SaveChangesAsync();

            return contaApagarDto;
        }

        private bool ContaApagarDtoExists(int id)
        {
            return _context.ContaApagarDto.Any(e => e.Id == id);
        }
    }
}
