using Microsoft.EntityFrameworkCore;
using MovieWala.Models;

namespace MovieWala.Data
{
    public class MovieWalaContext : DbContext
    {
        public MovieWalaContext(DbContextOptions<MovieWalaContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
