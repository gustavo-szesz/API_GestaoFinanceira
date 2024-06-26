using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_GestaoFinanceira.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Pessoas_PessoaId",
                table: "Empresas");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Empresas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Pessoas_PessoaId",
                table: "Empresas",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Pessoas_PessoaId",
                table: "Empresas");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Empresas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Pessoas_PessoaId",
                table: "Empresas",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
