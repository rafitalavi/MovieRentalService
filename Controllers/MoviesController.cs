using Microsoft.AspNetCore.Mvc;
using MovieWala.Models;
using MovieWala.ViewModels;

namespace MovieWala.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //var viewResult = new ViewResult();

            // List of customers
            var customers = new List<Customer>
            {
                new Customer { Name = "Zihan" },
                new Customer { Name = "Maruf" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //viewResult.ViewData.Model
            // Correct return options:
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
