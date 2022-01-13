using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenGaming.Api.Migrations
{
    public partial class AddPunterEventsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusType",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PunterId",
                table: "Events",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PunterId",
                table: "Events",
                column: "PunterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Punters_PunterId",
                table: "Events",
                column: "PunterId",
                principalTable: "Punters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Punters_PunterId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PunterId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PunterId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "StatusType",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
