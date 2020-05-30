using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kartzmax.Controllers.Resources;
using kartzmax.Core.Models;
using kartzmax.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kartzmax.Controllers {
    public class MakesController : Controller {
        private readonly KartzMaxDbContext context;
        private readonly IMapper mapper;

        // Inject  KartzMaxDbContext 
        // Inject Automapper
        public MakesController (KartzMaxDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet ("api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes () {

            var makes = await context.Makes.Include (m => m.Models).ToListAsync ();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}