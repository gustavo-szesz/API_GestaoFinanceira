using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_GestaoFinanceira.Models
{
    public class Usuario : BaseEntity
    {
        public string Cpf { get; set; }

        public string? Nome { get; set; }

        public string? Rg { get; set; }

        private DateTime? dataNascimento;
        public DateTime? DataNascimento
        {
            get => dataNascimento;
            set => dataNascimento = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : value;
        }

        public string? Sexo { get; set; }

        public int? EstadoCivil { get; set; }

        public string? Senha { get; set; }

        public int? EmpresaId { get; set; }

        public virtual Empresa? Empresa { get; set; }
    }
}
