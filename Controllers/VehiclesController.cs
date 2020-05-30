using System.Collections.Generic;
using System.Threading.Tasks;
using kartzmax.Core.Models;
using kartzmax.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kartzmax.Controllers
{
    public class VehiclesController : Controller
    {

        // Inject KartzMax DbContext into the Constructor
        private readonly KartzMaxDbContext context;

        public VehiclesController(KartzMaxDbContext context)
        {
            this.context = context;

        }



        [HttpGet("api/vehicles")]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {

            var vehicles = await context.Vehicles.ToListAsync();

            return vehicles;


        }

    }
}