using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Volume;
using MangaLibrary.ApplicationServices.API.Domain.Volume;
using MangaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Mappings
{
    public class VolumeProfile:Profile
    {
        public VolumeProfile()
        {
            CreateMap<AddVolumeRequest, Volume>()
               .ForMember(n => n.Arc, y => y.MapFrom(s => s.Arc))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description))
               .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
               .ForMember(n => n.MangaId, y => y.MapFrom(s => s.MangaId))
               .ForMember(n => n.ReleaseDate, y => y.MapFrom(s => s.ReleaseDate));

            CreateMap<UpdateVolumeRequest, Volume>()
               .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
               .ForMember(n => n.Arc, y => y.MapFrom(s => s.Arc))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description))
               .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
               .ForMember(n => n.MangaId, y => y.MapFrom(s => s.MangaId))
               .ForMember(n => n.ReleaseDate, y => y.MapFrom(s => s.ReleaseDate));


            CreateMap<Volume, VolumeDTO>()
               .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
               .ForMember(n => n.Arc, y => y.MapFrom(s => s.Arc))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description))
               .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
               .ForMember(n => n.ReleaseDate, y => y.MapFrom(s => s.ReleaseDate));

            CreateMap<Volume, VolumeDetailsDTO>()
               .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
               .ForMember(n => n.Arc, y => y.MapFrom(s => s.Arc))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description))
               .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
               .ForMember(n => n.Manga, y => y.MapFrom(s => s.Manga))
               .ForMember(n => n.ReleaseDate, y => y.MapFrom(s => s.ReleaseDate));
        }
    }
}
