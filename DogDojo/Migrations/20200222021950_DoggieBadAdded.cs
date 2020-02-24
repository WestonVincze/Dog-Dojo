using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDojo.Migrations
{
    public partial class DoggieBadAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoggieBagItems",
                columns: table => new
                {
                    DoggieBagItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    DoggieBagId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoggieBagItems", x => x.DoggieBagItemId);
                    table.ForeignKey(
                        name: "FK_DoggieBagItems_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoggieBagItems_DogId",
                table: "DoggieBagItems",
                column: "DogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoggieBagItems");
        }
    }
}
