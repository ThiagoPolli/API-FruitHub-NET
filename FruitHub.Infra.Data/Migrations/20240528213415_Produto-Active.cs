using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitHub.Infra.Data.Migrations
{
    public partial class ProdutoActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Produto",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Produto");
        }
    }
}
