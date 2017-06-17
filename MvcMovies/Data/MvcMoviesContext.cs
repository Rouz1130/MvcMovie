using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcMovies.Models
{


    //MvcMovieContext object handles the task of connecting to the database and mapping Movie objects to database records.The database context is registered with the Dependency Injection container in the ConfigureServices method in the Startup.cs file:
    public class MvcMoviesContext : DbContext
    {
        public MvcMoviesContext (DbContextOptions<MvcMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovies.Models.Movie> Movie { get; set; }
    }
}
