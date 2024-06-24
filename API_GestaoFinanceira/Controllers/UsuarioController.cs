using API_GestaoFinanceira.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_GestaoFinanceira.Dtos;
using System;
using System.Threading.Tasks;

namespace API_GestaoFinanceira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public UsuariosController(AplicationDbContext context)
        {
            _context = context;
        }

        //Corrigir

        [HttpGet("{cpf}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string cpf)
        {
            var usuario = await _context.Usuarios.FindAsync(cpf);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
        
        /// <summary>
        ///       Isso foi um delirio
        /// </summary>
        /// <returns></returns>

        //private Usuario MapUserObject(UsuarioDto payload)
        //{
        //    var result = new Usuario();
        //    result.Cpf = payload.Cpf;
        //    result.Nome = payload.Nome;
        //    result.Rg = payload.Rg;
        //    result.DataNascimento = payload.DataNascimento;
        //    result.EstadoCivil = payload.EstadoCivil;
        //    result.Senha = payload.Senha;
        //    result.empresa = new List<Empresa>();
        //    payload.empresa.ForEach(_ =>
        //    {
        //        var newEmpresa = new Empresa();
        //        newEmpresa.RazaoSocial = _.RazaoSocial;
        //        newEmpresa.NomeFantasia = _.NomeFantasia;
        //        newEmpresa.InscricaoMunicipal = _.InscricaoMunicipal;
        //        newEmpresa.InscricaoEstadual = _.InscricaoEstadual;
        //        //newEmpresa = _.DataAbertura;
        //        result.empresa.Add(newEmpresa);

        //    });
        //    return result;
        //}


        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            // Configura todos os campos de data para UTC
            if (usuario.DataNascimento.HasValue)
            {
                usuario.DataNascimento = DateTime.SpecifyKind(usuario.DataNascimento.Value, DateTimeKind.Utc);
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Created($"/Usuario/{usuario.Cpf}", usuario);
        }


        [HttpPatch("{cpf}/associar-empresa")]
        public async Task<IActionResult> AssociarEmpresa(string cpf, int empresaId)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Cpf == cpf);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var empresa = await _context.Empresas.FindAsync(empresaId);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            usuario.EmpresaId = empresaId;
            await _context.SaveChangesAsync();

            return NoContent();
        }




        private bool UsuarioExists(string cpf)
        {
            return _context.Usuarios.Any(u => u.Cpf == cpf);
        }


        // PUT: api/Usuarios/{cpf}
        [HttpPut("{cpf}")]
        public async Task<IActionResult> PutUsuario(string cpf, Usuario usuario)
        {
            if (cpf != usuario.Cpf)
            {
                return BadRequest("O CPF informado não corresponde ao CPF do usuário.");
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UsuarioExists(cpf))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
            // Criar mensagem ao atualizar base
            return NoContent();
        }

        // DELETE: api/Usuarios/{cpf}
        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeleteUsuario(string cpf)
        {
            var usuario = await _context.Usuarios.FindAsync(cpf);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            //Criar mensagem ao atualizar base

            return NoContent();
        }


    }
}
