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
        public async Task<ActionResult<Pessoa>> GetPessoa(string email)
        {
            var pessoa = await _context.Pessoa.FindAsync(email);

            if (pessoa == null) { 
                return NotFound();
            }

            return pessoa;
        }
    }
}
