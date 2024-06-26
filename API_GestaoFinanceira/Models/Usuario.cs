using System;
using System.ComponentModel.DataAnnotations;

namespace API_GestaoFinanceira.Models
{
    public class Usuario
    {
        [Key]
        public string Cpf { get; set; }

        public string? Nome { get; set; }
        public string? Rg { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Sexo { get; set; }
        public int? EstadoCivil { get; set; }
        public string? Senha { get; set; }

        public int? PessoaId { get; set; }
        public virtual Pessoa? Pessoa { get; set; }
    }
}
