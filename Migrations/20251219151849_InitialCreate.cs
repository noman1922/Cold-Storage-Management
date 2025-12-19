using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coldstorage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ColdRooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoomName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Temperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsedCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StorageType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColdRooms", x => x.RoomId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ColdRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "ColdRooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StockTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PerformedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReferenceNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_StockTransactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ColdRooms",
                columns: new[] { "RoomId", "CreatedDate", "Description", "RoomName", "Status", "StorageType", "Temperature", "TotalCapacity", "UsedCapacity" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(596), "Ultra-low temperature for frozen goods", "Freezer Room A", "Operational", "Frozen", -20.0m, 5000.0m, 1500.0m },
                    { 2, new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(599), "Medium temperature for dairy and vegetables", "Chilled Room B", "Operational", "Chilled", 2.0m, 3000.0m, 800.0m },
                    { 3, new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(601), "Room temperature for non-perishables", "Ambient Room C", "Operational", "Ambient", 18.0m, 8000.0m, 2000.0m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "Email", "FullName", "IsActive", "LastLogin", "Password", "Phone", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(476), "admin@coldstorage.com", "System Administrator", true, null, "admin123", "01712345678", "Admin", "admin" },
                    { 2, new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(478), "staff@coldstorage.com", "Storage Staff", true, null, "staff123", "01787654321", "Staff", "staff" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "EntryDate", "ExpiryDate", "Notes", "PricePerDay", "ProductName", "Quantity", "RoomId", "Status" },
                values: new object[,]
                {
                    { 1, "Meat", new DateTime(2025, 12, 9, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(638), new DateTime(2026, 6, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(621), "Premium quality", 10.0m, "Frozen Beef", 500.0m, 1, "Active" },
                    { 2, "Dairy", new DateTime(2025, 12, 17, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(646), new DateTime(2025, 12, 24, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(645), "Pasteurized", 6.0m, "Fresh Milk", 300.0m, 2, "Active" },
                    { 3, "Fruits", new DateTime(2025, 12, 14, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(649), new DateTime(2026, 1, 2, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(647), "Fresh from orchard", 5.0m, "Apples", 800.0m, 3, "Active" }
                });

            migrationBuilder.InsertData(
                table: "StockTransactions",
                columns: new[] { "TransactionId", "Date", "Notes", "PerformedBy", "ProductId", "Quantity", "ReferenceNumber", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 9, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(699), "Initial stock", "admin", 1, 500.0m, "IN-001", 0 },
                    { 2, new DateTime(2025, 12, 17, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(702), "Daily delivery", "staff", 2, 300.0m, "IN-002", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColdRooms_RoomName",
                table: "ColdRooms",
                column: "RoomName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ExpiryDate",
                table: "Products",
                column: "ExpiryDate");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RoomId",
                table: "Products",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Status",
                table: "Products",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_Date",
                table: "StockTransactions",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_ProductId",
                table: "StockTransactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTransactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ColdRooms");
        }
    }
}
