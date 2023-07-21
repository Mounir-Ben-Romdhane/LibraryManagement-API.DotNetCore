using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionLivres.Migrations
{
    /// <inheritdoc />
    public partial class updatelivre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ordered",
                table: "Livres",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Livres",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Returned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "Ordered",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "Category");
        }
    }
}
