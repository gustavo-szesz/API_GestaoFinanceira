using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_GestaoFinanceira.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoRelacionamentoEmpresaPessoa5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoValores_Empresas_EmpresaCnpj",
                table: "LancamentoValores");

            migrationBuilder.AlterColumn<string>(
                name: "EmpresaCnpj",
                table: "LancamentoValores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoValores_Empresas_EmpresaCnpj",
                table: "LancamentoValores",
                column: "EmpresaCnpj",
                principalTable: "Empresas",
                principalColumn: "Cnpj");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoValores_Empresas_EmpresaCnpj",
                table: "LancamentoValores");

            migrationBuilder.AlterColumn<string>(
                name: "EmpresaCnpj",
                table: "LancamentoValores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoValores_Empresas_EmpresaCnpj",
                table: "LancamentoValores",
                column: "EmpresaCnpj",
                principalTable: "Empresas",
                principalColumn: "Cnpj",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
