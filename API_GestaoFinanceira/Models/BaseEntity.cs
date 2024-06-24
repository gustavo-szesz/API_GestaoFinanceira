namespace API_GestaoFinanceira.Models
{
    public class BaseEntity
    {

        public int Id { get; set; }

        public int Status { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
