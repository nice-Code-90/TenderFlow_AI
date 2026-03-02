using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenderFlow_AI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorDomainEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPersonDays",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "MaxSoftwareDevelopers",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "WarrantyMonths",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "ClassificationLevel",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "MinimumYearsOfExperience",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "JiraGitConfluenceExperienceYears",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ModernTechStackExperienceYears",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TechnologiesUsed",
                table: "CompanyProjects");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "CompanyProjects");

            migrationBuilder.AddColumn<string>(
                name: "IssuerName",
                table: "Tenders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Importance",
                table: "Requirements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MappingKey",
                table: "Requirements",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Operator",
                table: "Requirements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TargetValue",
                table: "Requirements",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkillName = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyProjectId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAttributes_CompanyProjects_CompanyProjectId",
                        column: x => x.CompanyProjectId,
                        principalTable: "CompanyProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TenderConstraints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    TenderId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderConstraints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderConstraints_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                table: "EmployeeSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAttributes_CompanyProjectId",
                table: "ProjectAttributes",
                column: "CompanyProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderConstraints_TenderId",
                table: "TenderConstraints",
                column: "TenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "ProjectAttributes");

            migrationBuilder.DropTable(
                name: "TenderConstraints");

            migrationBuilder.DropColumn(
                name: "IssuerName",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "MappingKey",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "TargetValue",
                table: "Requirements");

            migrationBuilder.AddColumn<int>(
                name: "MaxPersonDays",
                table: "Tenders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxSoftwareDevelopers",
                table: "Tenders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarrantyMonths",
                table: "Tenders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationLevel",
                table: "Requirements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinimumYearsOfExperience",
                table: "Requirements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JiraGitConfluenceExperienceYears",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModernTechStackExperienceYears",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TechnologiesUsed",
                table: "CompanyProjects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "CompanyProjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
