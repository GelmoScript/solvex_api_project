using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Popip.Model.Migrations
{
    public partial class CheckedFieldAddedToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Checked = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DetetedDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
