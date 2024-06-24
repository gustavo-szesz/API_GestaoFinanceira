using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_GestaoFinanceira.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    NomeFantasia = table.Column<string>(type: "text", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "text", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "text", nullable: true),
                    DataAbertura = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Logradouro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Pais = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateString = table.Column<string>(type: "text", nullable: false),
                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Rg = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Sexo = table.Column<string>(type: "text", nullable: true),
                    EstadoCivil = table.Column<int>(type: "integer", nullable: true),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    EmpresaId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EnderecoId = table.Column<int>(type: "integer", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    DataCadastro = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
