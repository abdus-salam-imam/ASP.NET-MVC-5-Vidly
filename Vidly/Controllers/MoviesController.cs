using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name="Dilwaly" };

            var customers = new List<Customer>()
            {

                new Customer{Name="Customer 1"},
                new Customer{Name="Customer 2"}


            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers= customers


            };

            return View(viewModel);
        }

        public ActionResult Edit(int movieid)
        {

            return Content("id =" + movieid);

        } 

        public ActionResult Index()
        {

            var movies = GetMovies();

            if (movies == null)
                return HttpNotFound();

            return View(movies);
            
        }

        

        private IEnumerable<Movie> GetMovies()
        {

            return new List<Movie>
            {

            new Movie { Name="Dilwaly",Id=1},
            new Movie { Name="DDJL",Id=2}


            };



        }


    }
}