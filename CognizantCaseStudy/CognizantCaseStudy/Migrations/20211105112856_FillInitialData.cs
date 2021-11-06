using CognizantCaseStudy.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantCaseStudy.Migrations
{
    public partial class FillInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeChallenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestInputParameter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputParameter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeChallenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedChallengeResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedChallengeResults", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CodeChallenges",
                columns: new[] { "Name", "Description", "OutputParameter", "TestInputParameter" },
                values: new object[,]
                {
                     { "Sum two numbers", "Implement sum of two variables and print result via Console.Write()", "10", "3 7" },
                     { "Multiplication two numbers", "Implement multiplication of two variables and print result via Console.Write()", "20", "2 10" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeChallenges");
        }
    }
}
