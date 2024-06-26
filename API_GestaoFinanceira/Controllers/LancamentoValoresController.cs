using API_GestaoFinanceira.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_GestaoFinanceira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoValoresController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public LancamentoValoresController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LancamentoValores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LancamentoValores>>> GetLancamentoValores()
        {
            return await _context.LancamentoValores.ToListAsync();
        }

        // GET: api/LancamentoValores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LancamentoValores>> GetLancamentoValores(int id)
        {
            var lancamentoValores = await _context.LancamentoValores.FindAsync(id);

            if (lancamentoValores == null)
            {
                return NotFound();
            }

            return lancamentoValores;
        }

        // PUT: api/LancamentoValores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLancamentoValores(int id, LancamentoValores lancamentoValores)
        {
            if (id != lancamentoValores.Id)
            {
                return BadRequest();
            }

            _context.Entry(lancamentoValores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancamentoValoresExists(id))
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

        // POST: api/LancamentoValores
        [HttpPost]
        public async Task<ActionResult<LancamentoValores>> PostLancamentoValores(LancamentoValores lancamentoValores)
        {
            // Verifica se a empresa existe pelo CNPJ fornecido
            var empresa = await _context.Empresas.FindAsync(lancamentoValores.EmpresaCnpj);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            // Associa a empresa ao lançamento de valores
            lancamentoValores.Empresa = empresa;

            // Adiciona o lançamento de valores ao contexto e salva no banco de dados
            _context.LancamentoValores.Add(lancamentoValores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLancamentoValores", new { id = lancamentoValores.Id }, lancamentoValores);
        }


        // DELETE: api/LancamentoValores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLancamentoValores(int id)
        {
            var lancamentoValores = await _context.LancamentoValores.FindAsync(id);
            if (lancamentoValores == null)
            {
                return NotFound();
            }

            _context.LancamentoValores.Remove(lancamentoValores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LancamentoValoresExists(int id)
        {
            return _context.LancamentoValores.Any(e => e.Id == id);
        }
    }
}
