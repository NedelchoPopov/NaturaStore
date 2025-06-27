using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturaStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryProductProducer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table
                        .Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table
                        .Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table
                        .PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table
                        .Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table
                        .Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Location = table
                        .Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactEmail = table
                        .Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table
                        .Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table
                        .PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table
                        .Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    Description = table
                        .Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table
                        .Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ImageUrl = table
                        .Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table
                        .Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CategoryId = table
                        .Column<int>(type: "int", nullable: false),
                    ProducerId = table
                        .Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table
                        .PrimaryKey("PK_Products", x => x.Id);
                    table
                        .ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table
                        .ForeignKey(
                        name: "FK_Products_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder
                    .CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder
                    .CreateIndex(
                name: "IX_Products_ProducerId",
                table: "Products",
                column: "ProducerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                    .DropTable(
                name: "Products");

            migrationBuilder
                    .DropTable(
                name: "Categories");

            migrationBuilder
                    .DropTable(
                name: "Producers");
        }
    }
}
