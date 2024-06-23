using API_GestaoFinanceira.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{cpf}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string cpf)
        {
            var usuario = await _context.Usuario.FindAsync(cpf);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }


        [HttpPost]
        public async Task<IActionResult> PostUsuario(Usuario usuario)
        {
            try
            {
                // Verifica se já existe um usuário com o CPF informado
                var existingUser = await _context.Usuario.FindAsync(usuario.Cpf);
                if (existingUser != null)
                {
                    return Conflict("CPF já cadastrado.");
                }

                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUsuario), new { cpf = usuario.Cpf }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao salvar o usuário: " + ex.Message);
            }
        }

        private bool UsuarioExists(string cpf)
        {
            return _context.Usuario.Any(u => u.Cpf == cpf);
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
            var usuario = await _context.Usuario.FindAsync(cpf);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            //Criar mensagem ao atualizar base

            return NoContent();
        }


    }
}
