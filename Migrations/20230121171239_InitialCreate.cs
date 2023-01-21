using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsIdentified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "FirstName", "IsIdentified", "LastName", "Name", "Patronymic" },
                values: new object[,]
                {
                    { 1, "Пётр", true, "Сидоров", "Сидоров Пётр Олегович", "Олегович" },
                    { 2, "Музаффар", false, "Усманов", "Усманов Музаффар Шавкатович", "Шавкатович" },
                    { 3, "Лола", true, "Усманова", "Усманова Лола Юсуповна", "Юсуповна" },
                    { 4, "Надежда", false, "Смирнова", "Смирнова Надежда Николаевна", "Николаевна" }
                });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "Account", "Balance", "CustomerId", "Name" },
                values: new object[,]
                {
                    { 1, "2261684300342121200", 0m, 1, "Кошелёк 1" },
                    { 2, "2261684300214141200", 460m, 2, "Кошелёк 2" },
                    { 3, "2261684300897141200", 16000m, 3, "Кошелёк 2" }
                });

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "Amount", "Time", "WalletId" },
                values: new object[,]
                {
                    { 1, 1000m, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 2000m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 1000m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 12000m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, 100m, new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 100m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 260m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operation_WalletId",
                table: "Operation",
                column: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Wallet");
        }
    }
}
