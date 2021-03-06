﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    
    public class MoviesController : Controller
    {

        private readonly ApplicationDbContext _context;

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

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
                   return View ("ReadOnlyList");

            
            
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            

            var viewModel = new MovieFormViewModel()
            {

                
                Genres = _context.Genres.ToList()


            };
          
            
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {

                var viewModel = new MovieFormViewModel
                {

                    Movie = movie,
                    Genres= _context.Genres.ToList()

                };

                return View("MovieForm", viewModel);


            }


            if (movie.Id == 0)
            {

                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);


            }


            else
            {

                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;

            }
            
            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();


            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()

            };

            return View ("MovieForm", viewModel);
           



        }

        public ActionResult Details(int id)
        {

            var movies = _context.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movies);


        }

        


    }
}