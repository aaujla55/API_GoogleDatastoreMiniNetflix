using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Google.Cloud.Storage.V1;
using _300823928_aujla__ASS3.Models;
using _300823928_aujla__ASS3.ViewModels;

namespace _300823928_aujla__ASS3.Controllers
{
    public class MoviesController: Controller
    {

        StorageClient _storageClient = StorageClient.Create();
        private string objectName = null;
        private string _bucketName = "mytest11";
     
        private  IMovieStore _store;
        private MovieList _movieList;

        public MoviesController(IMovieStore store, MovieList list)
        {
            _store = store;
        }


        // GET: Books
        public ActionResult Index()
        {
            return View(new MovieViewModel()
            {
                MovieList = _store.List()
            });
        }

        public IActionResult AddMovie()
        {
            ViewData["Message"] = "Your add a movie page.";
            return View();

        }

      
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IFormFile files, Movie movie)
        {
            string downloadLink;
            if (ModelState.IsValid)
            {
            var filePath = Path.GetTempFileName();
            var dir = Directory.GetCurrentDirectory();
            var path = Path.Combine(dir, files.FileName);
            
                    using (var stream = new FileStream(filePath, FileMode.Open))
                    {
                       
                        var storage = StorageClient.Create();
                        objectName = objectName ?? Path.GetFileName(path);
                        var obj = storage.UploadObject(_bucketName, objectName, null, stream);
                       downloadLink = obj.MediaLink;
                        Console.WriteLine($"Uploaded {objectName}.");
                    }

                 movie.FileUrl = downloadLink;
              
                _store.Create(movie);
                
            }
            return RedirectToAction("Index");

        }


        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            return View("Create", movie);
        }

    }






}


