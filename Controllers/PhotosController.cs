using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using kartzmax.Controllers.Resources;
using kartzmax.Core.Models;
using kartzmax.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kartzmax.Controllers
{
    public class PhotosController : Controller
    {
        // Inject KartzMaxDbContext , I
        private readonly KartzMaxDbContext context;
        private readonly IWebHostEnvironment host;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PhotosController(KartzMaxDbContext context, IWebHostEnvironment host, IVehicleRepository repository, IUnitOfWork unitOfWork,
          IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;


            this.host = host;

            this.context = context;

        }

        [HttpPost("api/vehicles/{vehicleId}/photos")]
        public async Task<IActionResult> Upload(int vehicleId, IFormFile file)
        {

            var vehicle = await repository.GetVehicle(vehicleId, includeRelated: false);

            if (vehicle == null)
                return NotFound();

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {

                await file.CopyToAsync(stream);

            }

            var photo = new Photo { FileName = fileName };

            vehicle.Photos.Add(photo);

            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Photo, PhotoResource>(photo));

        }

    }
}