using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using TestProject.Application.Contracts;

namespace TestProject.Application.Services
{
    public class ImageService : IImageService
    {
        private const string PersonImageDirectory = "wwwroot\\persons\\images";

        public async Task<string> SaveImageAsync(IFormFile image, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), PersonImageDirectory, fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
                await image.CopyToAsync(fileSteam);

            return filePath;
        }

        public void DeleteImage(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), PersonImageDirectory, fileName);

            if (!File.Exists(filePath))
                return;

            File.Delete(filePath);
        }
    }
}
