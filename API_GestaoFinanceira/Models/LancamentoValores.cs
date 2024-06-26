using System;
using System.ComponentModel.DataAnnotations;

namespace API_GestaoFinanceira.Models
{
    public class LancamentoValores
    {
        [Key]
        public int Id { get; set; }
        public string NumLancamento { get; set; }
        public string TipoLancamento { get; set; }
        public bool TipoFixo { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public string TipoPagamento { get; set; }
        public DateOnly Vencimento { get; set; }
        public int Parcelas { get; set; }
        public bool Status { get; set; }
        public DateOnly DataLancamento { get; set; }

        public string? EmpresaCnpj { get; set; }
        public virtual Empresa? Empresa { get; set; }
    }
}
