using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankServices.Repo.Migrations
{
    public partial class AddedTransactionHistoryTableAndEmailAndPasswordToCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CustomerAccountBalanace",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TransactionHistories",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountTransferred = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrxRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderAccountEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverAccountEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionStatus = table.Column<bool>(type: "bit", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistories", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionHistories");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerAccountBalanace",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
