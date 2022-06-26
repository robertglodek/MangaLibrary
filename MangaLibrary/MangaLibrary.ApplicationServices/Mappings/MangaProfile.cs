using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.API.Domain.Models.Manga;
using MangaLibrary.DataAccess.CQRS.Queries.Manga;
using MangaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Mappings
{
    public class MangaProfile:Profile
    {

        public MangaProfile()
        {
            CreateMap<AddMangaRequest, Manga>() 
               .ForMember(n => n.DemographicId, y => y.MapFrom(s => s.DemographicId))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description))
               .ForMember(n => n.Status, y => y.MapFrom(s => s.Status))
               .ForMember(n => n.AnimeAdaptation, y => y.MapFrom(s => s.AnimeAdaptation))
               .ForMember(n => n.Story, y => y.MapFrom(s => s.Story))
               .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
               .ForMember(n => n.Genres, y => y.MapFrom(s => new List<Genre>()))
               .ForMember(n => n.Creators, y => y.MapFrom(s => new List<Creator>()))
               .ForMember(n => n.Characters, y => y.MapFrom(s => new List<Character>()))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description));


            CreateMap<UpdateMangaRequest, Manga>()
              .ForMember(n => n.DemographicId, y => y.MapFrom(s => s.DemographicId))
              .ForMember(n => n.Description, y => y.MapFrom(s => s.Description))
              .ForMember(n => n.Status, y => y.MapFrom(s => s.Status))
              .ForMember(n => n.AnimeAdaptation, y => y.MapFrom(s => s.AnimeAdaptation))
              .ForMember(n => n.Story, y => y.MapFrom(s => s.Story))
              .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
              .ForMember(n => n.Description, y => y.MapFrom(s => s.Description));

            CreateMap<Manga, MangaDTO>()
               .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description))
               .ForMember(n => n.Status, y => y.MapFrom(s => s.Status))
               .ForMember(n => n.AnimeAdaptation, y => y.MapFrom(s => s.AnimeAdaptation))
               .ForMember(n => n.Story, y => y.MapFrom(s => s.Story))
               .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description));


            CreateMap<Manga, MangaDetailsDTO>()
               .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
               .ForMember(n => n.Description, y => y.MapFrom(s => s.Description))
               .ForMember(n => n.Status, y => y.MapFrom(s => s.Status))
               .ForMember(n => n.AnimeAdaptation, y => y.MapFrom(s => s.AnimeAdaptation))
               .ForMember(n => n.Story, y => y.MapFrom(s => s.Story))
               .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
               .ForMember(n => n.Demographic, y => y.MapFrom(s => s.Demographic))
               .ForMember(n => n.Genres, y => y.MapFrom(s => s.Genres))
               .ForMember(n => n.Creators, y => y.MapFrom(s => s.Creators));


            CreateMap<GetMangasRequest, GetMangasQuery>();

        }
    }
}
