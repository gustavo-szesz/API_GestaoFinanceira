using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_GestaoFinanceira.Models
{
    public class EmpresaPessoa
    {
        public string Cnpj { get; set; } // Chave estrangeira para Empresa
        public int PessoaId { get; set; } // Chave estrangeira para Pessoa

        public virtual Empresa Empresa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }


}
