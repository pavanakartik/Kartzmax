using AutoMapper;
using kartzmax.Controllers.Resources;
using kartzmax.Core.Models;

namespace kartzmax.Mapping {
    public class MappingProfile : Profile {

        public MappingProfile () {
            // Domain to Api
            CreateMap<Make, MakeResource> ();
            CreateMap<Model, ModelResource> ();
        }

    }
}