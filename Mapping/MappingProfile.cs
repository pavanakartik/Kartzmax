using System.Linq;
using AutoMapper;
using kartzmax.Controllers.Resources;
using kartzmax.Core.Models;

namespace kartzmax.Mapping {
    public class MappingProfile : Profile {

        public MappingProfile () {
            // Domain to Api
            CreateMap<Make, MakeResource> ();
            CreateMap<Model, ModelResource> ();
            CreateMap<Vehicle, VehicleResource>();
            CreateMap<Feature, FeatureResource>();

            // Api  Resource to Domain

              // WHY WE USED FORMEMBER IS BECAUSE  VehicleResource and Vehicle are not Identical Objects  we refer a Contact Object in Vehicle Resource
              // so to map those attributes to domain we do  use ForMember 

            CreateMap<VehicleResource, Vehicle>()
            .ForMember(v=> v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
             .ForMember(v=> v.ContactEmail,opt => opt.MapFrom(vr => vr.Contact.Name))
              .ForMember(v=> v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Name))
              .ForMember(v=> v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature{FeatureId= id})));

        }

    }
}