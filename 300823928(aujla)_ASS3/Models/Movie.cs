using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace _300823928_aujla__ASS3.Models
{
  
    public class Movie
    {
        
        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Comments { get; set; }
        public string Rating { get; set; }
        public string FileUrl { get; set; }

    }
}
