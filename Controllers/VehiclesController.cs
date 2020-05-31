using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kartzmax.Controllers.Resources;
using kartzmax.Core.Models;
using kartzmax.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kartzmax.Controllers {
    public class VehiclesController : Controller {

        // Inject KartzMax DbContext into the Constructor
        private readonly KartzMaxDbContext context;
        private readonly IMapper mapper;

        public VehiclesController (KartzMaxDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet ("api/vehicles")]
        public async Task<IEnumerable<Vehicle>> GetVehicles () {

            var vehicles = await context.Vehicles.ToListAsync ();

            return vehicles;

        }

        [HttpPost ("api/vehicles")]
        public async Task<IActionResult> CreateVehicle ([FromBody] VehicleResource vehicleResource)

        {

            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            // validation which is kind of a overkill  will get through this later
            /*var model=  await context.Models.FindAsync(vehicleResource.ModelId);

            if(model==null){
                ModelState.AddModelError("ModelId","Invalid modelId.");
                return BadRequest(ModelState);eb
            }*/

            var vehicle = mapper.Map<VehicleResource, Vehicle> (vehicleResource);

            context.Vehicles.Add (vehicle);

            await context.SaveChangesAsync ();

            var result = mapper.Map<Vehicle, VehicleResource> (vehicle);

            return Ok (result);
        }

        [HttpPut ("api/vehicles/{id}")]
        public async Task<IActionResult> UpdateVehicle (int id, [FromBody] VehicleResource vehicleResource)

        {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var vehicle = await context.Vehicles.Include (v => v.Features).SingleOrDefaultAsync (v => v.Id == id);
            mapper.Map<VehicleResource, Vehicle> (vehicleResource, vehicle);

            await context.SaveChangesAsync ();

            var result = mapper.Map<Vehicle, VehicleResource> (vehicle);

            return Ok (result);
        }

        [HttpDelete ("api/vehicles/{id}")]
        public async Task<IActionResult> DeleteVehicle (int id) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var vehicle = await context.Vehicles.FindAsync (id);

            if (vehicle == null)
                return NotFound ();

            context.Remove (vehicle);
            await context.SaveChangesAsync ();

            return Ok (id);

        }

    }
}