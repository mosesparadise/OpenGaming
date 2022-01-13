using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenGaming.Api.Migrations;

public partial class AddAuditableEntity : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<int>(
            "RiskLevel",
            "Punters",
            "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            "DateOfBirth",
            "Punters",
            "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateOnly),
            oldType: "date");

        migrationBuilder.AddColumn<DateTime>(
            "CreatedOn",
            "Punters",
            "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            "LastModifiedDate",
            "Punters",
            "datetime(6)",
            nullable: true);

        migrationBuilder.AlterColumn<int>(
            "StatusType",
            "Events",
            "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AddColumn<DateTime>(
            "CreatedOn",
            "Events",
            "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            "LastModifiedDate",
            "Events",
            "datetime(6)",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "CreatedOn",
            "Punters");

        migrationBuilder.DropColumn(
            "LastModifiedDate",
            "Punters");

        migrationBuilder.DropColumn(
            "CreatedOn",
            "Events");

        migrationBuilder.DropColumn(
            "LastModifiedDate",
            "Events");

        migrationBuilder.AlterColumn<int>(
            "RiskLevel",
            "Punters",
            "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateOnly>(
            "DateOfBirth",
            "Punters",
            "date",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            "StatusType",
            "Events",
            "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);
    }
}