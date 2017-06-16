using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MvcMovies.Controllers
{
    // Controller: the glue between Models and Views. Retreives Model data and returns a response/displays it to the view
    // Controller handles Route Data and Query-String values and passes these values to the Model.
    // For example, http://localhost:1234/Home/About has Route Data of 'Home'(which is this controller) and 'About' (the action method to call in the second method of this controller)

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //The action method to call
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
