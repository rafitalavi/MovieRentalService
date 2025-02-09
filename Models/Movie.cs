using System.ComponentModel.DataAnnotations;

namespace MovieWala.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        // Navigation property for Genre
        [Required]
        public Genre Genre { get; set; }

        // Foreign key to Genre (use int since Genre's Id is int)
        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        public DateTime DateAdded { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
    }
}
