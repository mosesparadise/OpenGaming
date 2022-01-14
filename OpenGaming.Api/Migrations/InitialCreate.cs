using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenGaming.Api.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
                "Operators",
                table => new
                {
                    Id = table.Column<Guid>("char(36)", nullable: false, collation: "ascii_general_ci"),
                    OperatorName = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LicenceCode = table.Column<string>("varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>("datetime(6)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>("datetime(6)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Operators", x => x.Id); })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
                "Punters",
                table => new
                {
                    Id = table.Column<Guid>("char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>("datetime(6)", nullable: false),
                    Address = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostCode = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RiskLevel = table.Column<int>("int", nullable: true),
                    RegisteredBy = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>("datetime(6)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>("datetime(6)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Punters", x => x.Id); })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
                "Events",
                table => new
                {
                    Id = table.Column<Guid>("char(36)", nullable: false, collation: "ascii_general_ci"),
                    EventName = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventDescription = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventDateTime = table.Column<DateTime>("datetime(6)", nullable: false),
                    StatusType = table.Column<int>("int", nullable: false),
                    EventStatusDescription = table.Column<string>("longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PunterId = table.Column<Guid>("char(36)", nullable: false, collation: "ascii_general_ci"),
                    OperatorId = table.Column<Guid>("char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedOn = table.Column<DateTime>("datetime(6)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>("datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        "FK_Events_Operators_OperatorId",
                        x => x.OperatorId,
                        "Operators",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Events_Punters_PunterId",
                        x => x.PunterId,
                        "Punters",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            "IX_Events_OperatorId",
            "Events",
            "OperatorId");

        migrationBuilder.CreateIndex(
            "IX_Events_PunterId",
            "Events",
            "PunterId");

        migrationBuilder.CreateIndex(
            "IX_Operators_LicenceCode",
            "Operators",
            "LicenceCode",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "Events");

        migrationBuilder.DropTable(
            "Operators");

        migrationBuilder.DropTable(
            "Punters");
    }
}