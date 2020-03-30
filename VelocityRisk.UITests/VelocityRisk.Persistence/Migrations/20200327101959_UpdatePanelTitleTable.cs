using Microsoft.EntityFrameworkCore.Migrations;

namespace VelocityRisk.Persistence.Migrations
{
    public partial class UpdatePanelTitleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "PanelTitles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "PanelTitles");
        }
    }
}
