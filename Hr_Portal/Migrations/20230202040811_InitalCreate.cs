using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrPortal.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ContactNo = table.Column<long>(type: "bigint", nullable: false),
                    Dates = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SkillSet = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ResumeName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resumes");
        }
    }
}
