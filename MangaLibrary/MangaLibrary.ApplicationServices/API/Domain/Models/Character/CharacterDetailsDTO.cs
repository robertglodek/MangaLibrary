using MangaLibrary.ApplicationServices.API.Domain.Models.Manga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain.Models.Character
{
    public class CharacterDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
        public List<MangaDTO> Mangas { get; set; }
    }
}
