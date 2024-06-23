using API_GestaoFinanceira.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GestaoFinanceira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public EmpresaController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        // GET: api/Empresas/5
        [HttpGet("{cnpj}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(string cnpj)
        {
            var empresa = await _context.Empresas.FindAsync(cnpj);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        // PUT: api/Empresas/5
        [HttpPut("{cnpj}")]
        public async Task<IActionResult> PutEmpresa(string cnpj, Empresa empresa)
        {
            if (cnpj != empresa.Cnpj)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(cnpj))
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

        // POST: api/Empresas
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpresaExists(empresa.Cnpj))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpresa", new { cnpj = empresa.Cnpj }, empresa);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{cnpj}")]
        public async Task<IActionResult> DeleteEmpresa(string cnpj)
        {
            var empresa = await _context.Empresas.FindAsync(cnpj);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaExists(string cnpj)
        {
            return _context.Empresas.Any(e => e.Cnpj == cnpj);
        }
    }
}
