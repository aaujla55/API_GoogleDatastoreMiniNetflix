using System;
using _300823928_aujla__ASS3.Models;
using System.Collections.Generic;

namespace _300823928_aujla__ASS3.ViewModels
{
    public class                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        MovieViewModel
    {
        /// <summary>
        /// The book to be displayed in the form.
        /// </summary>
        public Models.Movie Movie;

        /// <summary>
        /// The string displayed to the user.  Either "Edit" or "Create".
        /// </summary>
        public string Action;

        /// <summary>
        /// False when the user tried entering a bad field value.  For example, they entered
        /// "yesterday" for Date Published.
        /// </summary>
        public bool IsValid;

        /// <summary>
        ///  The target of submit form.  Fills asp-action="".
        /// </summary>
        public string FormAction;

        public IEnumerable<Movie> MovieList { get; set; }

    }

    //public class Index
    //{
    //    public MovieList MovieList;
    //    }
    }
