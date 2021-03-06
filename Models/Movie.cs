﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eden.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public short NumberInStock { get; set; }
    }
}