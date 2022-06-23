using ApiDotflix.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _env;
        private readonly DotflixDbContext _db;

        public FileService(DotflixDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<string> UploadImage(int id, string title, IFormFile image)
        {
            if (!Directory.Exists(_env.WebRootPath + "\\Uploads\\"))
                Directory.CreateDirectory(_env.WebRootPath + "\\Uploads\\");

            var getMovie = new Movie();
            if (id != 0)
            {
                getMovie = await _db.Movie.FindAsync(id);

                File.Delete(Path.Combine(_env.WebRootPath, getMovie.ImageUrl));
            }

            var imageUrl = Path.Combine("Uploads", $"{title}-{image.FileName}");

            using FileStream fileStream = File.Create(_env.WebRootPath + @"\" + imageUrl);

            await image.CopyToAsync(fileStream);
            await fileStream.FlushAsync();

            return imageUrl;
        }
        public async Task DeleteFile(int id)
        {
            var getMovie = await _db.Movie.FindAsync(id);

            File.Delete(Path.Combine(_env.WebRootPath, getMovie.ImageUrl));
        }
    }
}
