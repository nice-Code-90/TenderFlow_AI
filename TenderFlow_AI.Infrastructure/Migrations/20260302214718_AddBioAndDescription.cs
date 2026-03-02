using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenderFlow_AI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBioAndDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CompanyProjects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CompanyProjects");
        }
    }
}
