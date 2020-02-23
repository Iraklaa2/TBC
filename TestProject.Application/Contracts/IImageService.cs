using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TestProject.Application.Contracts
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(IFormFile image, string fileName);

        void DeleteImage(string fileName);
    }
}
