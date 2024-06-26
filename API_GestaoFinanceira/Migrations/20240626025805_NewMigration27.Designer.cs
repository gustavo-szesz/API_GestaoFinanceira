﻿// <auto-generated />
using System;
using API_GestaoFinanceira;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_GestaoFinanceira.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20240626025805_NewMigration27")]
    partial class NewMigration27
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_GestaoFinanceira.Models.Empresa", b =>
                {
                    b.Property<string>("Cnpj")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataAbertura")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InscricaoEstadual")
                        .HasColumnType("text");

                    b.Property<string>("InscricaoMunicipal")
                        .HasColumnType("text");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("text");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("integer");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("text");

                    b.HasKey("Cnpj");

                    b.HasIndex("PessoaId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.LancamentoValores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataLancamento")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmpresaCnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumLancamento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Parcelas")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<bool>("TipoFixo")
                        .HasColumnType("boolean");

                    b.Property<string>("TipoLancamento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipoPagamento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.Property<DateOnly>("Vencimento")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaCnpj");

                    b.ToTable("LancamentoValores");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DataCadastro")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.Usuario", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("EstadoCivil")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.Property<string>("Rg")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.Property<string>("Sexo")
                        .HasColumnType("text");

                    b.HasKey("Cpf");

                    b.HasIndex("PessoaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API_GestaoFinanceira.WeatherForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DateString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.Empresa", b =>
                {
                    b.HasOne("API_GestaoFinanceira.Models.Pessoa", "Pessoa")
                        .WithMany("Empresas")
                        .HasForeignKey("PessoaId");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.Endereco", b =>
                {
                    b.HasOne("API_GestaoFinanceira.Models.Pessoa", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.LancamentoValores", b =>
                {
                    b.HasOne("API_GestaoFinanceira.Models.Empresa", "Empresa")
                        .WithMany("LancamentoValoresEmpresa")
                        .HasForeignKey("EmpresaCnpj")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.Usuario", b =>
                {
                    b.HasOne("API_GestaoFinanceira.Models.Pessoa", "Pessoa")
                        .WithMany("Usuarios")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.Empresa", b =>
                {
                    b.Navigation("LancamentoValoresEmpresa");
                });

            modelBuilder.Entity("API_GestaoFinanceira.Models.Pessoa", b =>
                {
                    b.Navigation("Empresas");

                    b.Navigation("Enderecos");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
