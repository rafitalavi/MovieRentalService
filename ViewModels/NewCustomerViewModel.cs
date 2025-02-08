using MovieWala.Models;
using System.Collections.Generic;

namespace MovieWala.ViewModels
{
    public class NewCustomerViewModel
    {
        public Customer Customer { get; set; }  // Initialize to avoid null warnings
        public IEnumerable<MembershipType> MembershipTypes { get; set; } // Initialize to avoid null warnings
    }
}