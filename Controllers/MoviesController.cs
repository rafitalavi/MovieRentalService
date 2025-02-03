using Microsoft.AspNetCore.Mvc;
using MovieWala.Models;
using MovieWala.ViewModels;
using Microsoft.EntityFrameworkCore;  // Add this for Include method
using MovieWala.Data;

namespace MovieWala.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieWalaContext _context;

        // Constructor injection of MovieWalaContext
        public MoviesController(MovieWalaContext context)
        {
            _context = context;
        }

        // Dispose method is no longer needed when using dependency injection
        // protected override void Dispose(bool disposing)
        // {
        //     _context.Dispose();
        // }

        public ViewResult Index()
        {
            // Eager loading of the Genre property
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            // Eager loading of Genre in Details view
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        public IActionResult Random()
        {
            // Creating a new movie object
            var movie = new Movie() { Name = "Shrek!" };

            // List of customers
            var customers = new List<Customer>
            {
                new Customer { Name = "Zihan" },
                new Customer { Name = "Maruf" }
            };

            // ViewModel to pass the movie and customer list to the view
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            // Return the view with the view model
            return View(viewModel); // Returns a View with the movie model
            // return Content("HELLO WORLD"); // Returns a simple text response
            // return NotFound(); // ✅ Correct replacement for HttpNotFound()
            // return new EmptyResult();

            //return RedirectToAction("Index", "Home"); // ✅ Redirect to Home Index
        }

        //    public IActionResult Edit(int id)
        //    {
        //        return Content($"id = {id}"); // ✅ Correct return type for ContentResult
        //    }

        //    public IActionResult Index(int? pageindex, string sortby)
        //    {
        //        if (!pageindex.HasValue)
        //            pageindex = 1;

        //        if (string.IsNullOrWhiteSpace(sortby)) // ✅ Fixed typo
        //            sortby = "Name";

        //        return Content($"PageIndex = {pageindex} & sortby = {sortby}");
        //    }

        //    // ✅ Fixed routing constraint (integer-based)
        //    [Route("movies/released/{year:int}/{month:int}")]
        //    public IActionResult ByReleaseDate(int year, int month)
        //    {
        //        return Content($"Movies released in {month}/{year}");
        //    }
    }
}
