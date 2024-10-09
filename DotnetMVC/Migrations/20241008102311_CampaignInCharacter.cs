using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetMVC.Migrations
{
    /// <inheritdoc />
    public partial class CampaignInCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Character",
                newName: "Campaign");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Campaign",
                table: "Character",
                newName: "Type");
        }
    }
}
