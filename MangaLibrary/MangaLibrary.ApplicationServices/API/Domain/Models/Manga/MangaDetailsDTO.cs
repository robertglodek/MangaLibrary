using MangaLibrary.ApplicationServices.API.Domain.Models.Character;
using MangaLibrary.ApplicationServices.API.Domain.Models.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Models.Demographic;
using MangaLibrary.ApplicationServices.API.Domain.Models.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Models.Manga
{
    public class MangaDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Story { get; set; }
        public string Status { get; set; }
        public bool AnimeAdaptation { get; set; }
        public DemographicDTO Demographic { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<CreatorDTO> Creators { get; set; }
        public List<CharacterDTO> Characters { get; set; }
    }
}
