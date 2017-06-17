using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovies.Models;

namespace MvcMovies.Controllers
{

    // Constructor below.
    // MVCMovieContext is teh database context

    public class MoviesController : Controller
    {
       // MVCMovieContext is the database context
      // we use dependency injection to inject  the db context(MvcContext) into the controller
      // the DB context is used in each of the CRUD mehtods in the controller
        private readonly MvcMoviesContext _context;

        public MoviesController(MvcMoviesContext context)
        {
            _context = context;    
        }


        // GET: Moives
        public async Task<IActionResult> Index(string searchString)
        {
            // this first line creates a LINQ query to select movies.
            var movies = from m in _context.Movie
                         select m;

            // If the searchString parameter contains a string the movie query is modified to filter value of search string.
            if (!String.IsNullOrEmpty(searchString))
            {
                // => is a lamda expression , which are used in method-based LINQ queries as arguments to a standard query operator such as Where mehtod or Contains method.(Linq methods: Contains, Where, OrderBy).
                //Linq quries are not exectued when they are defined or modified, when there methods (look above) are called. Rather they are delayed until teh Valueis iterated over in the ToListAsync method is called. 
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }


        // GET: Moives/Details/5

        // the id is defined as nullable thats why we have a ? after the data type(int?) its preventitive in case an ID value is not provided.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moive = await _context.Movie

                // A lambda expression is passed in to select movie entities that matchteh route dat or query string value.
                
                .SingleOrDefaultAsync(m => m.ID == id);


            // if movie not found return not found
            if (moive == null)
            {
                return NotFound();
            }

            // If movie is found , an instance of the Movie model is passed to the details View page.
            return View(moive);
        }

        // GET: Moives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,RelaseDate,Genre,Price")] Movie moive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moive);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(moive);
        }

        // GET: Moives/Edit/5
        // This method action for Edit fetches a Movie and populates the edit form via Edit.cshtml(view).
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                                             // EF method(single...) this method looks up Movie ID parameter and returns selected Movie if matched.   
            var moive = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (moive == null)
            {
                return NotFound();
            }
            return View(moive);
        }




        // POST: Moives/Edit/5
        // This Action method for edit is a Post which processes teh posted Movie Values.

        // HttpPost specifies that Edit method can be invoked ONLY for POST requests.
        [HttpPost]
        // VAlidateAntiForgeryToken is used to prevent forgery of a request and is paired with a token generated in the edit view. View/Edit generates the token with a form tag helper.
        [ValidateAntiForgeryToken]
                                                      // Bind attribute is a way to protect against over-posting. Only include properties in Bind attribute that you want to change. Although ViewModels is an alternative way to approach overposting.                      
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,RelaseDate,Genre,Price")] Movie moive)
        {
            if (id != moive.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid) // this method verifies that the data submitted in the form can be used to modit (edit, update) a Movie object. If valid proceeds to run method.
            {
                try
                {
                    _context.Update(moive);
                    await _context.SaveChangesAsync(); // Once method above is verified. This method updates its saved to the database.
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoiveExists(moive.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index"); // After data has been saved the code redirects theuser to the Index Action mehtod in this controller obviously. Which displays the movie collection including the changes that you have made as a user.
            }
            return View(moive);
        }

        // GET: Moives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moive = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (moive == null)
            {
                return NotFound();
            }

            return View(moive);
        }

        // POST: Moives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moive = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(moive);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MoiveExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
