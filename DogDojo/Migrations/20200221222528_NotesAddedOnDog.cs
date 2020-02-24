using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDojo.Migrations
{
    public partial class NotesAddedOnDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Dogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Dogs");
        }
    }
}
   