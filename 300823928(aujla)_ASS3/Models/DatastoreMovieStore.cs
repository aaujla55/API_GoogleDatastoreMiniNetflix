using System;
using System.Linq;
using Google.Cloud.Datastore.V1;
using System.Collections.Generic;

namespace _300823928_aujla__ASS3.Models
{
    public static class DatastoreMovieStoreExtensionMethods
    {
        /// <summary>
        /// Make a datastore key given a movie's id.
        /// </summary>
        /// <param name="id">A Movie's id.</param>
        /// <returns>A datastore key.</returns>
        public static Key ToKey(this long id) =>
            new Key().WithElement("Movie", id);

        /// <summary>
        /// Make a movie id given a datastore key.
        /// </summary>
        /// <param name="key">A datastore key</param>
        /// <returns>A movie id.</returns>
        public static long ToId(this Key key) => key.Path.First().Id;

        /// <summary>
        /// Create a datastore entity with the same values as movie.
        /// </summary>
        /// <param name="movie">The movie to store in datastore.</param>
        /// <returns>A datastore entity.</returns>
        /// [START toentity]
        public static Entity ToEntity(this Movie movie) => new Entity()
        {
            Key = movie.Id.ToKey(),
            ["Title"] = movie.Title,
            ["Comments"] = movie.Comments,
            ["Rating"] = movie.Rating,
            ["FileUrl"] = movie.FileUrl//TO TO: Change it to file url
            
        };
        // [END toentity]

        /// <summary>
        /// Unpack a movie from a datastore entity.
        /// </summary>
        /// <param name="entity">An entity retrieved from datastore.</param>
        /// <returns>A movie.</returns>
        public static Movie Tomovie(this Entity entity) => new Movie()
        {
            Id = entity.Key.Path.First().Id,
            Title = (string)entity["Title"],
            Comments = (string)entity["Comments"],
            Rating = (string)entity["Rating"],
            FileUrl = (string)entity["FileUrl"], 
        };
    }
    public class DatastoreMovieStore : IMovieStore
    {
        private string _projectId;
        private readonly DatastoreDb _db;

        /// <summary>
        /// Create a new datastore-backed moviestore.
        /// </summary>
        /// <param name="projectId">Your Google Cloud project id</param>
        public DatastoreMovieStore(string projectId = "myproject45644")
        {
            _projectId = projectId;
            _db = DatastoreDb.Create(_projectId);
        }

        // [START create]
        public void Create(Movie movie)
        {
            var entity = movie.ToEntity();
            entity.Key = _db.CreateKeyFactory("Movie").CreateIncompleteKey();
            var keys = _db.Insert(new[] { entity });
            movie.Id = keys.First().Path.First().Id;
        }
        // [END create]

        public void Delete(long id)
        {
            _db.Delete(id.ToKey());
        }

        
        public IEnumerable<Movie> List()
        {
            var query = new Query("Movie");

            var results = _db.RunQuery(query);
            //return new MovieList()
            //{
            //    Movies = )

            //};

            return results.Entities.Select(entity => entity.Tomovie());
        }
       

        public Movie Read(long id)
        {
            return _db.Lookup(id.ToKey())?.Tomovie();
        }

        public void Update(Movie movie)
        {
            _db.Update(movie.ToEntity());
        }
    }

}

