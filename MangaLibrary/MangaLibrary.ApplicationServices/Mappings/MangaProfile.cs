using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models;
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
            CreateMap<Manga, MangaDTO>();
            CreateMap<Manga, MangaDetailsDTO>();
        }
    }
}
