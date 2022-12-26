using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogues.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Children = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Name", "Children" },
                values: new object[] { "Creating Digital Images", "Resources,Evidence,Graphic Products" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Name", "Children" },
                values: new object[] { "Evidence", "" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Name", "Children" },
                values: new object[] { "Final Product", "" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Name", "Children" },
                values: new object[] { "Graphic Products", "Process,Final Product" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Name", "Children" },
                values: new object[] { "Primary Sources", "" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Name", "Children" },
                values: new object[] { "Process", "" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Name", "Children" },
                values: new object[] { "Resources", "Primary Sources,Secondary Sources" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Name", "Children" },
                values: new object[] { "Secondary Sources", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
