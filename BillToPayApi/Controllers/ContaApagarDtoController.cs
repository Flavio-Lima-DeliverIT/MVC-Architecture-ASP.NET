using BillToPayApi.Models;
using BillToPayApi.Models.DTOs;
using BillToPayApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

       

        // POST: api/ContaApagarDto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContaApagarDto>> PostContaApagarDto(ContaApagarDto contaApagarDto)
        {
            var atraso = (contaApagarDto.DataPagamento - contaApagarDto.DataVencimento);

            if (atraso.Days > 0 && atraso.Days <= 3)
            {
                contaApagarDto.ValorOriginal += Convert.ToDecimal(((2 * contaApagarDto.ValorOriginal) / 100) + (atraso.Days * (1 / 10)));
                contaApagarDto.ValorOriginal = decimal.Round(contaApagarDto.ValorOriginal, 2, MidpointRounding.ToEven);
            }

            if (atraso.Days > 3 && atraso.Days <= 5)
            {
                contaApagarDto.ValorOriginal += Convert.ToDecimal(((3 * contaApagarDto.ValorOriginal) / 100) + (atraso.Days * (2 / 10)));
                contaApagarDto.ValorOriginal = decimal.Round(contaApagarDto.ValorOriginal, 2, MidpointRounding.ToEven);
            }

            if (atraso.Days > 5)
            {
                contaApagarDto.ValorOriginal += Convert.ToDecimal(((5 * contaApagarDto.ValorOriginal) / 100) + (atraso.Days * (3 / 10)));
                contaApagarDto.ValorOriginal = decimal.Round(contaApagarDto.ValorOriginal, 2, MidpointRounding.ToEven);
            }
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
