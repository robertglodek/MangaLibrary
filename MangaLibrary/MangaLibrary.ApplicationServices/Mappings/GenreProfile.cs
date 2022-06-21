using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Models.Genre;
using MangaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Mappings
{
    public class GenreProfile:Profile
    {
        public GenreProfile()
        {
            CreateMap<AddGenreRequest, Genre>()
                .ForMember(n => n.Name, s => s.MapFrom(y => y.Name));

            CreateMap<UpdateGenreRequest,Genre>()
                .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
                .ForMember(n => n.Name, y => y.MapFrom(s => s.Name));

            CreateMap<Genre, GenreDTO>()
               .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
               .ForMember(n => n.Name, y => y.MapFrom(s => s.Name));
        }
    }
}
