using System.Collections.Generic;
using System.Threading.Tasks;
using kartzmax.Core.Models;
using kartzmax.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kartzmax.Controllers {
    public class FeaturesController : Controller {

        // We need to Inject  our KartzMaxDbContext into this Controller to use it to do Operations to Database

        private readonly KartzMaxDbContext context;

        public FeaturesController (KartzMaxDbContext context) {
            this.context = context;

        }

        [HttpGet ("/api/Features")]
        public async Task<IEnumerable<Feature>> GetFeatures () {
            var features = await context.Features.ToListAsync ();

            return features;
        }

    }
}