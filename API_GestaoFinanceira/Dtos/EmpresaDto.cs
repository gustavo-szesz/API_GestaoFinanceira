using API_GestaoFinanceira.Models;
using System.ComponentModel.DataAnnotations;

namespace API_GestaoFinanceira.Dtos
{
    public class EmpresaDto
    {
        [Key]
        public string Cnpj { get; set; }

        public string? RazaoSocial { get; set; }

        public string? NomeFantasia { get; set; }

        public string? InscricaoMunicipal { get; set; }

        public string? InscricaoEstadual { get; set; }

        public DateTime? DataAbertura { get; set; }

        public string UsuarioCpf { get; set; }

    }
}
