using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenGaming.Api.Migrations;

public partial class ChangeAmountPrecision : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<decimal>(
            "Amount",
            "Events",
            "decimal(14,2)",
            precision: 14,
            scale: 2,
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "decimal(65,30)");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<decimal>(
            "Amount",
            "Events",
            "decimal(65,30)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "decimal(14,2)",
            oldPrecision: 14,
            oldScale: 2);
    }
}