using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kartzmax.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace kartzmax.Persistence
{
    public class VehicleRepository : IVehicleRepository
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

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            context.Remove(vehicle);
        }

        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.Vehicles
              .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
              .Include(v => v.Model)
                .ThenInclude(m => m.Make)
              .SingleOrDefaultAsync(v => v.Id == id);
        }



        public async Task<IEnumerable<Vehicle>> GetVehicles(Filter filter)
        {
            var query = context.Vehicles
              .Include(v => v.Model)
                .ThenInclude(m => m.Make)
              .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature).AsQueryable();

            if (filter.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == filter.MakeId.Value);


if (filter.ModelId.HasValue)
                query = query.Where(v => v.ModelId == filter.ModelId);

          
          
          
            return await query.ToListAsync();

        }


    }
}