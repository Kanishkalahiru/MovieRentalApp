using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class MovieViewModel
    {
        [Key]
        public int movieId { get; set; }
        [Required]
        public string movieName { get; set; }
    }
}