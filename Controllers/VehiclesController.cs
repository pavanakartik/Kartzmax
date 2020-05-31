using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kartzmax.Controllers.Resources;
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
        private readonly IMapper mapper;

        public VehiclesController(KartzMaxDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

     



       [HttpGet("api/vehicles")]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {

            var vehicles = await context.Vehicles.ToListAsync();

            return vehicles;

        }


          [HttpPost("api/vehicles")]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource  vehicleResource)
        {
            var vehicle  = mapper.Map<VehicleResource, Vehicle>(vehicleResource); 

            context.Vehicles.Add(vehicle);

           await context.SaveChangesAsync();

           var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

           return Ok(result);
        }


    




    }
}