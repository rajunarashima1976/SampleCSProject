using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAssocaiteCode.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demands",
                columns: table => new
                {
                    DemandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimarySkills = table.Column<string>(nullable: false),
                    SecondarySkills = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Start_By_Date = table.Column<DateTime>(nullable: false),
                    Experience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demands", x => x.DemandId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demands");
        }
    }
}
