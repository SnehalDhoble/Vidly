using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            //return View();
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

        public ActionResult Random()
        {
            var movie = new Movie() { name = "Shrek!" };
            var customers = new List<Customer> { 
                /*new Customer {Name = "Customer1", Id = 1},
                new Customer {Name = "Customer2", Id = 2},*/
            };

            var randomMovieViewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            // return RedirectToAction("Index", "Home", new { page = 1 , sortby = "name"});
            return View(randomMovieViewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content("year = " + year + ", month = " + month);
        }
    }
}