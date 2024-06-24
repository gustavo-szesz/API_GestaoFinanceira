using API_GestaoFinanceira.Models;
using System.ComponentModel.DataAnnotations;

namespace API_GestaoFinanceira.Dtos
{
    public class UsuarioDto
    {
        [Key]
        public string Cpf { get; set; }

        public string? Nome { get; set; }

        public string? Rg { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string? Sexo { get; set; }

        public int? EstadoCivil { get; set; }

        public string? Senha { get; set; }

        public List<Empresa> empresa { get; set; }
    }
}
