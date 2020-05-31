using System.Threading.Tasks;
using kartzmax.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace kartzmax.Persistence
{
    public class VehicleRepository: IVehicleRepository
    {



        private readonly KartzMaxDbContext context;
        public VehicleRepository(KartzMaxDbContext context)
        {
            this.context = context;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await context.Vehicles
              .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
              .Include(v => v.Model)
                .ThenInclude(m => m.Make)
              .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}