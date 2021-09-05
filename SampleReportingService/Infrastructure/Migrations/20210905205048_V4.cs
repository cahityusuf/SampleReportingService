using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ReportDetail",
                newName: "ReportDetail",
                newSchema: "ReportingService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ReportDetail",
                schema: "ReportingService",
                newName: "ReportDetail");
        }
    }
}
