using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_GestaoFinanceira.Models
{
    public class LancamentoValores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string numLancamento { get; set; }


        /// <summary>
        ///  Empresa
        /// </summary>
        public string EmpresaCnpj { get; set; }

        [ForeignKey("EmpresaCnpj")]
        public string Empresa;



        public string TipoLancamento { set; get; }

        public bool TipoFixo { set; get; }

        public string Descricao { get; set; }
        public float Valor { get; set; }

        public string TipoPagamento { get; set; }

        public DateOnly Vencimento { get; set; }

        public int Parcelas { get; set; }

        public bool Status {  get; set; }

        public DateOnly DataLancamento { get; set; }

    }
}
