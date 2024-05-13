using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitHub.Migrations
{
    /// <inheritdoc />
    public partial class suscriptionNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Subscriptions_SubscriptionId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Members",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Subscriptions_SubscriptionId",
                table: "Members",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Subscriptions_SubscriptionId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Members",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Subscriptions_SubscriptionId",
                table: "Members",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
