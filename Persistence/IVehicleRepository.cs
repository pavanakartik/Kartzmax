using System.Collections.Generic;
using System.Threading.Tasks;
using kartzmax.Core.Models;

namespace kartzmax.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);

        Task<IEnumerable<Vehicle>> GetVehicles();

    }
}