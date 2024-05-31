using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_ITI.Migrations
{
    /// <inheritdoc />
    public partial class qqqqqqqq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyRestaurantId1",
                table: "customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyRestaurantId1",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
