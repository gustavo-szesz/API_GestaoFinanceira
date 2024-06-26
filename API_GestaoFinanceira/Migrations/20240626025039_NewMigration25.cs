using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_GestaoFinanceira.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoValores_Pessoas_EmpresaId",
                table: "LancamentoValores");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Enderecos_EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Pessoas_EmpresaId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_EmpresaId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoValores_EmpresaId",
                table: "LancamentoValores");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "DataAbertura",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "InscricaoMunicipal",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "NomeFantasia",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "LancamentoValores");

            migrationBuilder.AddColumn<string>(
                name: "EmpresaCnpj",
                table: "LancamentoValores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Enderecos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    NomeFantasia = table.Column<string>(type: "text", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "text", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "text", nullable: true),
                    DataAbertura = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PessoaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Cnpj);
                    table.ForeignKey(
                        name: "FK_Empresas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Rg = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Sexo = table.Column<string>(type: "text", nullable: true),
                    EstadoCivil = table.Column<int>(type: "integer", nullable: true),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    PessoaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Usuarios_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoValores_EmpresaCnpj",
                table: "LancamentoValores",
                column: "EmpresaCnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_PessoaId",
                table: "Empresas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PessoaId",
                table: "Usuarios",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Pessoas_PessoaId",
                table: "Enderecos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoValores_Empresas_EmpresaCnpj",
                table: "LancamentoValores",
                column: "EmpresaCnpj",
                principalTable: "Empresas",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Pessoas_PessoaId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoValores_Empresas_EmpresaCnpj",
                table: "LancamentoValores");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoValores_EmpresaCnpj",
                table: "LancamentoValores");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "EmpresaCnpj",
                table: "LancamentoValores");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Enderecos");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAbertura",
                table: "Pessoas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Pessoas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoas",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Pessoas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Pessoas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoCivil",
                table: "Pessoas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoMunicipal",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFantasia",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "LancamentoValores",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EmpresaId",
                table: "Pessoas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoValores_EmpresaId",
                table: "LancamentoValores",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoValores_Pessoas_EmpresaId",
                table: "LancamentoValores",
                column: "EmpresaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Enderecos_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Pessoas_EmpresaId",
                table: "Pessoas",
                column: "EmpresaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
