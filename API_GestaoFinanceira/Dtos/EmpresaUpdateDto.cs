namespace API_GestaoFinanceira.Dtos
{
    public class EmpresaUpdateDto
    {
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? InscricaoEstadual { get; set; }
        public DateTime? DataAbertura { get; set; }
        public int? PessoaId { get; set; }
    }
}
