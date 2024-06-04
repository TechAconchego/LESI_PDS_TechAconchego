using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechAconchego.Migrations
{
    /// <inheritdoc />
    public partial class MigrBDUpdate03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Alojamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Alojamentos");
        }
    }
}
