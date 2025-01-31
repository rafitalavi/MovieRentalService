using System.ComponentModel.DataAnnotations;

namespace MovieWala.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }   // Corrected spelling of "Birthday"

        public bool IsSubscribedToNewsletter { get; set; }

        // Foreign key reference to MembershipType
        public int? MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }  // Navigation property
    }
}
