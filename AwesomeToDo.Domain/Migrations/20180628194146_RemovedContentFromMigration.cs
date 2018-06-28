using Microsoft.EntityFrameworkCore.Migrations;

namespace AwesomeToDo.Domain.Migrations
{
    public partial class RemovedContentFromMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "ToDos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ToDos",
                nullable: true);
        }
    }
}
