using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MangaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Mappings
{
    public class CreatorProfile:Profile
    {
        public CreatorProfile()
        {
            CreateMap<AddCreatorRequest, Creator>()
                .ForMember(n => n.FirstName, y => y.MapFrom(s => s.FirstName))
                .ForMember(n => n.LastName, y => y.MapFrom(s => s.LastName))
                .ForMember(n => n.DateOfBirth, y => y.MapFrom(s => s.DateOfBirth))
                .ForMember(n => n.Description, y => y.MapFrom(s => s.Description));


            CreateMap<UpdateCreatorRequest, Creator>()
                .ForMember(n => n.FirstName, y => y.MapFrom(s => s.FirstName))
                .ForMember(n => n.LastName, y => y.MapFrom(s => s.LastName))
                .ForMember(n => n.DateOfBirth, y => y.MapFrom(s => s.DateOfBirth))
                .ForMember(n => n.Description, y => y.MapFrom(s => s.Description));

            CreateMap<Creator, CreatorDTO>()
                .ForMember(n => n.FirstName, y => y.MapFrom(s => s.FirstName))
                .ForMember(n => n.LastName, y => y.MapFrom(s => s.LastName))
                .ForMember(n => n.DateOfBirth, y => y.MapFrom(s => s.DateOfBirth))
                .ForMember(n => n.Description, y => y.MapFrom(s => s.Description));
        }
    }
}
