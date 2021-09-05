using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportStatus_ReportStatusId",
                schema: "ReportingService",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "ReportStatus",
                schema: "ReportingService");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReportStatusId",
                schema: "ReportingService",
                table: "Reports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportStatusId",
                schema: "ReportingService",
                table: "Reports",
                column: "ReportStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportStatus_ReportStatusId",
                schema: "ReportingService",
                table: "Reports",
                column: "ReportStatusId",
                principalSchema: "ReportingService",
                principalTable: "ReportStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
