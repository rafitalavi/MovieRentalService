using System.ComponentModel.DataAnnotations;

namespace MovieWala.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }   // Corrected spelling of "Birthday"

        public bool IsSubscribedToNewsletter { get; set; }

        // Foreign key reference to MembershipType
        [Display(Name = "MemberShip Type")]
        public int? MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }  // Navigation property
    }
}
