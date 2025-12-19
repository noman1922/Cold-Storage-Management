using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coldstorage.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ColdRooms_RoomId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "StockTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ExpiryDate",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductName",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Status",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ColdRooms_RoomName",
                table: "ColdRooms");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "StorageType",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "TotalCapacity",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "UsedCapacity",
                table: "ColdRooms");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "Products",
                newName: "ExitDate");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "ColdRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_RoomId",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "ColdRooms",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Phone",
                keyValue: null,
                column: "Phone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "FullName",
                keyValue: null,
                column: "FullName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerDay",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Category",
                keyValue: null,
                column: "Category",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ColdRoomId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "PaymentCompleted",
                table: "Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmountDue",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Temperature",
                table: "ColdRooms",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "AvailableCapacity",
                table: "ColdRooms",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Capacity",
                table: "ColdRooms",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "ColdRooms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ColdRooms",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerKgPerDay",
                table: "ColdRooms",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ColdRooms",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Currency = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StripePaymentId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StripeCustomerId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReceiptUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ColdRooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableCapacity", "Capacity", "IsAvailable", "Name", "PricePerKgPerDay", "Temperature", "Type" },
                values: new object[] { 5000m, 5000m, true, "Frozen Storage (-18°C)", 10m, -18m, "Frozen" });

            migrationBuilder.UpdateData(
                table: "ColdRooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableCapacity", "Capacity", "IsAvailable", "Name", "PricePerKgPerDay", "Temperature", "Type" },
                values: new object[] { 3000m, 3000m, true, "Chilled Storage (4°C)", 6m, 4m, "Chilled" });

            migrationBuilder.UpdateData(
                table: "ColdRooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableCapacity", "Capacity", "IsAvailable", "Name", "PricePerKgPerDay", "Temperature", "Type" },
                values: new object[] { 8000m, 8000m, true, "Ambient Storage (20°C)", 4m, 20m, "Ambient" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColdRoomId",
                table: "Products",
                column: "ColdRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ProductId",
                table: "Payments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ColdRooms_ColdRoomId",
                table: "Products",
                column: "ColdRoomId",
                principalTable: "ColdRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ColdRooms_ColdRoomId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColdRoomId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PaymentCompleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalAmountDue",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AvailableCapacity",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "PricePerKgPerDay",
                table: "ColdRooms");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ColdRooms");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "ExitDate",
                table: "Products",
                newName: "ExpiryDate");

            migrationBuilder.RenameColumn(
                name: "ColdRoomId",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_RoomId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ColdRooms",
                newName: "RoomId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerDay",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Products",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Products",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Temperature",
                table: "ColdRooms",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ColdRooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ColdRooms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "ColdRooms",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ColdRooms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StorageType",
                table: "ColdRooms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCapacity",
                table: "ColdRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UsedCapacity",
                table: "ColdRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "StockTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PerformedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "ColdRooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "RoomName", "Status", "StorageType", "Temperature", "TotalCapacity", "UsedCapacity" },
                values: new object[] { new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(596), "Ultra-low temperature for frozen goods", "Freezer Room A", "Operational", "Frozen", -20.0m, 5000.0m, 1500.0m });

            migrationBuilder.UpdateData(
                table: "ColdRooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "RoomName", "Status", "StorageType", "Temperature", "TotalCapacity", "UsedCapacity" },
                values: new object[] { new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(599), "Medium temperature for dairy and vegetables", "Chilled Room B", "Operational", "Chilled", 2.0m, 3000.0m, 800.0m });

            migrationBuilder.UpdateData(
                table: "ColdRooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "RoomName", "Status", "StorageType", "Temperature", "TotalCapacity", "UsedCapacity" },
                values: new object[] { new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(601), "Room temperature for non-perishables", "Ambient Room C", "Operational", "Ambient", 18.0m, 8000.0m, 2000.0m });

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
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "Email", "FullName", "IsActive", "LastLogin", "Password", "Phone", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(476), "admin@coldstorage.com", "System Administrator", true, null, "admin123", "01712345678", "Admin", "admin" },
                    { 2, new DateTime(2025, 12, 19, 21, 18, 48, 795, DateTimeKind.Local).AddTicks(478), "staff@coldstorage.com", "Storage Staff", true, null, "staff123", "01787654321", "Staff", "staff" }
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
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
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
                name: "IX_Products_Status",
                table: "Products",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ColdRooms_RoomName",
                table: "ColdRooms",
                column: "RoomName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_Date",
                table: "StockTransactions",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_ProductId",
                table: "StockTransactions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ColdRooms_RoomId",
                table: "Products",
                column: "RoomId",
                principalTable: "ColdRooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
