using Microsoft.EntityFrameworkCore;
using MovieWala.Models;

namespace MovieWala.Data
{
    public class MovieWalaContext : DbContext
    {
        public MovieWalaContext(DbContextOptions<MovieWalaContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }  // Add MembershipType DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Customer and MembershipType relationship
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.MembershipType)
                .WithMany()  // Multiple customers can belong to one membership type
                .HasForeignKey(c => c.MembershipTypeId)
                .OnDelete(DeleteBehavior.SetNull);  // Or choose your delete behavior (Cascade, etc.)

            // Configure decimal properties for MembershipType
            modelBuilder.Entity<MembershipType>()
                .Property(m => m.SignUpFee)
                .HasColumnType("decimal(18,2)");  // Explicitly set the precision and scale for SignUpFee

            modelBuilder.Entity<MembershipType>()
                .Property(m => m.DiscountRate)
                .HasColumnType("decimal(18,2)");  // Explicitly set the precision and scale for DiscountRate
        }
    }
}
