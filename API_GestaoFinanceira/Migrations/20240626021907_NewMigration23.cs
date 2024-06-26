using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_GestaoFinanceira.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoValores_Pessoas_Id",
                table: "LancamentoValores");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LancamentoValores",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoValores_Pessoas_EmpresaId",
                table: "LancamentoValores");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoValores_EmpresaId",
                table: "LancamentoValores");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LancamentoValores",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoValores_Pessoas_Id",
                table: "LancamentoValores",
                column: "Id",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
