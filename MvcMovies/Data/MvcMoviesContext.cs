using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcMovies.Models
{
    public class MvcMoviesContext : DbContext
    {
        public MvcMoviesContext (DbContextOptions<MvcMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovies.Models.Moive> Moive { get; set; }
    }
}
