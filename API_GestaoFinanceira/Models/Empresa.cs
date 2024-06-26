using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_GestaoFinanceira.Models
{
    public class Empresa
    {
        [Key]
        public string Cnpj { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? InscricaoEstadual { get; set; }
        public DateTime? DataAbertura { get; set; }

        public int? PessoaId { get; set; }
        public virtual Pessoa? Pessoa { get; set; }

        public virtual ICollection<EmpresaPessoa>? PessoasAssociadas { get; set; } // Coleção para associar pessoas à empresa

        public virtual ICollection<LancamentoValores>? LancamentoValoresEmpresa { get; set; }
    }

}
