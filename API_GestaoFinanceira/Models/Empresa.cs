using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_GestaoFinanceira.Models
{
    public class Empresa
    {
        [Key]
        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string InscricaoMunicipal { get; set; }

        public string InscricaoEstadual { get; set; }

        public DateTime DataAbertura { get; set; }

        // Propriedade de navegação para Usuario
        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
