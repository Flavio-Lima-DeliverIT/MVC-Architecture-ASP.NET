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
    public class ListaContaCadastradaDtoController : ControllerBase
    {
        private readonly ListaContaCadastradaContext _context;

        public ListaContaCadastradaDtoController(ListaContaCadastradaContext context)
        {
            _context = context;
        }

        // GET: api/ListaContaCadastradaDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaContaCadastradaDto>>> GetListaContaCadastradaDto()
        {
            return await _context.ListaContaCadastradaDto.ToListAsync();
        }

        // GET: api/ListaContaCadastradaDto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaContaCadastradaDto>> GetListaContaCadastradaDto(int id)
        {
            var listaContaCadastradaDto = await _context.ListaContaCadastradaDto.FindAsync(id);

            if (listaContaCadastradaDto == null)
            {
                return NotFound();
            }

            return listaContaCadastradaDto;
        }

        // PUT: api/ListaContaCadastradaDto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaContaCadastradaDto(int id, ListaContaCadastradaDto listaContaCadastradaDto)
        {
            if (id != listaContaCadastradaDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(listaContaCadastradaDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaContaCadastradaDtoExists(id))
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

        // POST: api/ListaContaCadastradaDto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ListaContaCadastradaDto>> PostListaContaCadastradaDto(ListaContaCadastradaDto listaContaCadastradaDto)
        {
            _context.ListaContaCadastradaDto.Add(listaContaCadastradaDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListaContaCadastradaDto", new { id = listaContaCadastradaDto.Id }, listaContaCadastradaDto);
        }

        // DELETE: api/ListaContaCadastradaDto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ListaContaCadastradaDto>> DeleteListaContaCadastradaDto(int id)
        {
            var listaContaCadastradaDto = await _context.ListaContaCadastradaDto.FindAsync(id);
            if (listaContaCadastradaDto == null)
            {
                return NotFound();
            }

            _context.ListaContaCadastradaDto.Remove(listaContaCadastradaDto);
            await _context.SaveChangesAsync();

            return listaContaCadastradaDto;
        }

        private bool ListaContaCadastradaDtoExists(int id)
        {
            return _context.ListaContaCadastradaDto.Any(e => e.Id == id);
        }
    }
}
