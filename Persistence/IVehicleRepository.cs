using System.Threading.Tasks;
using kartzmax.Core.Models;

namespace kartzmax.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);

    }
}