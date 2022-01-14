using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenGaming.Api.Migrations;

public partial class AddAmountAttributeToEvent : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<decimal>(
            "Amount",
            "Events",
            "decimal(65,30)",
            nullable: false,
            defaultValue: 0m);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "Amount",
            "Events");
    }
}