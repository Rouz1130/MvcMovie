using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovies.Models
{
    public class MovieGenreViewModel
    {
        // contains a list of movies
        public List<Movie> movies;

        // containg a list of genres
        public SelectList genres;

        //contains selected genre
        public string movieGenre { get; set; }
    }
}
