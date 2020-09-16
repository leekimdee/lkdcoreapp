using Microsoft.EntityFrameworkCore.Migrations;

namespace LkdCoreApp.Data.EF.Migrations
{
    public partial class ChangeContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "ContactDetails");

            migrationBuilder.AddColumn<string>(
                name: "EmbedCode",
                table: "ContactDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmbedCode",
                table: "ContactDetails");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "ContactDetails",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "ContactDetails",
                nullable: true);
        }
    }
}
