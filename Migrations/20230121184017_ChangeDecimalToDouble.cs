using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDecimalToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Wallet_WalletId",
                table: "Operation");

            migrationBuilder.DropIndex(
                name: "IX_Operation_WalletId",
                table: "Operation");

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Wallet",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Operation",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 2000.0);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: 12000.0);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 5,
                column: "Amount",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 6,
                column: "Amount",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 7,
                column: "Amount",
                value: 260.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 2,
                column: "Balance",
                value: 460.0);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 3,
                column: "Balance",
                value: 16000.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Wallet",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Operation",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 1000m);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 2000m);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 1000m);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: 12000m);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 5,
                column: "Amount",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 6,
                column: "Amount",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 7,
                column: "Amount",
                value: 260m);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 2,
                column: "Balance",
                value: 460m);

            migrationBuilder.UpdateData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 3,
                column: "Balance",
                value: 16000m);

            migrationBuilder.CreateIndex(
                name: "IX_Operation_WalletId",
                table: "Operation",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Wallet_WalletId",
                table: "Operation",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
