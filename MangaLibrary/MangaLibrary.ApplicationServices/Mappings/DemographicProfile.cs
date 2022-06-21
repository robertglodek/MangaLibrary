using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using MangaLibrary.ApplicationServices.API.Domain.Models.Demographic;
using MangaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Mappings
{
    public class DemographicProfile:Profile
    {
        public DemographicProfile()
        {
            CreateMap<AddDemographicRequest, Demographic>()
               .ForMember(n => n.Value, y => y.MapFrom(s => s.Value))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description));


            CreateMap<UpdateDemographicRequest, Demographic>()
               .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
               .ForMember(n => n.Value, y => y.MapFrom(s => s.Value))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description));

            CreateMap<Demographic, DemographicDTO>()
                .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
                .ForMember(n => n.Value, y => y.MapFrom(s => s.Value))
                .ForMember(n => n.Description, y => y.MapFrom(s => s.Description));
        }
    }
}
