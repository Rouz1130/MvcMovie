using System;
using System.ComponentModel.DataAnnotations;
// System.ComponentModel.DataAnnotations namespace provides formatting attributes in addition to the built-in set of validation attributes

namespace MvcMovies.Models
{
    public class Movie
    {
        // type 'prop' hit tab twice shortcut for writing properties.
        public int ID { get; set; } //ID is primary key

        [StringLength(60, MinimumLength =3)]
        [Required]
        public string Title { get; set; }

        //DataType Enumeration provides for many data types, such as Date, Time, PhoneNumber, Currency, EmailAddress
        [Display(Name = "Release Date")] //Display attribute specifies what to display for the name of a field(in our case 'Release Date') instead of ReleaseDate.
        [DataType(DataType.Date)]       // DataType attribute dpecifies the type of the Date , therefore the time information is not displayed.
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } //Not an int because using more that just Whole Numbers.


        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }


        [RegularExpression(@"[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}
