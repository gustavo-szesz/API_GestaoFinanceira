using API_GestaoFinanceira.Models;
using Microsoft.EntityFrameworkCore;
namespace API_GestaoFinanceira
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
       : base(options)
        {
        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Empresa> Empresas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuração 1:1 usuario e empresa
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Empresa)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Empresa>(e => e.Cnpj);
            base.OnModelCreating(modelBuilder);
        }


    }
}
