using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechAconchego.Migrations
{
    /// <inheritdoc />
    public partial class MigrBDUpdate02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlojamentoId",
                table: "Manutencoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlojamentoId",
                table: "Alugueres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Alugueres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId",
                table: "Alugueres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_AlojamentoId",
                table: "Manutencoes",
                column: "AlojamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueres_AlojamentoId",
                table: "Alugueres",
                column: "AlojamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueres_UtilizadorId",
                table: "Alugueres",
                column: "UtilizadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueres_Alojamentos_AlojamentoId",
                table: "Alugueres",
                column: "AlojamentoId",
                principalTable: "Alojamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueres_Utilizadores_UtilizadorId",
                table: "Alugueres",
                column: "UtilizadorId",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencoes_Alojamentos_AlojamentoId",
                table: "Manutencoes",
                column: "AlojamentoId",
                principalTable: "Alojamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alugueres_Alojamentos_AlojamentoId",
                table: "Alugueres");

            migrationBuilder.DropForeignKey(
                name: "FK_Alugueres_Utilizadores_UtilizadorId",
                table: "Alugueres");

            migrationBuilder.DropForeignKey(
                name: "FK_Manutencoes_Alojamentos_AlojamentoId",
                table: "Manutencoes");

            migrationBuilder.DropIndex(
                name: "IX_Manutencoes_AlojamentoId",
                table: "Manutencoes");

            migrationBuilder.DropIndex(
                name: "IX_Alugueres_AlojamentoId",
                table: "Alugueres");

            migrationBuilder.DropIndex(
                name: "IX_Alugueres_UtilizadorId",
                table: "Alugueres");

            migrationBuilder.DropColumn(
                name: "AlojamentoId",
                table: "Manutencoes");

            migrationBuilder.DropColumn(
                name: "AlojamentoId",
                table: "Alugueres");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Alugueres");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Alugueres");
        }
    }
}
