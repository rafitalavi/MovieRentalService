namespace MovieWala.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public decimal SignUpFee { get; set; }  // The fee charged during sign-up
        public int DurationInMonths { get; set; }  // Duration in months for the membership
        public decimal DiscountRate { get; set; }  // Discount associated with this membership type
    }
}
