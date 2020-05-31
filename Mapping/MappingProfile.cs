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

            CreateMap<Feature, FeatureResource> ();
            CreateMap<Vehicle, VehicleResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone } ))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));


        // Api  Resource to Domain

        // WHY WE USED FORMEMBER IS BECAUSE  VehicleResource and Vehicle are not Identical Objects  we refer a Contact Object in Vehicle Resource
        // so to map those attributes to domain we do  use ForMember 

        CreateMap<VehicleResource, Vehicle> ()
            .ForMember (v => v.ContactName, opt => opt.MapFrom (vr => vr.Contact.Name))
            .ForMember (v => v.ContactEmail, opt => opt.MapFrom (vr => vr.Contact.Email))
            .ForMember (v => v.ContactPhone, opt => opt.MapFrom (vr => vr.Contact.Phone))
            .ForMember (v => v.Features, opt => opt.MapFrom (vr => vr.Features.Select (id => new VehicleFeature { FeatureId = id })));

    }

}
}