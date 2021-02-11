using Microsoft.EntityFrameworkCore.Migrations;

namespace MockServiceApi.Data.Migrations
{
    public partial class ModifiedResClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "RestClients",
                newName: "HttpMethod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HttpMethod",
                table: "RestClients",
                newName: "MyProperty");
        }
    }
}
