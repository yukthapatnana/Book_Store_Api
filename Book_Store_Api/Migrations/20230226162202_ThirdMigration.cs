using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store_Api.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Bookss",
                columns: table => new
                {
                    ISBN = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    BookCategoryCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookss", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Bookss_BookCategories_BookCategoryCategoryId",
                        column: x => x.BookCategoryCategoryId,
                        principalTable: "BookCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderId = table.Column<string>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<long>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    RegistrationId = table.Column<int>(nullable: true),
                    BooksISBN = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Bookss_BooksISBN",
                        column: x => x.BooksISBN,
                        principalTable: "Bookss",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Registrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registrations",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    OrderDetailOrderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_OrderDetail_OrderDetailOrderId",
                        column: x => x.OrderDetailOrderId,
                        principalTable: "OrderDetail",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookss_BookCategoryCategoryId",
                table: "Bookss",
                column: "BookCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BooksISBN",
                table: "OrderDetail",
                column: "BooksISBN");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_RegistrationId",
                table: "OrderDetail",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderDetailOrderId",
                table: "Payment",
                column: "OrderDetailOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Bookss");

            migrationBuilder.DropTable(
                name: "BookCategories");
        }
    }
}
