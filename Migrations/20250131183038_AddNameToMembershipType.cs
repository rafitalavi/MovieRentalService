using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWala.Migrations
{
    public partial class AddNameToMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the Name column to the MembershipTypes table
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MembershipTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // Populate the Name column with values
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Pay as You GO' WHERE SignUpFee = 0");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Weekly' WHERE SignUpFee = 30");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE SignUpFee = 90");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Yearly' WHERE SignUpFee = 300");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the Name column if the migration is rolled back
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MembershipTypes");
        }
    }
}
