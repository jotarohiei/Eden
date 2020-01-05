using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eden.Models;
using Eden.ViewModels;

namespace Eden.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("Movies/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Movies.ToList().SingleOrDefault(c => c.Id == Id);  // ???

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


                /*
        public ActionResult Random()
        {
            var shrek = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer {Name= "Customer 1"},
                new Customer {Name= "Customer 2"},
                new Customer {Name= "Customer 3"}
            };

            // ViewData["Movie"] = Shrek;           Poorly optimised method of passing data to Views.
            // ViewBag.RandomMovie = Shrek;         Poorly optimised method of passing data to Views.

            var viewModel = new RandomMovieViewModel
            {
                Movie = shrek,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("ID: " + id);
        }



        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek 1"},
                new Movie { Id = 2, Name = "Wall-E"},
                new Movie { Id = 3, Name = "Bad Boys"}
            };
        }

                [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        */
    }
}
    
