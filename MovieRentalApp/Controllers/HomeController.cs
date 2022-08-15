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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}