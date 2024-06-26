namespace API_GestaoFinanceira.Dtos
{
    public class UpdatePessoaDto
    {
        public string CurrentEmail { get; set; }
        public string NewEmail { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }
        public DateOnly DataCadastro { get; set; }
    }
}
