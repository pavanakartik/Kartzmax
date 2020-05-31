using System;
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
        private readonly IVehicleRepository repository;

        public VehiclesController(KartzMaxDbContext context, IMapper mapper, IVehicleRepository repository)
        {
            this.repository = repository;
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
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);



            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("api/vehicles/{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);

        }

        [HttpDelete("api/vehicles/{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await context.Vehicles.FindAsync(id);

            if (vehicle == null)
                return NotFound();

            context.Remove(vehicle);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("api/vehicles/{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id);


            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

    }
}