using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    konum = table.Column<string>(type: "text", nullable: true),
                    kisisayisi = table.Column<long>(type: "bigint", nullable: false),
                    telefonsayisi = table.Column<long>(type: "bigint", nullable: false),
                    ReportsId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<List<long>>(type: "bigint[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportDetail_Reports_ReportsId",
                        column: x => x.ReportsId,
                        principalSchema: "ReportingService",
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetail_ReportsId",
                table: "ReportDetail",
                column: "ReportsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportDetail");
        }
    }
}
