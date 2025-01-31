using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWala.Migrations
{
    public partial class UpdateCustomerBirthdayColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Alter the Birthday column to be of type DATE (without time)
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Customers",
                type: "DATE",  // Use the DATE type in SQL (this will store only the date)
                nullable: false,  // Keep it non-nullable if that's your requirement
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");  // The previous type
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the Birthday column to DATETIME if you roll back the migration
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Customers",
                type: "DATETIME",  // Revert to DATETIME (which includes time)
                nullable: false,  // Keep it non-nullable if that's your requirement
                oldClrType: typeof(DateTime),
                oldType: "DATE");  // The type to revert to
        }
    }
}
