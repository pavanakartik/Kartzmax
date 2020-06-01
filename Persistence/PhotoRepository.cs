using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kartzmax.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace kartzmax.Persistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly KartzMaxDbContext context;

        public PhotoRepository(KartzMaxDbContext context)
        {
            this.context = context;

        }
        public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
        {
            return await context.Photos.Where(p => p.VehicleId == vehicleId).ToListAsync();
        }
    }
}