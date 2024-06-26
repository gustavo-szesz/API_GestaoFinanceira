using API_GestaoFinanceira.Dtos;
using API_GestaoFinanceira.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_GestaoFinanceira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public PessoaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            return await _context.Pessoas.ToListAsync();    
        }

        // Método para pesquisar uma pessoa pelo email
        [HttpGet("{email}")]
        public async Task<ActionResult<Pessoa>> GetPessoaByEmail(string email)
        {
            var pessoa = await _context.Pessoas
                                       .Include(p => p.Enderecos)
                                       .Include(p => p.Usuarios)
                                       .Include(p => p.Empresas)
                                       .FirstOrDefaultAsync(p => p.Email == email);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        [HttpPost]
        public async Task<IActionResult> PostPessoa(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPessoas), new { id = pessoa.Id }, pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao criar pessoa" + ex.Message);
            }
        }



        private bool PessoaExists(string email) {
            return _context.Pessoas.Any(e => e.Email == email);
        }

        // Método para atualizar uma pessoa pelo email
        [HttpPut("{email}")]
        public async Task<IActionResult> UpdatePessoaByEmail(string email, UpdatePessoaDto updatedPessoaDto)
        {
            if (email != updatedPessoaDto.CurrentEmail)
            {
                return BadRequest("The current email in the URL does not match the email in the request body.");
            }

            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Email == email);

            if (pessoa == null)
            {
                return NotFound();
            }

            // Atualizar os campos necessários
            pessoa.Email = updatedPessoaDto.NewEmail ?? pessoa.Email;
            pessoa.Complemento = updatedPessoaDto.Complemento;
            pessoa.Numero = updatedPessoaDto.Numero;
            pessoa.Telefone = updatedPessoaDto.Telefone;
            pessoa.DataCadastro = updatedPessoaDto.DataCadastro;

            try
            {
                _context.Entry(pessoa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pessoas.Any(p => p.Id == pessoa.Id))
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



        // Método para deletar uma pessoa pelo email
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeletePessoaByEmail(string email)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Email == email);

            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
