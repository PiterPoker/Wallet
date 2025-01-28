using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WalletsMigration_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Wallets_ParentWalletId",
                table: "Wallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Wallets_WalletId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_WalletId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Wallets");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Wallets_ParentWalletId",
                table: "Wallets",
                column: "ParentWalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Wallets_ParentWalletId",
                table: "Wallets");

            migrationBuilder.AddColumn<long>(
                name: "WalletId",
                table: "Wallets",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletId",
                table: "Wallets",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Wallets_ParentWalletId",
                table: "Wallets",
                column: "ParentWalletId",
                principalTable: "Wallets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Wallets_WalletId",
                table: "Wallets",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }
    }
}
