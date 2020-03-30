using Microsoft.EntityFrameworkCore.Migrations;

namespace VelocityRisk.Persistence.Migrations
{
    public partial class RenameTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PanelTitles",
                table: "PanelTitles");

            migrationBuilder.RenameTable(
                name: "PanelTitles",
                newName: "PanelItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PanelItems",
                table: "PanelItems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PanelItems",
                table: "PanelItems");

            migrationBuilder.RenameTable(
                name: "PanelItems",
                newName: "PanelTitles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PanelTitles",
                table: "PanelTitles",
                column: "Id");
        }
    }
}
