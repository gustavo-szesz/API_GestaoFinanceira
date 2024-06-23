using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_GestaoFinanceira.Models
{
    public class Usuario
    {
        [Key]
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Rg { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public int EstadoCivil { get; set; }

        public string Senha { get; set; }

        // Propriedade de navegação para Empresa
        [NotMapped]
        [JsonIgnore]
        public Empresa Empresa { get; set; }
    }
}
