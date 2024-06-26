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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<LancamentoValores> LancamentoValores { get; set; }

        public DbSet<EmpresaPessoa> EmpresaPessoas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Pessoa)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.PessoaId);

            modelBuilder.Entity<Empresa>()
                .HasOne(e => e.Pessoa)
                .WithMany(p => p.Empresas)
                .HasForeignKey(e => e.PessoaId);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Pessoa)
                .WithMany(p => p.Enderecos)  // Relacionamento um para muitos: uma Pessoa pode ter vários Enderecos
                .HasForeignKey(e => e.PessoaId);

            modelBuilder.Entity<LancamentoValores>()
                .HasOne(l => l.Empresa)
                .WithMany(e => e.LancamentoValoresEmpresa)
                .HasForeignKey(l => l.EmpresaCnpj);

            modelBuilder.Entity<EmpresaPessoa>()
                .HasKey(ep => new { ep.Cnpj, ep.PessoaId });

            modelBuilder.Entity<EmpresaPessoa>()
                .HasOne(ep => ep.Empresa)
                .WithMany(e => e.PessoasAssociadas)
                .HasForeignKey(ep => ep.Cnpj)
                .OnDelete(DeleteBehavior.Cascade); // Defina o comportamento de exclusão conforme necessário

            modelBuilder.Entity<EmpresaPessoa>()
                .HasOne(ep => ep.Pessoa)
                .WithMany(p => p.EmpresasAssociadas)
                .HasForeignKey(ep => ep.PessoaId)
                .OnDelete(DeleteBehavior.Cascade); // Defina o comportamento de exclusão conforme necessário
        }


    }
}

