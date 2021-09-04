using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ReportingService");

            migrationBuilder.CreateTable(
                name: "ReportStatus",
                schema: "ReportingService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                schema: "ReportingService",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReportDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReportStatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_ReportStatus_ReportStatusId",
                        column: x => x.ReportStatusId,
                        principalSchema: "ReportingService",
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportStatusId",
                schema: "ReportingService",
                table: "Reports",
                column: "ReportStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports",
                schema: "ReportingService");

            migrationBuilder.DropTable(
                name: "ReportStatus",
                schema: "ReportingService");
        }
    }
}
