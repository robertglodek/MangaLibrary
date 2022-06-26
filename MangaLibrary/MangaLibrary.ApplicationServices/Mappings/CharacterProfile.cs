using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Character;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Models.Character;
using MangaLibrary.DataAccess.CQRS.Queries.Character;
using MangaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.Mappings
{

    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<AddCharacterRequest, Character>()
                .ForMember(n => n.Image, y => y.MapFrom(s => s.Image))
                .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
                .ForMember(n => n.About, y => y.MapFrom(s => s.About));


            CreateMap<UpdateCharacterRequest, Character>()
                .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
                .ForMember(n => n.Image, y => y.MapFrom(s => s.Image))
                .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
                .ForMember(n => n.About, y => y.MapFrom(s => s.About));

            CreateMap<Character, CharacterDTO>()
                .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
                .ForMember(n => n.Image, y => y.MapFrom(s => s.Image))
                .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
                .ForMember(n => n.About, y => y.MapFrom(s => s.About));

            CreateMap<Character, CharacterDetailsDTO>()
                .ForMember(n => n.Id, y => y.MapFrom(s => s.Id))
                 .ForMember(n => n.Image, y => y.MapFrom(s => s.Image))
                .ForMember(n => n.Name, y => y.MapFrom(s => s.Name))
                .ForMember(n => n.Mangas, y => y.MapFrom(s => s.Mangas))
                .ForMember(n => n.About, y => y.MapFrom(s => s.About));


            CreateMap<GetCharactersRequest, GetCharactersQuery>();
        }
    }
}
