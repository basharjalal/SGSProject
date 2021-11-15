using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGS.Repositories.Migrations
{
    public partial class AddFiscalYearTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FiscalYear",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(maxLength: 250, nullable: true),
                    ArabicName = table.Column<string>(maxLength: 250, nullable: true),
                    ClubName = table.Column<string>(maxLength: 250, nullable: true),
                    StartedDate = table.Column<DateTime>(nullable: false),
                    EndedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYear", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiscalYear");
        }
    }
}
