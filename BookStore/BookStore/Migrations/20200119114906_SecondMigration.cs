using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Carousels");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Carousels");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Carousels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carousels_SectionId",
                table: "Carousels",
                column: "SectionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carousels_Sections_SectionId",
                table: "Carousels",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carousels_Sections_SectionId",
                table: "Carousels");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Carousels_SectionId",
                table: "Carousels");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Carousels");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Carousels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Carousels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
