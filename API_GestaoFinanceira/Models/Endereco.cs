using System.ComponentModel.DataAnnotations;

namespace API_GestaoFinanceira.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public int? PessoaId { get; set; }
        public virtual Pessoa? Pessoa { get; set; }
    }
}
