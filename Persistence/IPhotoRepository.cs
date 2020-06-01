using System.Collections.Generic;
using System.Threading.Tasks;
using kartzmax.Core.Models;

namespace kartzmax.Persistence
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int vehicleId);
    }
}