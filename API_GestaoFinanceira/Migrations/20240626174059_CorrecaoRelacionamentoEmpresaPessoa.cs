using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_GestaoFinanceira.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoRelacionamentoEmpresaPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresaPessoas",
                columns: table => new
                {
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    PessoaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaPessoas", x => new { x.Cnpj, x.PessoaId });
                    table.ForeignKey(
                        name: "FK_EmpresaPessoas_Empresas_Cnpj",
                        column: x => x.Cnpj,
                        principalTable: "Empresas",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaPessoas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaPessoas_PessoaId",
                table: "EmpresaPessoas",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaPessoas");
        }
    }
}
