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

        public string Welcome(string name, int ID = 1)
        {
            // HtmlEncoder.Default.Encode to protect the app from malicious input (namely JavaScript) using System.Text.Encodings.Web; allows app to use HtmlEncoder.
            // Interpolated Strings: C# 6 feature ($"Hello {name}, ID: {ID}");
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");  
        }
    }
}