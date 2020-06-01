using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using kartzmax.Core.Models;

namespace kartzmax.Core {
    public interface IPhotoService {
        Task<Photo> UploadPhoto (Vehicle vehicle, IFormFile file, string uploadsFolderPath);
    }
}