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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moive = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (moive == null)
            {
                return NotFound();
            }
            return View(moive);
        }

        // POST: Moives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,RelaseDate,Genre,Price")] Movie moive)
        {
            if (id != moive.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moive);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction("Index");
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
