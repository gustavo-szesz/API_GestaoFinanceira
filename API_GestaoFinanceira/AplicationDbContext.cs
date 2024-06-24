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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Empresa)
                .WithMany(e => e.Usuarios)
                .HasForeignKey(u => u.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }



    }
}
