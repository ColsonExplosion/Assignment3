using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers

    //Home controller for ACTIONS
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private MovieListContext context { get; set; }
        public HomeController(MovieListContext con)
		{
            context = con;
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

//Makes sure that you can't add Independance Day
        [HttpGet]
        public IActionResult MoviesList()
        {
            return View(context.Movies.Where(r => r.Title != "Independence Day"));
        }
//sends the movieId from the movies list to the controller and then to the edit view
        [HttpPost]
        public IActionResult MoviesList(int movieId)
        {
            return View("Edit", context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault());
        }
//checks if the model is valid and then will save the changes
		[HttpPost]
		public IActionResult Edit(AddMovieModel movie)
		{
            if (ModelState.IsValid)
            {
                context.Movies.Update(movie);
                context.SaveChanges();
                Response.Redirect("MoviesList");

            }

            return View();
        }

 //deletes records from the database
        [HttpPost]
        public IActionResult Delete(int movieId)
        {

            context.Movies.Remove(context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault());
            context.SaveChanges();
            return View();

        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
//adds movie that is sent in
        [HttpPost]
        public IActionResult AddMovie(AddMovieModel movie)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(movie);
                context.SaveChanges();
                Response.Redirect("MoviesList");
            }

            
            return View();

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
