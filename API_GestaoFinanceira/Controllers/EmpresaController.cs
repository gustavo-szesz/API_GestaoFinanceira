using API_GestaoFinanceira.Dtos;
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
            var empresa = await _context.Empresas
                                        .Include(e => e.PessoasAssociadas)
                                        .FirstOrDefaultAsync(e => e.Cnpj == cnpj);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }


        [HttpPatch("{cnpj}/associar-a-pessoa")]
        public async Task<IActionResult> AssociarEmpresa(string cnpj, int pessoaId)
        {
            var pessoa = await _context.Pessoas.FindAsync(pessoaId);
            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            var empresa = await _context.Empresas.Include(e => e.PessoasAssociadas)
                                                 .FirstOrDefaultAsync(e => e.Cnpj == cnpj);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            // Verifica se a empresa já possui essa pessoa associada
            var empresaPessoa = empresa.PessoasAssociadas.FirstOrDefault(ep => ep.PessoaId == pessoaId);

            if (empresaPessoa == null)
            {
                // Se não existir, cria uma nova associação
                empresa.PessoasAssociadas ??= new List<EmpresaPessoa>();
                empresa.PessoasAssociadas.Add(new EmpresaPessoa { Cnpj = cnpj, PessoaId = pessoaId });
            }
            else
            {
                // Se existir, apenas atualiza
                empresaPessoa.PessoaId = pessoaId;
            }

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPatch("{cnpj}/remover-pessoa-da-empresa")]
        public async Task<IActionResult> RemoverPessoaDaEmpresa(string cnpj, int pessoaId)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == pessoaId);
            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            var empresa = await _context.Empresas.Include(e => e.PessoasAssociadas)
                                                 .FirstOrDefaultAsync(e => e.Cnpj == cnpj);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            var associacao = empresa.PessoasAssociadas.FirstOrDefault(pa => pa.PessoaId == pessoaId);
            if (associacao == null)
            {
                return NotFound("Pessoa não está associada a esta empresa.");
            }

            // Remove a pessoa da lista de associados da empresa
            empresa.PessoasAssociadas.Remove(associacao);

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            return NoContent();
        }





        [HttpPut("{cnpj}")]
        public async Task<IActionResult> PutEmpresa(string cnpj, EmpresaUpdateDto empresaDto)
        {
            var empresa = await _context.Empresas.FindAsync(cnpj);
            if (empresa == null)
            {
                return NotFound();
            }

            empresa.RazaoSocial = empresaDto.RazaoSocial ?? empresa.RazaoSocial;
            empresa.NomeFantasia = empresaDto.NomeFantasia ?? empresa.NomeFantasia;
            empresa.InscricaoMunicipal = empresaDto.InscricaoMunicipal ?? empresa.InscricaoMunicipal;
            empresa.InscricaoEstadual = empresaDto.InscricaoEstadual ?? empresa.InscricaoEstadual;
            empresa.DataAbertura = empresaDto.DataAbertura ?? empresa.DataAbertura;
            empresa.PessoaId = empresaDto.PessoaId ?? empresa.PessoaId;

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
        public async Task<IActionResult> PostEmpresa(Empresa empresa)
        {
            try
            {
                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEmpresa), new { cnpj = empresa.Cnpj }, empresa);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao criar a empresa: " + ex.Message);
            }
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
