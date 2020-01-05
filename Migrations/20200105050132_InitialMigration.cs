using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Nickname = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 45, nullable: false),
                    Password = table.Column<string>(maxLength: 45, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 1, 5, 2, 1, 31, 635, DateTimeKind.Local).AddTicks(1499))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
