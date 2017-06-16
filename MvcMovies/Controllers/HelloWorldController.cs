using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


// Controller: the glue between Models and Views. Retreives Model data and returns a response/displays it to the view
// TCP port: localhost:1234 : is the network location of the web server.

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {

        // GET: /HelloWorld/ : the target URL.
        // public method in a controller is callable as an HTTP endpoint
        // HTTP endpoint is a targetable URL in the web application
        // HTTP GET method therfore appends 'HelloWorld' to the base URL(Index).

        public IActionResult Index()
        {
            return View(); // returns a View Object.
        }



        // GET: /HelloWorld/Welcome/ 
        // HTTP GET method that is invoked by appending "/HelloWorld/Welcome/" to the URL

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            /*ViewData["Message"] = "Hello" + name;*/   //ViewData is a dictionary which is a Dynamic obejct:Meaning no defined properties until we put something in it.
            /*ViewData["NunTimes"] = nunTimes;        *///ViewData dictionary object contains data that will be added to the view.    

            return View();
        }
    }
}