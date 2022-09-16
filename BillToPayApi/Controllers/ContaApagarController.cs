using BillToPayApi.Models.Entities;
using BillToPayApi.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillToPayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaApagarController : ControllerBase
    {
        private readonly IContaApagarService service;

        public ContaApagarController(IContaApagarService _service)
        {
           service = _service;
        }

        // GET: api/ContaApagar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaApagar>>> GetContaApagar()
        {
            var result = service.GetContaApagar();
            return   Ok(result);
        }

        // GET: api/ContaApagar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaApagar>> GetContaApagar(int id)
        {
            var contaApagar = service.BuscarContaApagar(id);
             
            if (contaApagar == null)
            {
                return NotFound();
            }

            return Ok(contaApagar);
        }

        // POST: api/ContaApagar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContaApagar>> PostContaApagar(ContaApagar conta)
        {
            service.InserirContaApagar(conta);
            service.CalcularContaAtrasada(conta); // em teste
           
            return CreatedAtAction("GetContaApagar", new { id = conta.Id }, conta);
        }

       // DELETE: api/ContaApagar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContaApagar>> DeleteContaApagar(int id)
        {
            bool removido = service.Remover(id);

            if (removido == false)
            {
                return NotFound();
            }

            return Ok();
        }


    }
}
