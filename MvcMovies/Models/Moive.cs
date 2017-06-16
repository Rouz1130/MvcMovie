using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovies.Models
{
    public class Moive
    {
        public int ID { get; set; } //ID is primary key
        public string Title { get; set; }
        public DateTime RelaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; } //Not an int because using more that just Whole Numbers.
    }
}
