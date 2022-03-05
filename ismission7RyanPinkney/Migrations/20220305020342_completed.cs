using Microsoft.EntityFrameworkCore.Migrations;

namespace ismission7RyanPinkney.Migrations
{
    public partial class completed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderCompleted",
                table: "Purchases",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCompleted",
                table: "Purchases");
        }
    }
}
