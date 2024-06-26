using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_GestaoFinanceira.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }
        public DateOnly DataCadastro { get; set; }

        public virtual ICollection<Endereco>? Enderecos { get; set; }
        public virtual ICollection<Usuario>? Usuarios { get; set; }
        public virtual ICollection<Empresa>? Empresas { get; set; }

        public virtual ICollection<EmpresaPessoa>? EmpresasAssociadas { get; set; } // Coleção para associar empresas à pessoa
    }

}
