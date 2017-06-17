using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovies.Models
{
    public class Movie
    {
        // type 'prop' hit tab twice shortcut for writing properties.
        public int ID { get; set; } //ID is primary key
        public string Title { get; set; }

        [Display(Name = "Release Date")] //Display attribute specifies what to display for the name of a field(in our case 'Release Date') instead of ReleaseDate.
        [DataType(DataType.Date)]       // DataType attribute dpecifies the type of the Date , therefore the time information is not displayed.
        public DateTime RelaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; } //Not an int because using more that just Whole Numbers.
    }
}
