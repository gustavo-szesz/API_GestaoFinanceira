using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_GestaoFinanceira.Models
{
    public class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }

        // Chave estrangeira para Endereco
        public int EnderecoId { get; set; }  // Propriedade para armazenar o ID do Endereco

        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }  // Propriedade de navegação para o objeto Endereco

        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }

        public DateOnly DataCadastro { get; set; }

        public Pessoa()
        {
            DataCadastro = DateOnly.MinValue;  
        }
    }
}
