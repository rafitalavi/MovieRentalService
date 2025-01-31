namespace MovieWala.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSubscribedToNewsletter { get; set; }

        // Foreign key reference to MembershipType
        public int? MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }  // Navigation property
    }
}