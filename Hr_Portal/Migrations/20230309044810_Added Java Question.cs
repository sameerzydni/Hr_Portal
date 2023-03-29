using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddedJavaQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JavaQuestions",
                columns: table => new
                {
                    QnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QnInWords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Option1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Option4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavaQuestions", x => x.QnId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JavaQuestions");
        }
    }
}
