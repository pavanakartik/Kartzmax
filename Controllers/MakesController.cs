using System.Collections.Generic;
using System.Threading.Tasks;
using kartzmax.Core.Models;
using kartzmax.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kartzmax.Controllers
{
    public class MakesController : Controller
    {
        private readonly KartzMaxDbContext context;

        // Inject  KartzMaxDbContext 
        public MakesController(KartzMaxDbContext context)
        {
            this.context = context;

        }

        [HttpGet("api/makes")]
        public async Task<IEnumerable<Make>> GetMakes()
        {

            var makes = await context.Makes.Include(m => m.Models).ToListAsync();

            return makes;
        }
    }
}