using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWala.Migrations
{
    public partial class PopulateMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert data into MembershipTypes table without specifying the Id
            migrationBuilder.Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMonths, DiscountRate) VALUES (0, 0, 0)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMonths, DiscountRate) VALUES (30, 1, 10)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMonths, DiscountRate) VALUES (90, 3, 15)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMonths, DiscountRate) VALUES (300, 12, 20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the inserted data if the migration is rolled back
            migrationBuilder.Sql("DELETE FROM MembershipTypes WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
