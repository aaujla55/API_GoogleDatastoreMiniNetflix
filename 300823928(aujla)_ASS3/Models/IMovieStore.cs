using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace _300823928_aujla__ASS3.Models
{
    public interface IMovieStore
    {
        /// <summary>
        /// Creates a new movie.  The Id of the movie will be filled when the
        /// function returns.
        /// </summary>
        void Create(Movie movie);

        Movie Read(long id);

        void Update(Movie book);

        void Delete(long id);

        IEnumerable<Movie> List();

    }
}
