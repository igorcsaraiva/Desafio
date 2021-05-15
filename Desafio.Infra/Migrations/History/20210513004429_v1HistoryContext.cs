using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Infra.Migrations.History
{
    public partial class v1HistoryContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcountHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    AcountEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcountHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalNoteHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalNoteHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfoHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfoHistory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcountHistory_UserId",
                table: "AcountHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalNoteHistory_UserId",
                table: "PersonalNoteHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfoHistory_UserId",
                table: "UserInfoHistory",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcountHistory");

            migrationBuilder.DropTable(
                name: "PersonalNoteHistory");

            migrationBuilder.DropTable(
                name: "UserInfoHistory");
        }
    }
}
