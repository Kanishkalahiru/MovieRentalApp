using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalApp.Models;
using MovieRentalApp.DAL;

namespace MovieRentalApp.Controllers
{
    public class HomeController : Controller
    {
        MoviesDAL movieDAL = new MoviesDAL();

        public ActionResult Index()
        {
            var movieList = movieDAL.getAllMovies();

            if(movieList.Count == 0)
            {
                TempData["Validation"] = "Fuck you";
            }

            return View(movieList);
        }

        public ActionResult InsertMovie()
        {
            ViewBag.Message = "Please type a movie name.";

            return View();
        }

        public ActionResult EditMovieView(int id)
        {
            string movieName = movieDAL.getMovieName(id);
            ViewBag.Message = "Please edit a movie name.";
            ViewBag.movieName = movieName;
            ViewBag.movieId = id;

            return View();
        }

        [HttpPost]
        public ActionResult saveMovieDetails(string inputMovie)
        {
            MovieViewModel movieViewModelObj = new MovieViewModel();
            movieViewModelObj.movieName = inputMovie;
            movieDAL.addMovie(movieViewModelObj);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult editMovieDetails(string inputMovieName)
        {
            MovieViewModel movieViewModelObj = new MovieViewModel();
            movieViewModelObj.movieId = 100;
            movieViewModelObj.movieName = inputMovieName;
            movieDAL.editMovie(movieViewModelObj);
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}