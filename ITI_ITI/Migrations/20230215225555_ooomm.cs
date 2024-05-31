using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_ITI.Migrations
{
    /// <inheritdoc />
    public partial class ooomm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyRestaurantId",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

           

            migrationBuilder.CreateIndex(
                name: "IX_customers_MyRestaurantId",
                table: "customers",
                column: "MyRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_MyRestaurants_MyRestaurantId",
                table: "customers",
                column: "MyRestaurantId",
                principalTable: "MyRestaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_MyRestaurants_MyRestaurantId",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_MyRestaurantId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "MyRestaurantId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "MyRestaurantId1",
                table: "customers");
        }
    }
}
