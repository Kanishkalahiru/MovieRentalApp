using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalApp.Models;

namespace MovieRentalApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var movie = new MovieView() { movieName = "Pablo Escobar" };
            return View(movie);
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